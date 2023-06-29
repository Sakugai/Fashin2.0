using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomlLib
{
    internal partial class Class1
    {
        private static string fashin;

        public static string Fashins
        {
            get { return fashin; }
            set
            {
                fashin = value;
                var dict = new ResourceDictionary { Source = new Uri($"/Theme/{value}.xaml", UriKind.Relative) };

                Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                Application.Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }

        public static void InitializeTheme()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt"))
            {
                Fashins = File.ReadAllText($"{desktop}\\theme.txt");
            }
        }
    }
}
