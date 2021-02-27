﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ATRoYStatCalc.ViewModel
{
    public class SplashScreenViewModel : ViewModelBase
    {
        public ObservableCollection<string> BuildFiles { get; } = new ObservableCollection<string>();

        public SplashScreenViewModel() 
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Build Files"));
           
            string[] buildExtensions = { ".bmag", ".bwar", ".bsey", ".brog" };

            foreach (FileInfo file in dir.EnumerateFiles())
            {
                if (file.Extension.In(buildExtensions))
                {
                    BuildFiles.Add(file.Name);
                }
            }
        }


    }
}
