using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

    public class SplashScreenViewModel : ObservableRecipient
    {
        public string AppVersion { get; set; }
        public ObservableCollection<BuildFileSummary> BuildFiles { get; set; }
        public BuildFileSummary SelectedFile { get; set; }

        public SplashScreenViewModel()
        {
            AppVersion = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (Directory.Exists("BuildFiles"))
            {
                DirectoryInfo dir = new(Path.Combine(Environment.CurrentDirectory, "BuildFiles"));

                List<BuildFileSummary> buildFileList = new();

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

                        BuildFileSummary buildFile = new()
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
            Messenger.Send(SelectedFile);
        }, Import_CanExecute);

        public bool Import_CanExecute()
        {
            return SelectedFile != null;
        }
    }
}
