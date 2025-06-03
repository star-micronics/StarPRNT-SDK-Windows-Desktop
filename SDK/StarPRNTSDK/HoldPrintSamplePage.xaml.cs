using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class HoldPrintSamplePage : Page
    {
        public HoldPrintSamplePage()
        {
            InitializeComponent();
        }

        private void Print()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            bool[] isHoldArray;
            if(holdingControlComboBox.SelectedItem == alwaysComboBoxItem) // Always hold
            {
                isHoldArray = new bool[] { true, true, true };
            }
            else if(holdingControlComboBox.SelectedItem == lastPageComboBoxItem) // Hold before printing the last page
            {
                isHoldArray = new bool[] { false, true, false };
            }
            else // Do not Hold
            {
                isHoldArray = new bool[] { false, false, false };
            }

            List<byte[]> commandList = PrinterFunctions.CreateHoldPrintData(emulation, isHoldArray);

            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...");
            progressBarWindow.BackgroundAction = () =>
            {
                result = Communication.SendCommandsMultiplePages(commandList, portName, portSettings, 30000, 10000, null, (index) =>
                {
                    if(!isHoldArray[index])
                    {
                        return;
                    }

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progressBarWindow.Title = "Please remove paper from printer.";
                    }));
                });
            };
            progressBarWindow.DoBackgroundAction();
            progressBarWindow.ShowDialog();

            Communication.ShowCommunicationResultMessage(result);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }
    }
}
