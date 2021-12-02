using ATRoYStatCalc.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace ATRoYStatCalc.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        public ObservableRecipient CurrentView { get; set; }

        public MainViewModel() 
        {
            Messenger.Register<MainViewModel, BuildFileSummary>(this, static (r, m) => r.BuildFileReceived(m));
            CurrentView = Ioc.Default.GetService<SplashScreenViewModel>();
        }

        private ICommand _setMageView;
        public ICommand SetMageView => _setMageView ??= new RelayCommand(() =>
        {
            MageViewModel mvm = Ioc.Default.GetService<MageViewModel>();
            mvm.Setup();
            CurrentView = mvm;
        });

        private ICommand _setWarriorView;
        public ICommand SetWarriorView => _setWarriorView ??= new RelayCommand(() =>
        {
            WarriorViewModel wvm = Ioc.Default.GetService<WarriorViewModel>();
            wvm.Setup();
            CurrentView = wvm;
        });

        private ICommand _setSeyanView;
        public ICommand SetSeyanView => _setSeyanView ??= new RelayCommand(() =>
        {
            SeyanViewModel svm = Ioc.Default.GetService<SeyanViewModel>();
            svm.Setup();
            CurrentView = svm;
        });

        private ICommand _setRogueView;
        public ICommand SetRogueView => _setRogueView ??= new RelayCommand(() =>
        {
            RogueViewModel rvm = Ioc.Default.GetService<RogueViewModel>();
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
            return CurrentView != null;
        }

        private ICommand _import;
        public ICommand Import => _import ??= new RelayCommand(async () =>
        {
            await ImportBuildFile();
        });
    
        public async void BuildFileReceived(BuildFileSummary buildFile)
        {
            string filePath = buildFile.FilePath;
            await ImportBuildFile(filePath);
        }

        private async Task ImportBuildFile(string FilePath = null)
        {
            //if user wants to select a file
            if (FilePath == null)
            {
                OpenFileDialog ofd = new()
                {
                    Filter = "Bel Build Files|*.bmag;*.bwar;*.bsey;*.brog",
                    Multiselect = false
                };

                if (ofd.ShowDialog() == true)
                {
                    string selectedFile = ofd.FileName;
                    string ext = ofd.FileName[(ofd.FileName.LastIndexOf('.'))..].ToLower();

                    string json = await File.ReadAllTextAsync(selectedFile);

                    LoadFromJson(ext, json);
                }
            }
            else
            {
                string ext = FilePath[(FilePath.LastIndexOf('.'))..].ToLower();
                string json = await File.ReadAllTextAsync(FilePath);
                LoadFromJson(ext, json);
            }
        }

        private void LoadFromJson(string extension, string json)
        {
            switch (extension)
            {
                case ".bmag":
                    MageViewModel mvm = Ioc.Default.GetService<MageViewModel>();
                    CurrentView = mvm;
                    mvm.Mage = JsonConvert.DeserializeObject<Mage>(json);
                    mvm.Setup();
                    break;

                case ".bwar":
                    WarriorViewModel wvm = Ioc.Default.GetService<WarriorViewModel>();
                    CurrentView = wvm;
                    wvm.Warrior = JsonConvert.DeserializeObject<Warrior>(json);
                    wvm.Setup();
                    break;

                case ".bsey":
                    SeyanViewModel svm = Ioc.Default.GetService<SeyanViewModel>();
                    CurrentView = svm;
                    svm.Seyan = JsonConvert.DeserializeObject<Seyan>(json);
                    svm.Setup();
                    break;

                case ".brog":
                    RogueViewModel rvm = Ioc.Default.GetService<RogueViewModel>();
                    CurrentView = rvm;
                    rvm.Rogue = JsonConvert.DeserializeObject<Rogue>(json);
                    rvm.Setup();
                    break;
            }
        }
    }
}
