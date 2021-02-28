using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class BuildFileSummary
    {
        public string Class { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public class SplashScreenViewModel : ViewModelBase
    {
        public ObservableCollection<BuildFileSummary> BuildFiles { get; } = new ObservableCollection<BuildFileSummary>();
        public BuildFileSummary SelectedFile { get; set; }

        public SplashScreenViewModel()
        {
            if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "BuildFiles")))
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "BuildFiles"));

                string[] buildExtensions = { ".bmag", ".bwar", ".bsey", ".brog" };

                foreach (FileInfo file in dir.EnumerateFiles())
                {
                    if (file.Extension.In(buildExtensions))
                    {
                        string type = "";
                        switch (file.Extension)
                        {
                            case ".bmag":
                                type = "Mage";
                                break;

                            case ".bwar":
                                type = "Warrior";
                                break;

                            case ".bsey":
                                type = "Seyan'du";
                                break;

                            case ".brog":
                                type = "Rogue";
                                break;
                        }

                        BuildFileSummary buildFile = new BuildFileSummary
                        {
                            FileName = file.Name,
                            Class = type,
                            FilePath = file.FullName
                        };

                        BuildFiles.Add(buildFile);
                    }
                }
            }
        }

        private ICommand _import;
        public ICommand Import => _import ??= new RelayCommand(() =>
        {
            Messenger.Default.Send(SelectedFile);
        }, Import_CanExecute);

        public bool Import_CanExecute()
        {
            return SelectedFile != null;
        }
    }
}
