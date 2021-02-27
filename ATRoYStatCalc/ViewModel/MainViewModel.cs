using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Windows.Input;
using System.IO;

namespace ATRoYStatCalc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentView { get; set; }

        public MainViewModel() 
        {
            CurrentView = SimpleIoc.Default.GetInstance<SplashScreenViewModel>();
        }

        private ICommand _setMageView;
        public ICommand SetMageView => _setMageView ??= new RelayCommand(() =>
        {
            MageViewModel mvm = SimpleIoc.Default.GetInstance<MageViewModel>();
            mvm.Setup();
            CurrentView = mvm;
        });

        private ICommand _setWarriorView;
        public ICommand SetWarriorView => _setWarriorView ??= new RelayCommand(() =>
        {
            WarriorViewModel wvm = SimpleIoc.Default.GetInstance<WarriorViewModel>();
            wvm.Setup();
            CurrentView = wvm;
        });

        private ICommand _setSeyanView;
        public ICommand SetSeyanView => _setSeyanView ??= new RelayCommand(() =>
        {
            SeyanViewModel svm = SimpleIoc.Default.GetInstance<SeyanViewModel>();
            svm.Setup();
            CurrentView = svm;
        });

        private ICommand _setRogueView;
        public ICommand SetRogueView => _setRogueView ??= new RelayCommand(() =>
        {
            RogueViewModel rvm = SimpleIoc.Default.GetInstance<RogueViewModel>();
            rvm.Setup();
            CurrentView = rvm;
        });

        private ICommand _export;
        public ICommand Export => _export ??= new RelayCommand(async () =>
        {
            if (CurrentView.GetType() == typeof(MageViewModel))
            {
                MageViewModel temp = (MageViewModel)CurrentView;
                await temp.Export();
            }

            if (CurrentView.GetType() == typeof(WarriorViewModel))
            {
                WarriorViewModel temp = (WarriorViewModel)CurrentView;
                await temp.Export();
            }

            if (CurrentView.GetType() == typeof(SeyanViewModel))
            {
                SeyanViewModel temp = (SeyanViewModel)CurrentView;
                await temp.Export();
            }

            if (CurrentView.GetType() == typeof(RogueViewModel))
            {
                RogueViewModel temp = (RogueViewModel)CurrentView;
                await temp.Export();
            }
        }, Export_CanExecute);

        public bool Export_CanExecute()
        {
            return true; 
        }

        private ICommand _import;
        public ICommand Import => _import ??= new RelayCommand(async () =>
        {
            CurrentView = HelperFuncs.ImportBuildAsync();


            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Bel Build Files|*.bmag;*.bwar;*.bsey;*brog",
                Multiselect = false
            };

            if (ofd.ShowDialog() == true)
            {
                string selectedFile = ofd.FileName;
                string ext = ofd.FileName[(ofd.FileName.LastIndexOf('.') + 1)..].ToLower();

                string json = await File.ReadAllTextAsync(selectedFile);

                switch (ext)
                {
                    case "bmag":
                        MageViewModel mvm = SimpleIoc.Default.GetInstance<MageViewModel>();
                        CurrentView = mvm;
                        mvm.Mage = JsonConvert.DeserializeObject<Mage>(json);
                        mvm.Setup();
                        break;

                    case "bwar":
                        WarriorViewModel wvm = SimpleIoc.Default.GetInstance<WarriorViewModel>();
                        CurrentView = wvm;
                        wvm.Warrior = JsonConvert.DeserializeObject<Warrior>(json);
                        wvm.Setup();
                        break;

                    case "bsey":
                        SeyanViewModel svm = SimpleIoc.Default.GetInstance<SeyanViewModel>();
                        CurrentView = svm;
                        svm.Seyan = JsonConvert.DeserializeObject<Seyan>(json);
                        svm.Setup();
                        break;

                    case "brog":
                        RogueViewModel rvm = SimpleIoc.Default.GetInstance<RogueViewModel>();
                        CurrentView = rvm;
                        rvm.Rogue = JsonConvert.DeserializeObject<Rogue>(json);
                        rvm.Setup();
                        break;
                }
            }
        });
    }
}
