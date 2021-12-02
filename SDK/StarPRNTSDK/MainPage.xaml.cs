using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    /// <summary>
    /// Sample : Getting library version.
    /// </summary>
    public static class LibraryVersionSampleManager
    {
        // StarIO
        public static string GetStarIOVersion()
        {
            return Factory.I.GetStarIOVersion();
        }

        // StarIOExtension
        public static string GetStarIOExtVersion()
        {
            return StarIoExt.GetStarIOExtVersion();
        }

        public static void ShowLibraryVersion()
        {
            string starIOVersion = GetStarIOVersion();
            string starIOExtVersion = GetStarIOExtVersion();

            string message = "StarIO : version " + starIOVersion + "\n" +
                             "StarIOExtension : version " + starIOExtVersion;

            MessageBox.Show(message, "Library Version");
        }
    }

    /// <summary>
    /// Sample : Getting printer serial number.
    /// </summary>
    public static class SerialNumberSampleManager
    {
        public static void ShowPrinterSerialNumber()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            string serialNumber = "";

            // Getting printer serial number sample is in "Communication.GetProductSerialNumber(ref string serialNumber, IPort port)".
            CommunicationResult result = Communication.GetProductSerialNumberWithProgressBar(ref serialNumber, portName, portSettings, 30000);

            if (result.Result == Communication.Result.Success)
            {
                MessageBox.Show(serialNumber, "Product Serial Number");
            }
            else
            {
                Communication.ShowCommunicationResultMessage(result);
            }
        }
    }


    public partial class MainPage : Page
    {
        public Uri JumpUri { get; set; }

        public MainPage()
        {
            InitializeComponent();

            JumpUri = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RemoveAllJournals();

            Util.GoNextPage(JumpUri);

            JumpUri = null;
        }

        private void RemoveAllJournals()
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
        }
    }

    public class ShowSerialNumberClickEvent : BaseCommand
    {
        public override void Execute(object parameter)
        {
            SerialNumberSampleManager.ShowPrinterSerialNumber();
        }
    }

    public class ShowLibraryVersionClickEvent : BaseCommand
    {
        public override void Execute(object parameter)
        {
            LibraryVersionSampleManager.ShowLibraryVersion();
        }
    }

    public class AutoSwitchInterfaceClickEvent : BaseCommand
    {
        public override void Execute(object parameter)
        {
            SelectSettingWindow selectSampleWindow = new SelectSettingWindow()
            {
                SettingTitle = "Select Sample",
                Settings = new string[] { "StarIO Sample", "StarIoExtManager Sample" },
                SelectedIndex = 0
            };

            bool result = (bool)selectSampleWindow.ShowDialog();

            if (result)
            {
                string navigationPage;
                switch (selectSampleWindow.SelectedIndex)
                {
                    default:
                    case 0:
                        navigationPage = "AutoSwitchInterfaceSamplePage.xaml";
                        break;

                    case 1:
                        navigationPage = "AutoSwitchInterfaceExtSamplePage.xaml";
                        break;
                }

                Util.GoNextPage(new Uri(navigationPage, UriKind.Relative));
            }
        }
    }
}
