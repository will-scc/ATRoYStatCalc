using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ATRoYStatCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if (!Directory.Exists("BuildFiles"))
                {
                    Directory.CreateDirectory("BuildFiles");
                }

                string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                for (int i = 0; i <= resourceNames.Count() - 1; i++)
                {
                    string ext = Path.GetExtension(resourceNames[i]);

                    if (ext.In(HelperFuncs.ValidBuildFileExtensions))
                    {
                        string file = GetFileNameFromResource(resourceNames[i]);

                        if (!File.Exists($"BuildFiles/{file}"))
                        {
                            using (var fileStream = File.Create($"BuildFiles/{file}"))
                            {
                                Stream buildStream = ResourceAssembly.GetManifestResourceStream(resourceNames[i]);
                                buildStream.Seek(0, SeekOrigin.Begin);
                                buildStream.CopyTo(fileStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Likely due to insufficient permissions
                MessageBox.Show($"An error occurred during setup: {ex.Message}", "Setup Error");
            }
        }

        private string GetFileNameFromResource(string resourcePath)
        {
            int i = GetNthIndex(resourcePath, '.', 2);
            return resourcePath.Substring(i+1);
        }

        private int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
