using StarMicronics.StarIOExtension;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class AutoSwitchInterfaceSamplePage : Page
    {
        /// <summary>
        /// Sample : Sending commands to printer with Auto Interface Select.
        /// </summary>
        public static void Print()
        {
            // Create receipt commands.
            Emulation emulation = SharedInformationManager.SelectedEmulation;
            LocalizeReceipt localizeReceipt = new EnglishReceipt()
            {
                PaperSize = SharedInformationManager.SelectedPaperSize
            };
            byte[] commands = PrinterFunctions.CreateRasterReceiptData(emulation, localizeReceipt);

            // Send receipts commands.
            CommunicationResult result = null;
            string portName = null;
            string portSettings = SharedInformationManager.SelectedPortSettings; // Your printer PortSettings.
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = Communication.SendCommandsWithAutoInterfaceSelect(commands, portSettings, 30000, out portName);
            });
            progressBarWindow.ShowDialog();

            // Show result.
            string resultMessage = Communication.GetCommunicationResultMessage(result) + Environment.NewLine + "PortName: ";
            if (portName != null)
            {
                resultMessage = resultMessage + portName;
            }
            else
            {
                resultMessage = resultMessage + "null";
            }
            MessageBox.Show(resultMessage, "Communication Result");
        }

        public AutoSwitchInterfaceSamplePage()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }
    }
}
