using Microsoft.Win32;
using StarMicronics.StarIOExtension;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class PrinterSampleManager
    {
        /// <summary>
        /// Sample : Sending commands to printer.
        /// </summary>
        public static void Print(byte[] commands)
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Sending commands to printer sample is "Communication.SendCommands(byte[] commands, string portName, string portSettings, int timeout)".
            Communication.SendCommandsWithProgressBar(commands, portName, portSettings, 30000);
        }

        /// <summary>
        /// Sample : Creating printing receipt commands.
        /// </summary>
        public static byte[] CreateLocalizeReceiptCommands(ReceiptInformationManager receiptInfo)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // print paper size
            int paperSize = receiptInfo.ActualPaperSize;

            // Creating localize receipt commands sample is in "LocalizeReceipts/'Language'Receipt.cs"
            ReceiptInformationManager.ReceiptType type = receiptInfo.Type;
            LocalizeReceipt localizeReceipt = receiptInfo.LocalizeReceipt;

            byte[] commands;

            switch (type)
            {
                default:
                case ReceiptInformationManager.ReceiptType.Text:
                    commands = PrinterFunctions.CreateTextReceiptData(emulation, localizeReceipt, false);
                    break;

                case ReceiptInformationManager.ReceiptType.TextUTF8:
                    commands = PrinterFunctions.CreateTextReceiptData(emulation, localizeReceipt, true);
                    break;

                case ReceiptInformationManager.ReceiptType.Raster:
                    commands = PrinterFunctions.CreateRasterReceiptData(emulation, localizeReceipt);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterBothScale:
                    commands = PrinterFunctions.CreateScaleRasterReceiptData(emulation, localizeReceipt, paperSize, true);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterScale:
                    commands = PrinterFunctions.CreateScaleRasterReceiptData(emulation, localizeReceipt, paperSize, false);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterCoupon:
                    commands = PrinterFunctions.CreateCouponData(emulation, localizeReceipt, paperSize, BitmapConverterRotation.Normal);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterCouponRotation90:
                    commands = PrinterFunctions.CreateCouponData(emulation, localizeReceipt, paperSize, BitmapConverterRotation.Right90);
                    break;
            }

            return commands;
        }

        /// <summary>
        /// Sample : Printing photo from image file.
        /// </summary>
        public static void PrintPhotoFromLibrary()
        {
            // Get printing file path.
            string filePath = ShowSelectImageFileDialog();

            if (filePath == null)
            {
                return;
            }

            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // print paper size
            int paperSize = SharedInformationManager.SelectedActualPaperSize;

            byte[] commands = PrinterFunctions.CreateFileOpenData(emulation, filePath, paperSize);

            Print(commands);
        }

        public static void PrintLocalizeReceipt(ReceiptInformationManager receiptInfo)
        {
            byte[] commands = CreateLocalizeReceiptCommands(receiptInfo);


            Print(commands);
        }

        private static string ShowSelectImageFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *bmp, *tiff, *.gif) | *.jpg; *.jpeg; *.png; *bmp; *tiff; *.gif";

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                return fileDialog.FileName;
            }

            return null;
        }
    }


    public class PrintLocalizeReceiptClickEvent : BaseCommand
    {
        public ReceiptInformationManager ReceiptInformationManager { get; set; }

        public override void Execute(object parameter)
        {
            PrinterSampleManager.PrintLocalizeReceipt(ReceiptInformationManager);
        }
    }

    public class PrintPhotoFromLibraryClickEvent : BaseCommand
    {
        public ReceiptInformationManager ReceiptInformationManager { get; set; }

        public override void Execute(object parameter)
        {
            PrinterSampleManager.PrintPhotoFromLibrary();
        }
    }

    public partial class PrinterSamplePage : Page
    {
        public PrinterSamplePage()
        {
            InitializeComponent();
        }
    }
}
