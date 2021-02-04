using ATRoYStatCalc.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public MainViewModel() { }

        private ICommand _setMageView;
        public ICommand SetMageView => _setMageView ??= new RelayCommand(() =>
        {
            CurrentView = SimpleIoc.Default.GetInstance<MageViewModel>();
        });

        private ICommand _setWarriorView;
        public ICommand SetWarriorView => _setWarriorView ??= new RelayCommand(() =>
        {
            CurrentView = SimpleIoc.Default.GetInstance<WarriorViewModel>();
        });

        private ICommand _setSeyanView;
        public ICommand SetSeyanView => _setSeyanView ??= new RelayCommand(() =>
        {
            CurrentView = SimpleIoc.Default.GetInstance<SeyanViewModel>();
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
        });

        private ICommand _import;
        public ICommand Import => _import ??= new RelayCommand(async () =>
        {

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Build Files|*.bmag;*.bwar;*.bsey",
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
                        MageBuild mageBuild = JsonConvert.DeserializeObject<MageBuild>(json);
                        MageViewModel _m = SimpleIoc.Default.GetInstance<MageViewModel>();
                        _m.Mage = mageBuild.Stats;
                        CurrentView = _m;
                        break;

                    case "bwar":
                        WarriorBuild warriorBuild = JsonConvert.DeserializeObject<WarriorBuild>(json);
                        WarriorViewModel _w = SimpleIoc.Default.GetInstance<WarriorViewModel>();
                        _w.Warrior = warriorBuild.Stats;
                        CurrentView = _w;
                        break;

                    case "bsey":
                        SeyanBuild seyanBuild = JsonConvert.DeserializeObject<SeyanBuild>(json);
                        SeyanViewModel _s = SimpleIoc.Default.GetInstance<SeyanViewModel>();
                        _s.Seyan = seyanBuild.Stats;
                        CurrentView = _s;
                        break;
                }
            }
        });
    }
}
