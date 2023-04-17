using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace StarPRNTSDK
{
    public partial class EnterTextWindow : Window
    {
        public EnterTextWindow()
        {
            InitializeComponent();

            RegisterDescripter();

            SetPosition();
        }

        public EnterTextWindow(EnterTextWindow sourceObject)
        {
            InitializeComponent();

            RegisterDescripter();

            SettingTitle = sourceObject.SettingTitle;

            Settings = sourceObject.Settings;

            if (sourceObject.TextBoxTexts != null)
            {
                TextBoxTexts = sourceObject.TextBoxTexts;
            }

            SetPosition();
        }

        public string SettingTitle
        {
            get
            {
                return (string)TitleLabel.Content;
            }
            set
            {
                TitleLabel.Content = value;
            }
        }

        public string[] Settings
        {
            get
            {
                return settingsArray;
            }
            set
            {
                settingsArray = new string[value.Length];

                Array.Copy(value, 0, settingsArray, 0, settingsArray.Length);

                SetSettings();
            }
        }

        public static readonly DependencyProperty TextBoxTextsProperty = DependencyProperty.Register("TextBoxTexts", typeof(string[]), typeof(EnterTextWindow));
        public string[] TextBoxTexts
        {
            get
            {
                return (string[])GetValue(TextBoxTextsProperty);
            }
            set
            {
                textBoxTexts = new string[value.Length];

                Array.Copy(value, 0, textBoxTexts, 0, textBoxTexts.Length);

                SetValue(TextBoxTextsProperty, textBoxTexts);
            }
        }

        private void OnTextBoxTextsPropertyChanged(object sender, EventArgs e)
        {
            EnterText(TextBoxTexts);
        }

        private List<TextBox> settingTextBoxList;

        private string[] settingsArray;

        private string[] textBoxTexts;

        private void SetPosition()
        {
            MainWindow mainWindow = Util.GetMainWindow();

            if (mainWindow.ActualHeight != 0)
            {
                Owner = mainWindow;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
        }

        private void SetSettings()
        {
            settingTextBoxList = new List<TextBox>();

            ContainerStackPanel.Children.RemoveRange(0, ContainerStackPanel.Children.Count);

            foreach (string setting in settingsArray)
            {
                Label settingLabel = new Label();
                settingLabel.Content = setting;
                settingLabel.FontSize = 15;

                TextBox settingTextBox = new TextBox();
                settingTextBox.Margin = new Thickness(0, 0, 0, 10);

                ContainerStackPanel.Children.Add(settingLabel);
                ContainerStackPanel.Children.Add(settingTextBox);

                settingTextBoxList.Add(settingTextBox);
            }
        }

        private void EnterText(string[] textArray)
        {
            int index = 0;

            foreach (TextBox settingTextBox in settingTextBoxList)
            {
                if (textArray.Length - 1 < index)
                {
                    break;
                }

                settingTextBox.Text = textArray[index];

                index++;
            }
        }

        private void SetTextBoxTexts()
        {
            string[] textArray = new string[settingTextBoxList.Count];

            int index = 0;

            foreach (TextBox settingTextBox in settingTextBoxList)
            {
                textArray[index] = settingTextBox.Text;

                index++;
            }

            TextBoxTexts = textArray;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            SetTextBoxTexts();

            DialogResult = true;

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }

        private void RegisterDescripter()
        {
            DependencyPropertyDescriptor descripter = DependencyPropertyDescriptor.FromProperty(TextBoxTextsProperty, typeof(EnterTextWindow));

            descripter.AddValueChanged(this, OnTextBoxTextsPropertyChanged);
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        const int GWL_STYLE = -16;
        const int WS_SYSMENU = 0x80000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            int style = GetWindowLong(handle, GWL_STYLE);
            style = style & (~WS_SYSMENU);
            SetWindowLong(handle, GWL_STYLE, style);
        }
    }
}
