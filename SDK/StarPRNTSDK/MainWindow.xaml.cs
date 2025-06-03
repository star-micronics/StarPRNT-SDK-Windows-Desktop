using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StarPRNTSDK
{
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            Navigate(new MainPage());
        }

        public void NavigateNextPage(Uri uri)
        {
            Navigate(uri);
        }        
    }
}
