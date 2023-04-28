using System.Collections.Generic;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class PrintRedirectionSampleManager
    {
        /// <summary>
        /// Sample : Print redirection.
        /// </summary>
        public static void PrintRedirection(byte[] commands)
        {
            // Your main printer PortName and PortSettings.
            string mainPortName = SharedInformationManager.SelectedPortName;
            string mainPortSettings = SharedInformationManager.SelectedPortSettings;

            // Your sub printer PortName and PortSettings.
            string subPortName = SharedInformationManager.SelectedAllPortInfo[1].PortName;
            string subPortSettings = SharedInformationManager.SelectedAllModelInformation[1].PortSettings;

            // Print redirection sample is "Communication.SendCommandsForRedirection(byte[] commands, string[] portNameArray, string[] portSettingsArray, int[] timeoutMillisArray)".
            Communication.SendCommandsForRedirectionWithProgressBar(commands, new string[] { mainPortName, subPortName }, new string[] { mainPortSettings, subPortSettings }, new int[] { 10000, 10000 });
        }

        public static void PrintLocalizeReceiptUsingRedirection(ReceiptInformationManager receiptInfo)
        {
            byte[] commands = PrinterSampleManager.CreateLocalizeReceiptCommands(receiptInfo);

            PrintRedirection(commands);
        }
    }

    public partial class PrintRedirectionSamplePage : Page
    {
        public PrintRedirectionSamplePage()
        {
            InitializeComponent();
        }
    }

    public class PrintRedirectionClickEvent : BaseCommand
    {
        public ReceiptInformationManager ReceiptInformationManager { get; set; }

        public override void Execute(object parameter)
        {
            PrintRedirectionSampleManager.PrintLocalizeReceiptUsingRedirection(ReceiptInformationManager);
        }
    }
}
