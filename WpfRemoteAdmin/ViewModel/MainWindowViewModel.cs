using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfRemoteAdmin.Helpers;

namespace WpfRemoteAdmin.ViewModel
{
    public class MainWindowViewModel
    {
        MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        public DelegateCommand OpenServerCommand { get; set; } 

        public MainWindowViewModel()
        {
            OpenServerCommand = new DelegateCommand(o => OpenServer());

        }

        private void OpenServer()
        {
            window.mainGrid.Children.Clear();
            window.mainGrid.Children.Add(new View.Server());
            window.Title = "Server";
        }

    }
}
