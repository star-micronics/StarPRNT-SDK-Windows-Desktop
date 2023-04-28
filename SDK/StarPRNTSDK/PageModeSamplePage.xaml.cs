using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class PageModeSampleManager
    {
        /// <summary>
        /// Sample : Creating printing receipt with page mode commands.
        /// </summary>
        public static byte[] CreateLocalizeReceiptWithPageModeCommands(ReceiptInformationManager receiptInfo)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // Creating localize receipt commands sample is in "LocalizeReceipts/'Language'Receipt.cs"
            LocalizeReceipt localizeReceipt = receiptInfo.LocalizeReceipt;

            // Image height.
            int height = 30 * 8;

            // Image width.
            int width = SharedInformationManager.SelectedActualPaperSize;

            // Image rotation.
            BitmapConverterRotation rotation = receiptInfo.Rotation;

            // Print region.
            Rectangle printRegion;
            switch (rotation)
            {
                default:
                case BitmapConverterRotation.Normal:
                    printRegion = new Rectangle(0, 0, width, height);
                    break;

                case BitmapConverterRotation.Right90:
                    printRegion = new Rectangle(0, 0, width, width);
                    break;

                case BitmapConverterRotation.Rotate180:
                    printRegion = new Rectangle(0, 0, width, height);
                    rotation = BitmapConverterRotation.Rotate180;
                    break;

                case BitmapConverterRotation.Left90:
                    printRegion = new Rectangle(0, 0, height, width);
                    break;
            }

            byte[] commands = PrinterFunctions.CreateTextPageModeData(emulation, localizeReceipt, printRegion, rotation, false);

            return commands;
        }

        public static void Print(byte[] commands)
        {
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            Communication.SendCommandsWithProgressBar(commands, portName, portSettings, 30000);
        }

        public static void PrintLocalizeReceiptWithPageMode(ReceiptInformationManager receiptInfo)
        {
            byte[] commands = CreateLocalizeReceiptWithPageModeCommands(receiptInfo);

            Print(commands);
        }
    }

    public class PrintLocalizeReceiptWithPageModeClickEvent : BaseCommand
    {
        public ReceiptInformationManager ReceiptInformationManager { get; set; }

        public override void Execute(object parameter)
        {
            PageModeSampleManager.PrintLocalizeReceiptWithPageMode(ReceiptInformationManager);
        }
    }

    public partial class PageModeSamplePage : Page
    {
        public PageModeSamplePage()
        {
            InitializeComponent();
        }
    }
}
