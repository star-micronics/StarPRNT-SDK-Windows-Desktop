using StarMicronics.StarIOExtension;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class BlackMarkPasteSamplePage : Page
    {
        /// <summary>
        /// Sample : Creating printing paste text with black mark commands.
        /// </summary>
        private byte[] CreatePrintBlackMarkPasteTextCommands(string pasteText)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // Creating localize receipt commands sample is in "LocalizeReceipts/'Language'Receipt.cs"
            LocalizeReceipt localizeReceipt = SharedInformationManager.SelectedLocalizeReceipt;

            // Select using double height.
            bool doubleHeight = (bool)doubleHeightCheckBox.IsChecked;

            // Select black mark type.
            BlackMarkType blackMarkType = SharedInformationManager.SelectedBlackMarkType;

            byte[] commands = PrinterFunctions.CreatePasteTextBlackMarkData(emulation, localizeReceipt, pasteText, doubleHeight, blackMarkType, false);

            return commands;
        }

        private void Print(byte[] commands)
        {
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            Communication.SendCommandsWithProgressBar(commands, portName, portSettings, 30000);
        }

        private void PrintPasteText()
        {
            byte[] commands = CreatePrintBlackMarkPasteTextCommands(pasteTextBox.Text);

            Print(commands);
        }

        public BlackMarkPasteSamplePage()
        {
            InitializeComponent();

            SharedInformationManager.SelectedBlackMarkType = BlackMarkType.Valid;
        }

        private void DetectionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SharedInformationManager.SelectedBlackMarkType = BlackMarkType.ValidWithDetection;
        }

        private void DetectionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SharedInformationManager.SelectedBlackMarkType = BlackMarkType.Valid;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            pasteTextBox.Text = "";
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintPasteText();
        }
    }
}
