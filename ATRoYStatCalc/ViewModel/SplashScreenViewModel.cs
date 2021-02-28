using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace ATRoYStatCalc.ViewModel
{
    public class BuildFileSummary
    {
        public string Class { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime DateAccessed { get; set; }
    }

    public class SplashScreenViewModel : ViewModelBase
    {
        public string AppVersion { get; set; }
        public ObservableCollection<BuildFileSummary> BuildFiles { get; set; }
        public BuildFileSummary SelectedFile { get; set; }

        public SplashScreenViewModel()
        {
            AppVersion = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (Directory.Exists("BuildFiles"))
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "BuildFiles"));

                List<BuildFileSummary> buildFileList = new List<BuildFileSummary>();

                foreach (FileInfo file in dir.EnumerateFiles())
                {
                    if (file.Extension.In(HelperFuncs.ValidBuildFileExtensions))
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
                            Class = type,
                            FileName = Path.GetFileNameWithoutExtension(file.Name),
                            FilePath = file.FullName,
                            DateAccessed = file.LastAccessTimeUtc
                        };

                        buildFileList.Add(buildFile);
                    }
                }

                buildFileList.Sort((x, y) => y.DateAccessed.CompareTo(x.DateAccessed));
                BuildFiles = new ObservableCollection<BuildFileSummary>(buildFileList);
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
