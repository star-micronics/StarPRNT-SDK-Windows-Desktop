using Microsoft.Win32;
using StarMicronics.StarIOExtension;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class MelodySpeakerSamplePage : Page
    {
        private void PlayRegisteredSound()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Your speaker model.
            MelodySpeakerModel speakerModel = SharedInformationManager.SelectedSpeakerModel;

            // Check MCS10 connection status.
            if (speakerModel == MelodySpeakerModel.MCS10)
            {
                IPeripheralConnectParser parser = StarIoExt.CreateMelodySpeakerConnectParser(speakerModel);

                CommunicationResult parseResult = Communication.ParseDoNotCheckCondition(parser, portName, portSettings, 30000);

                if (parseResult.Result == Communication.Result.Success)
                {
                    if (!parser.IsConnected)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            MessageBox.Show("MelodySpeaker Disconnect.", "Check Status");
                        }));
                        return;
                    }
                }
                else
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Printer Impossible", "Failure");
                    }));
                    return;
                }
            }

            // Set sound storage area and number settings.
            bool specifySound = false;
            MelodySpeakerSoundStorageArea soundStorageArea = MelodySpeakerSoundStorageArea.Area1;
            int soundNumber = 0;

            Dispatcher.Invoke((Action)(() =>
            {
                switch (soundStorageAreaComboBox.SelectedIndex)
                {
                    default:
                    case 0: // Default
                            // Not specify sound storage area and sound number
                        break;

                    case 1: // Area1
                        specifySound = true;
                        soundStorageArea = MelodySpeakerSoundStorageArea.Area1;
                        soundNumber = soundNumberInputTextBox.Value;
                        break;

                    case 2: // Area2
                        specifySound = true;
                        soundStorageArea = MelodySpeakerSoundStorageArea.Area2;
                        soundNumber = soundNumberInputTextBox.Value;
                        break;
                }
            }));

            // Set volume setting.
            bool specifyVolume = false;
            int volume = 0;

            if (speakerModel != MelodySpeakerModel.FVP10) // FVP10 not supported volume setting.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    switch (volumeTypeRegisteredComboBox.SelectedIndex)
                    {
                        default:
                        case 0: // Default
                                // Not specify volume
                            break;

                        case 1: // Off
                            specifyVolume = true;
                            volume = SoundSetting.VolumeOff;
                            break;

                        case 2: // Min
                            specifyVolume = true;
                            volume = SoundSetting.VolumeMin;
                            break;

                        case 3: // Max
                            specifyVolume = true;
                            volume = SoundSetting.VolumeMax;
                            break;

                        case 4: // Manual
                            specifyVolume = true;
                            volume = (int)volumeRegisteredSlider.Value;
                            break;
                    }
                }));
            }

            // Create melody speaker commands.
            byte[] commands = null;
            try
            {
                commands = MelodySpeakerFunctions.CreatePlayingRegisteredSoundData(speakerModel, specifySound, soundStorageArea, soundNumber, specifyVolume, volume);
            }
            catch (ArgumentOutOfRangeException ex) // Specified parameter is out of range.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (ArgumentException ex) // Not allowed operation. (Ex. Specify not supported parameter)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (Exception ex) // Other error.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }

            // Send melody speaker commands.
            CommunicationResult sendCommandsResult = Communication.SendCommands(commands, portName, portSettings, 30000);

            Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(Communication.GetCommunicationResultMessage(sendCommandsResult), "Communication Result");
            }));
        }

        private void PlaySoundData()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Your speaker model.
            MelodySpeakerModel speakerModel = SharedInformationManager.SelectedSpeakerModel;

            // Check MCS10 connection status.
            if (speakerModel == MelodySpeakerModel.MCS10)
            {
                IPeripheralConnectParser parser = StarIoExt.CreateMelodySpeakerConnectParser(speakerModel);

                CommunicationResult parseResult = Communication.ParseDoNotCheckCondition(parser, portName, portSettings, 30000);

                if (parseResult.Result == Communication.Result.Success)
                {
                    if (!parser.IsConnected)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            MessageBox.Show("MelodySpeaker Disconnect.", "Check Status");
                        }));
                        return;
                    }
                }
                else
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Printer Impossible", "Failure");
                    }));
                    return;
                }
            }

            // Specify sound file path.
            string filePath = "";
            Dispatcher.Invoke((Action)(() =>
            {
                filePath = filePathTextBox.Text;
            }));

            // Set volume setting.
            bool specifyVolume = false;
            int volume = 0;

            if (speakerModel != MelodySpeakerModel.FVP10) // FVP10 not supported volume setting.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    switch (volumeTypeReceivedComboBox.SelectedIndex)
                    {
                        default:
                        case 0: // Default
                                // Not specify volume
                            break;

                        case 1: // Off
                            specifyVolume = true;
                            volume = SoundSetting.VolumeOff;
                            break;

                        case 2: // Min
                            specifyVolume = true;
                            volume = SoundSetting.VolumeMin;
                            break;

                        case 3: // Max
                            specifyVolume = true;
                            volume = SoundSetting.VolumeMax;
                            break;

                        case 4: // Manual
                            specifyVolume = true;
                            volume = (int)volumeReceivedSlider.Value; ;
                            break;
                    }
                }));
            }

            // Create melody speaker commands.
            byte[] commands = null;
            try
            {
                commands = MelodySpeakerFunctions.CreatePlayingSoundData(speakerModel, filePath, specifyVolume, volume);
            }
            catch (FormatException ex) // Unsupported sound format.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (ArgumentOutOfRangeException ex) // Specified parameter is out of range.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (ArgumentException ex) // Not allowed operation. (Ex. Specify not supported parameter)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (InvalidOperationException ex) // Not allowed operation. (Ex. Unsupported model is specified.)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }
            catch (Exception ex) // Other error.
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MessageBox.Show(ex.GetType().Name + "\n" + ex.Message, "Error");
                }));
                return;
            }

            // Send melody speaker commands.
            CommunicationResult sendCommandsResult = Communication.SendCommands(commands, portName, portSettings, 30000);

            Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(Communication.GetCommunicationResultMessage(sendCommandsResult), "Communication Result");
            }));
        }

        private void PlayRegisteredSoundWithProgressBar()
        {
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                PlayRegisteredSound();
            });

            progressBarWindow.ShowDialog();
        }

        private void PlaySoundDataWithProgressBar()
        {
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                PlaySoundData();
            });

            progressBarWindow.ShowDialog();
        }

        private void SelectSoundFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Please select wav file.";
            dialog.Filter = "Wav Files (*.wav)|*.wav";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (dialog.ShowDialog() == true)
            {
                filePathTextBox.Text = dialog.FileName;
            }
        }

        public MelodySpeakerSamplePage()
        {
            InitializeComponent();
        }

        private void PlayRegisteredButton_Click(object sender, RoutedEventArgs e)
        {
            PlayRegisteredSoundWithProgressBar();
        }

        private void PlayReceivedButton_Click(object sender, RoutedEventArgs e)
        {
            if (filePathTextBox.Text == null ||
               filePathTextBox.Text.Length == 0)
            {
                MessageBox.Show("Sound file is not selected.", "Error");

                return;
            }

            PlaySoundDataWithProgressBar();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            SelectSoundFile();
        }

        private void SoundStorageAreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            bool isDefaultSelected = (soundStorageAreaComboBox.SelectedIndex == 0);

            soundNumberTitleLabel.IsEnabled = !isDefaultSelected;
            soundNumberInputTextBox.IsEnabled = !isDefaultSelected;
        }

        private void VolumeTypeRegisteredComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            bool isManualSelected = ((sender as ComboBox).SelectedIndex == 4);

            volumeRegisteredSlider.IsEnabled = isManualSelected;
            volumeRegisteredValueTextBlock.IsEnabled = isManualSelected;
        }

        private void VolumeTypeReceivedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            bool isManualSelected = ((sender as ComboBox).SelectedIndex == 4);

            volumeReceivedSlider.IsEnabled = isManualSelected;
            volumeReceivedValueTextBlock.IsEnabled = isManualSelected;
        }
    }
}
