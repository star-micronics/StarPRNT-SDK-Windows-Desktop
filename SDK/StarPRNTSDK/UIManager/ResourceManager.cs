using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows;

namespace StarPRNTSDK
{
    public class ResourceManager
    {
        public string AppTitle
        {
            get
            {
                return Properties.Resources.AppTitle;
            }
        }

        public string Version
        {
            get
            {
                FileVersionInfo assemblyVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

                string MAJORVERSION = assemblyVersion.FileMajorPart.ToString();
                string MINORVERSION = assemblyVersion.FileMinorPart.ToString();
                string BUILDNUMBER = assemblyVersion.FileBuildPart.ToString();

                return MAJORVERSION + "." + MINORVERSION + "." + BUILDNUMBER;
            }
        }

        public string SearchPortSamplePageTitle
        {
            get
            {
                return Properties.Resources.SearchPortSamplePageTitle;
            }
        }

        public string PrinterSamplePageTitle
        {
            get
            {
                return Properties.Resources.PrinterSamplePageTitle;
            }
        }

        public string StarIOSDKSampleTitle
        {
            get
            {
                return Properties.Resources.StarIOSDKSampleTitle;
            }
        }

        public string StarIOExtManagerSampleTitle
        {
            get
            {
                return Properties.Resources.StarIOExtManagerSampleTitle;
            }
        }

        public string PrinterExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.PrinterExtSamplePageTitle;
            }
        }

        public string CashDrawerSamplePageTitle
        {
            get
            {
                return Properties.Resources.CashDrawerSamplePageTitle;
            }
        }

        public string CashDrawerExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.CashDrawerExtSamplePageTitle;
            }
        }

        public string BlackMarkSamplePageTitle
        {
            get
            {
                return Properties.Resources.BlackMarkSamplePageTitle;
            }
        }

        public string BlackMarkPasteSamplePageTitle
        {
            get
            {
                return Properties.Resources.BlackMarkPasteSamplePageTitle;
            }
        }

        public string PageModeSamplePageTitle
        {
            get
            {
                return Properties.Resources.PageModeSamplePageTitle;
            }
        }

        public string AutoSwitchInterfaceSamplePageTitle
        {
            get
            {
                return Properties.Resources.AutoSwitchInterfaceSamplePageTitle;
            }
        }

        public string AutoSwitchInterfaceExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.AutoSwitchInterfaceExtSamplePageTitle;
            }
        }

        public string PrintRedirectionSamplePageTitle
        {
            get
            {
                return Properties.Resources.PrintRedirectionSamplePageTitle;
            }
        }

        public string HoldPrintSamplePageTitle
        {
            get
            {
                return Properties.Resources.HoldPrintSamplePageTitle;
            }
        }

        public string BarcodeReaderExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.BarcodeReaderExtSamplePageTitle;
            }
        }

        public string DisplaySamplePageTitle
        {
            get
            {
                return Properties.Resources.DisplaySamplePageTitle;
            }
        }

        public string DisplayExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.DisplayExtSamplePageTitle;
            }
        }

        public string MelodySpeakerSamplePageTitle
        {
            get
            {
                return Properties.Resources.MelodySpeakerSamplePageTitle;
            }
        }

        public string CombinationSamplePageTitle
        {
            get
            {
                return Properties.Resources.CombinationSamplePageTitle;
            }
        }

        public string CombinationExtSamplePageTitle
        {
            get
            {
                return Properties.Resources.CombinationExtSamplePageTitle;
            }
        }

        public string APISamplePageTitle
        {
            get
            {
                return Properties.Resources.APISamplePageTitle;
            }
        }

        public string DeviceStatusSamplePageTitle
        {
            get
            {
                return Properties.Resources.DeviceStatusSamplePageTitle;
            }
        }

        public string BluetoothSettingSamplePageTitle
        {
            get
            {
                return Properties.Resources.BluetoothSettingSamplePageTitle;
            }
        }

        public string USBSerialNumberSamplePageTitle
        {
            get
            {
                return Properties.Resources.USBSerialNumberSamplePageTitle;
            }
        }

        public string PrinterDriverWithCheckStatusSamplePageTitle
        {
            get
            {
                return Properties.Resources.PrinterDriverWithCheckStatusSamplePageTitle;
            }
        }

        public string PrinterDriverWithBarcodeReaderSamplePageTitle
        {
            get
            {
                return Properties.Resources.PrinterDriverWithBarcodeReaderSamplePageTitle;
            }
        }

        public string PrinterDriverWithDisplaySamplePageTitle
        {
            get
            {
                return Properties.Resources.PrinterDriverWithDisplaySamplePageTitle;
            }
        }

        public string CombinationPrinterDriverSamplePageTitle
        {
            get
            {
                return Properties.Resources.CombinationPrinterDriverSamplePageTitle;
            }
        }

        public Bitmap RefreshImage
        {
            get
            {
                Bitmap image;

                using (var stream = Properties.Resources.Refresh_Image)
                {
                    image = new Bitmap(stream);
                }

                return image;
            }
        }

        public double MainWindowHeight
        {
            get
            {
                double defaultHeight = SystemParameters.WorkArea.Height - 50;

                if (defaultHeight > 800)
                {
                    defaultHeight = 800;
                }

                return defaultHeight;
            }
        }

        public double MainWindowWidth
        {
            get
            {
                double defaultWidth = SystemParameters.WorkArea.Width - 50;

                if (defaultWidth > 1200)
                {
                    defaultWidth = 1200;
                }

                return defaultWidth;
            }
        }
    }
}
