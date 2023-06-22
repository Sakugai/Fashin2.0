using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Найкраще_мисце
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string fashin;
        
        public static string Fashins
        {
            get { return fashin; }
            set { 
                fashin = value;
                var dict = new ResourceDictionary { Source = new Uri($"/Resourse/{value}.xaml", UriKind.Relative) };

                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);

            }
        }
        public App()
        {
            InitializeComponent();

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(File.Exists($"{desktop}\\theme.txt"))
            {
                Fashins = File.ReadAllText($"{desktop}\\theme.txt");
            
            }
        }
    }
}
