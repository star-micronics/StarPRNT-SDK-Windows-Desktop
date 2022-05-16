using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace StarPRNTSDK
{
    public partial class SelectSettingWindow : Window
    {
        public SelectSettingWindow()
        {
            InitializeComponent();

            SetPosition();
        }

        public SelectSettingWindow(string caption, string message, Visibility acceptButtonVisibility, Visibility cancelButtonVisibility)
        {
            InitializeComponent();

            Title = caption;
            SettingTitle = message;
            AcceptButton.Visibility = acceptButtonVisibility;
            CancelButton.Visibility = cancelButtonVisibility;

            ReArrangeButtonPosition();

            SetPosition();
        }

        public SelectSettingWindow(string caption, string message) : this(caption, message, Visibility.Visible, Visibility.Visible) { }


        public object AcceptButtonContent
        {
            get
            {
                return AcceptButton.Content;
            }
            set
            {
                AcceptButton.Content = value;
            }
        }

        public object CancelButtonContent
        {
            get
            {
                return CancelButton.Content;
            }
            set
            {
                CancelButton.Content = value;
            }
        }

        public SelectSettingWindow(Templete templeteType)
        {
            InitializeComponent();

            TempleteType = templeteType;

            SetPosition();
        }

        public SelectSettingWindow(SelectSettingWindow sourceObject)
        {
            InitializeComponent();

            Title = sourceObject.Title;

            SettingTitle = sourceObject.SettingTitle;

            Settings = sourceObject.Settings;

            SelectedIndex = sourceObject.SelectedIndex;

            if (sourceObject.ModelInformations != null)
            {
                ModelInformations = sourceObject.ModelInformations;
            }

            if (sourceObject.InterfaceInformations != null)
            {
                InterfaceInformations = sourceObject.InterfaceInformations;
            }

            if (sourceObject.Languages != null)
            {
                Languages = sourceObject.Languages;
            }

            if (sourceObject.PaperSizeCollection != null)
            {
                PaperSizeCollection = sourceObject.PaperSizeCollection;
            }

            CheckRadioButton(selectedIndex);

            SetPosition();
        }

        public enum Templete
        {
            BlackMarkType,
            PaperSize
        }

        public Templete TempleteType
        {
            get
            {
                return templete;
            }
            set
            {
                templete = value;

                SetTemplete();
            }
        }

        public Templete templete;

        private void SetTemplete()
        {
            switch (TempleteType)
            {
                default:
                case Templete.BlackMarkType:
                    SettingTitle = "Select black mark type.";
                    BlackMarkTypeCollection = (BlackMarkType[])Enum.GetValues(typeof(BlackMarkType));

                    break;

                case Templete.PaperSize:
                    SettingTitle = "Select paper size.";

                    List<PaperSize> paperSizeList = new List<PaperSize>();

                    foreach(PaperSizeType type in (PaperSizeType[])Enum.GetValues(typeof(PaperSizeType)))
                    {
                        if(type != PaperSizeType.Unknown)
                        {
                            paperSizeList.Add(new PaperSize(type));
                        }
                    }
                    
                    PaperSizeCollection = paperSizeList.ToArray();

                    break;
            }

            SelectedIndex = 0;
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

        internal ModelInformation[] ModelInformations
        {
            get
            {
                return modelInformationArray;
            }
            set
            {
                modelInformationArray = new ModelInformation[value.Length];

                Array.Copy(value, 0, modelInformationArray, 0, modelInformationArray.Length);

                ModelInformationToString();

                SetSettings();
            }
        }

        internal ModelInformation SelectedModel
        {
            get
            {
                return modelInformationArray[SelectedIndex];
            }
        }

        public InterfaceInformation[] InterfaceInformations
        {
            get
            {
                return interfaceInformationArray;
            }
            set
            {
                interfaceInformationArray = new InterfaceInformation[value.Length];

                Array.Copy(value, 0, interfaceInformationArray, 0, interfaceInformationArray.Length);

                InterfaceInformationToString();

                SetSettings();
            }
        }

        public InterfaceInformation SelecedInterfaceType
        {
            get
            {
                return interfaceInformationArray[SelectedIndex];
            }
        }

        public Language[] Languages
        {
            get
            {
                return languageArray;
            }
            set
            {
                languageArray = new Language[value.Length];

                Array.Copy(value, 0, languageArray, 0, languageArray.Length);

                LanguageToString();

                SetSettings();
            }
        }

        public Language SelectedLanguage
        {
            get
            {
                return languageArray[SelectedIndex];
            }
        }

        public PaperSize[] PaperSizeCollection
        {
            get
            {
                return paperSizeArray;
            }
            set
            {
                paperSizeArray = new PaperSize[value.Length];

                Array.Copy(value, 0, paperSizeArray, 0, paperSizeArray.Length);

                PaperSizeToString();

                SetSettings();
            }
        }

        public PaperSize SelectedPaperSize
        {
            get
            {
                return paperSizeArray[SelectedIndex];
            }
        }

        public BlackMarkType[] BlackMarkTypeCollection
        {
            get
            {
                return blackMarkTypeCollection;
            }
            set
            {
                blackMarkTypeCollection = new BlackMarkType[value.Length];

                Array.Copy(value, 0, blackMarkTypeCollection, 0, blackMarkTypeCollection.Length);

                BlackMarkTypeToString();

                SetSettings();
            }
        }

        private BlackMarkType[] blackMarkTypeCollection;

        public BlackMarkType SelectedBlackMarkType
        {
            get
            {
                return blackMarkTypeCollection[SelectedIndex];
            }
        }

        public DisplayFunctionManager DisplayFunction
        {
            get
            {
                return displayFunction;
            }
            set
            {
                displayFunction = value;

                SettingTitle = displayFunction.SelectPatternWindowTitle;

                DisplayFunctionToString();

                SetSettings();
            }
        }

        private DisplayFunctionManager displayFunction;

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;

                CheckRadioButton(value);
            }
        }

        public DisplayFunctionManager.TextPattern SelectedDisplayTextPattern
        {
            get
            {
                return (DisplayFunctionManager.TextPattern)Enum.ToObject(typeof(DisplayFunctionManager.TextPattern), selectedIndex);
            }
        }

        public DisplayFunctionManager.GraphicPattern SelectedDisplayGraphicPattern
        {
            get
            {
                return (DisplayFunctionManager.GraphicPattern)Enum.ToObject(typeof(DisplayFunctionManager.GraphicPattern), selectedIndex);
            }
        }

        public bool SelectedDisplayTurnOnOffPattern
        {
            get
            {
                if (selectedIndex == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DisplayCursorMode SelectedDisplayCursorPattern
        {
            get
            {
                return (DisplayCursorMode)Enum.ToObject(typeof(DisplayCursorMode), selectedIndex);
            }
        }

        public DisplayContrastMode SelectedDisplayContrastPattern
        {
            get
            {
                return (DisplayContrastMode)Enum.ToObject(typeof(DisplayContrastMode), selectedIndex);
            }
        }

        public DisplayInternationalType SelectedDisplayCharacterSetInternationalType
        {
            get
            {
                return (DisplayInternationalType)Enum.ToObject(typeof(DisplayInternationalType), selectedIndex);
            }
        }

        public DisplayCodePageType SelectedDisplayCharacterSetCodePageType
        {
            get
            {
                return (DisplayCodePageType)Enum.ToObject(typeof(DisplayCodePageType), selectedIndex);
            }
        }

        public DisplayFunctionManager.UserDefinedCharacterPattern SelectedDisplayUserDefinedCharacterPattern
        {
            get
            {
                return (DisplayFunctionManager.UserDefinedCharacterPattern)Enum.ToObject(typeof(DisplayFunctionManager.UserDefinedCharacterPattern), selectedIndex);
            }
        }

        private List<RadioButton> settingRadioButtonList;

        private string[] settingsArray;

        private ModelInformation[] modelInformationArray;

        private InterfaceInformation[] interfaceInformationArray;

        private Language[] languageArray;

        private PaperSize[] paperSizeArray;

        private int selectedIndex;

        private void SetPosition()
        {
            MainWindow mainWindow = Util.GetMainWindow();

            if (mainWindow.ActualHeight != 0)
            {
                Owner = mainWindow;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
        }

        private void ReArrangeButtonPosition()
        {
            if (AcceptButton.Visibility == Visibility.Visible && CancelButton.Visibility == Visibility.Collapsed)
            {
                AcceptButton.SetValue(Grid.ColumnProperty, 2);
            }
        }

        private void SetSettings()
        {
            settingRadioButtonList = new List<RadioButton>();

            ContainerStackPanel.Children.RemoveRange(0, ContainerStackPanel.Children.Count);

            int index = 0;

            foreach (string setting in settingsArray)
            {
                RadioButton settingRadioButton = new RadioButton();
                settingRadioButton.Content = setting;
                settingRadioButton.FontSize = 15;
                settingRadioButton.Margin = new Thickness(0, 0, 0, 10);
                settingRadioButton.Tag = index;
                settingRadioButton.Checked += RadioButton_Check;

                ContainerStackPanel.Children.Add(settingRadioButton);

                settingRadioButtonList.Add(settingRadioButton);

                index++;
            }
        }

        private void ModelInformationToString()
        {
            settingsArray = new string[modelInformationArray.Length];

            for (int i = 0; i < settingsArray.Length; i++)
            {
                settingsArray[i] = modelInformationArray[i].SimpleModelName;
            }
        }

        private void InterfaceInformationToString()
        {
            settingsArray = new string[interfaceInformationArray.Length];

            for (int i = 0; i < settingsArray.Length; i++)
            {
                settingsArray[i] = interfaceInformationArray[i].Description;
            }
        }

        private void LanguageToString()
        {
            settingsArray = new string[languageArray.Length];

            for (int i = 0; i < settingsArray.Length; i++)
            {
                settingsArray[i] = languageArray[i].Description;
            }
        }

        private void PaperSizeToString()
        {
            settingsArray = new string[paperSizeArray.Length];

            for (int i = 0; i < settingsArray.Length; i++)
            {
                settingsArray[i] = paperSizeArray[i].Description;
            }
        }

        private void BlackMarkTypeToString()
        {
            settingsArray = new string[blackMarkTypeCollection.Length];

            for (int i = 0; i < settingsArray.Length; i++)
            {
                settingsArray[i] = GetBlackMarkTypeDescription(blackMarkTypeCollection[i]);
            }
        }

        private string GetBlackMarkTypeDescription(BlackMarkType type)
        {
            string description = "";

            switch (type)
            {
                default:
                case BlackMarkType.Invalid:
                    description = "Invalid";
                    break;

                case BlackMarkType.Valid:
                    description = "Valid";
                    break;

                case BlackMarkType.ValidWithDetection:
                    description = "Valid With Detection";
                    break;
            }

            return description;
        }

        private void DisplayFunctionToString()
        {
            settingsArray = displayFunction.Patterns;
        }

        private void CheckRadioButton(int index)
        {
            RadioButton settingRadioButton = settingRadioButtonList[index];

            settingRadioButton.IsChecked = true;
        }

        private void RadioButton_Check(object sender, RoutedEventArgs e)
        {
            RadioButton checkedRadioButton = (RadioButton)sender;

            selectedIndex = (int)checkedRadioButton.Tag;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
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
