using StarMicronics.StarIOExtension;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class APIFunctionManager
    {
        /// <summary>
        /// Sample : Creating API commands.
        /// </summary>
        private static byte[] CreateAPICommands(APIManager.APIType type)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // Your printer paper size.
            int paperSize = SharedInformationManager.SelectedActualPaperSize;

            byte[] commands;

            switch (type)
            {
                default:
                case APIManager.APIType.Generic:
                    commands = APIFunctions.CreateGenericData(emulation);
                    break;

                case APIManager.APIType.FontStyle:
                    commands = APIFunctions.CreateFontStyleData(emulation);
                    break;

                case APIManager.APIType.Initialization:
                    commands = APIFunctions.CreateInitializationData(emulation);
                    break;

                case APIManager.APIType.CodePage:
                    commands = APIFunctions.CreateCodePageData(emulation);
                    break;

                case APIManager.APIType.International:
                    commands = APIFunctions.CreateInternationalData(emulation);
                    break;

                case APIManager.APIType.Feed:
                    commands = APIFunctions.CreateFeedData(emulation);
                    break;

                case APIManager.APIType.CharacterSpace:
                    commands = APIFunctions.CreateCharacterSpaceData(emulation);
                    break;

                case APIManager.APIType.LineSpace:
                    commands = APIFunctions.CreateLineSpaceData(emulation);
                    break;

                case APIManager.APIType.TopMargin:
                    commands = APIFunctions.CreateTopMarginData(emulation);
                    break;

                case APIManager.APIType.Emphasis:
                    commands = APIFunctions.CreateEmphasisData(emulation);
                    break;

                case APIManager.APIType.Invert:
                    commands = APIFunctions.CreateInvertData(emulation);
                    break;

                case APIManager.APIType.UnderLine:
                    commands = APIFunctions.CreateUnderLineData(emulation);
                    break;

                case APIManager.APIType.Multiple:
                    commands = APIFunctions.CreateMultipleData(emulation);
                    break;

                case APIManager.APIType.AbsolutePosition:
                    commands = APIFunctions.CreateAbsolutePositionData(emulation);
                    break;

                case APIManager.APIType.Alignment:
                    commands = APIFunctions.CreateAlignmentData(emulation);
                    break;

                case APIManager.APIType.HorizontalTab:
                    commands = APIFunctions.CreateHorizontalTabData(emulation);
                    break;

                case APIManager.APIType.Logo:
                    commands = APIFunctions.CreateLogoData(emulation);
                    break;

                case APIManager.APIType.CutPaper:
                    commands = APIFunctions.CreateCutPaperData(emulation);
                    break;

                case APIManager.APIType.Peripheral:
                    commands = APIFunctions.CreatePeripheralData(emulation);
                    break;

                case APIManager.APIType.Sound:
                    commands = APIFunctions.CreateSoundData(emulation);
                    break;

                case APIManager.APIType.Bitmap:
                    commands = APIFunctions.CreateBitmapData(emulation, paperSize);
                    break;

                case APIManager.APIType.Barcode:
                    commands = APIFunctions.CreateBarcodeData(emulation);
                    break;

                case APIManager.APIType.Pdf417:
                    commands = APIFunctions.CreatePdf417Data(emulation);
                    break;

                case APIManager.APIType.QrCode:
                    commands = APIFunctions.CreateQrCodeData(emulation);
                    break;

                case APIManager.APIType.BlackMark:
                    // Select black mark type.
                    BlackMarkType? blackmarkType = ShowSelectBlackMarkTypeWindow();

                    if (blackmarkType == null)
                    {
                        return null;
                    }

                    commands = APIFunctions.CreateBlackMarkData(emulation, (BlackMarkType)blackmarkType);
                    break;

                case APIManager.APIType.PageMode:
                    commands = APIFunctions.CreatePageModeData(emulation, paperSize);
                    break;

                case APIManager.APIType.PrintableArea:
                    PrintableAreaType? printableAreaType = ShowSelectPrintableAreaTypeWindow();

                    if (printableAreaType == null)
                    {
                        return null;
                    }

                    commands = APIFunctions.CreatePrintableAreaData(emulation, (PrintableAreaType)printableAreaType);

                    break;
            }

            return commands;
        }

        /// <summary>
        /// Sample : Sending API commands to printer.
        /// </summary>
        public static void SendAPICommands(APIManager.APIType type)
        {
            byte[] commands = CreateAPICommands(type);

            if (commands == null)
            {
                return;
            }

            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Sending commands to printer sample is "Communication.SendCommands(byte[] commands, string portName, string portSettings, int timeout)".
            Communication.SendCommandsWithProgressBar(commands, portName, portSettings, 30000);
        }

        private static BlackMarkType? ShowSelectBlackMarkTypeWindow()
        {
            BlackMarkType? blackMarkType = null;

            SelectSettingWindow selectblackMarkWindow = new SelectSettingWindow(SelectSettingWindow.Templete.BlackMarkType);

            bool? result = selectblackMarkWindow.ShowDialog();

            if (result == true)
            {
                blackMarkType = selectblackMarkWindow.SelectedBlackMarkType;
            }
            else
            {
                return null;
            }

            return blackMarkType;
        }

        private static PrintableAreaType? ShowSelectPrintableAreaTypeWindow()
        {
            PrintableAreaType? type = null;

            SelectSettingWindow selectPrintableAreaTypeWindow = new SelectSettingWindow();
            selectPrintableAreaTypeWindow.Title = "Select printable area type.";
            selectPrintableAreaTypeWindow.Settings = new string[] { "Standard", "Type1", "Type2", "Type3", "Type4" };
            selectPrintableAreaTypeWindow.SelectedIndex = 0;

            bool? result = selectPrintableAreaTypeWindow.ShowDialog();

            if (result == true)
            {
                switch(selectPrintableAreaTypeWindow.SelectedIndex)
                {
                    default:
                    case 0:
                        type = PrintableAreaType.Standard;
                        break;

                    case 1:
                        type = PrintableAreaType.Type1;
                        break;

                    case 2:
                        type = PrintableAreaType.Type2;
                        break;

                    case 3:
                        type = PrintableAreaType.Type3;
                        break;

                    case 4:
                        type = PrintableAreaType.Type4;
                        break;
                }
            }

            return type;
        }
    }

    public partial class APISamplePage : Page
    {
        public APISamplePage()
        {
            InitializeComponent();
        }
    }
}
