using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StarMicronics.StarIODeviceSetting;

namespace StarIODeviceSettingSDK
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            // Please refer to the SDK manual for portName argument which using for communicating with the printer.
            // (https://www.star-m.jp/products/s_print/sdk/starprnt_sdk/manual/wind_csharp/en/api_stario_i_factory.html#getport)
            string portName = PortNameTextBox.Text;
            StarNetworkManager manager = new StarNetworkManager(portName);

            try
            {
                StarNetworkSetting setting = manager.Load();
                SteadyLanSetting steadyLan = setting.SteadyLan;

                MessageBox.Show(this, "SteadyLAN Setting : " + steadyLan.ToString(), "Communication Result", MessageBoxButton.OK);
            }
            catch (StarIODeviceSettingException ex)
            {
                MessageBox.Show(this, ex.Message, "Communication Result", MessageBoxButton.OK);
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            // Please refer to the SDK manual for portName argument which using for communicating with the printer.
            // (https://www.star-m.jp/products/s_print/sdk/starprnt_sdk/manual/wind_csharp/en/api_stario_i_factory.html#getport)
            string portName = PortNameTextBox.Text;
            StarNetworkManager manager = new StarNetworkManager(portName);

            SteadyLanSetting steadyLan;
            switch (SteadyLanSettingComboBox.SelectedIndex)
            {
                default:
                case 0:
                    steadyLan = SteadyLanSetting.Unspecified;
                    break;

                case 1:
                    steadyLan = SteadyLanSetting.Disable;
                    break;

                case 2:
                    steadyLan = SteadyLanSetting.iOS;
                    break;

                case 3:
                    steadyLan = SteadyLanSetting.Android;
                    break;

                case 4:
                    steadyLan = SteadyLanSetting.Windows;
                    break;
            }

            StarNetworkSetting setting = new StarNetworkSetting()
            {
                SteadyLan = steadyLan
            };

            try
            {
                manager.Apply(setting);

                MessageBox.Show(this, "Data transmission succeeded." + Environment.NewLine + "Please confirm the current settings by Load method after a printer reset is executed.", "Communication Result", MessageBoxButton.OK);
            }
            catch (StarIODeviceSettingException ex)
            {
                MessageBox.Show(this, ex.Message, "Communication Result", MessageBoxButton.OK);
            }
        }
    }
}
