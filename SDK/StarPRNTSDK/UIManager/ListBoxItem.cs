using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace StarPRNTSDK
{
    public class BaseListBoxItem : DependencyObject, INotifyPropertyChanged
    {
        public BaseListBoxItem()
        {
            Visibility = Visibility.Visible;

            SetForeGroundColor();

            backGroudColor = new SolidColorBrush(Colors.White);

            ArrowVisibility = Visibility.Visible;

            DependencyPropertyDescriptor descripter = DependencyPropertyDescriptor.FromProperty(IsAnimationProperty, typeof(BaseListBoxItem));

            descripter.AddValueChanged(this, OnIsAnimationPropertyChanged);
        }

        public static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility", typeof(Visibility), typeof(BaseListBoxItem));
        public Visibility Visibility
        {
            get
            {
                return (Visibility)GetValue(VisibilityProperty);
            }
            set
            {
                SetValue(VisibilityProperty, value);
            }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BaseListBoxItem));
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public Brush ForeGroundColor
        {
            get
            {
                return foreGroundColor;
            }
            set
            {
                foreGroundColor = value;

                defaultForeGroundColor = value;
            }
        }

        private Brush foreGroundColor;

        private Brush defaultForeGroundColor;

        public Brush BackGroudColor
        {
            get
            {
                return backGroudColor;
            }
            set
            {
                backGroudColor = value;
            }
        }

        public Brush backGroudColor;


        public static readonly DependencyProperty IsAnimationProperty = DependencyProperty.Register("IsAnimation", typeof(bool), typeof(BaseListBoxItem));

        public bool IsAnimation
        {
            get
            {
                return (bool)GetValue(IsAnimationProperty);
            }
            set
            {
                SetValue(IsAnimationProperty, value);
            }
        }

        private void OnIsAnimationPropertyChanged(object sender, EventArgs e)
        {
            SetForeGroundColor();

            OnPropertyChanged("ForeGroundColor");
        }

        public BaseCommand ListBoxItemTouchedCommand
        {
            get
            {
                return listBoxItemTouchedCommand;
            }
            set
            {
                if (value != null)
                {
                    listBoxItemTouchedCommand = value;

                    listBoxItemTouchedCommand.ExuecutableChangedEvent += OnListBoxItemTouchedCommandExecutableChanged;

                    SetForeGroundColor();
                }
            }
        }

        private BaseCommand listBoxItemTouchedCommand;

        private void OnListBoxItemTouchedCommandExecutableChanged(object sender, EventArgs e)
        {
            SetForeGroundColor();

            OnPropertyChanged("ForeGroundColor");
        }

        public Visibility ArrowVisibility { set; get; }

        public Brush BorderBlushColor { get; set; }

        public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(BaseListBoxItem));

        public object Tag
        {
            get
            {
                return GetValue(TagProperty);
            }
            set
            {
                SetValue(TagProperty, value);
            }
        }

        private void SetForeGroundColor()
        {
            if (ListBoxItemTouchedCommand != null)
            {
                if (!ListBoxItemTouchedCommand.CanExecute(null))
                {
                    foreGroundColor = new SolidColorBrush(Colors.LightGray);

                    return;
                }
            }

            if (IsAnimation)
            {
                foreGroundColor = new SolidColorBrush(Colors.Red);

                return;
            }

            foreGroundColor = defaultForeGroundColor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class ListBoxItemWithControl : BaseListBoxItem
    {
        public event EventHandler ContentChangedEvent;

        protected void OnContentChanged()
        {
            EventHandler handler = ContentChangedEvent;
            if (handler != null)
            {
                handler(null, null);
            }
        }

        public ListBoxItemWithControl() : base()
        {
            ControlIsEnabled = true;
        }

        public bool ControlIsEnabled
        {
            get
            {
                return controlIsEnabled;
            }
            set
            {
                controlIsEnabled = value;

                SetDisableMessage(value);

                OnPropertyChanged("ControlIsEnabled");
            }
        }
        protected bool controlIsEnabled;

        public string ControlDisabledMessage { get; set; }

        protected virtual void SetDisableMessage(bool isEnabled) { }
    }


    public class ListBoxItemCheckBox : CheckBox
    {
        private ListBoxItemWithCheckBox ParentListBoxItem
        {
            get
            {
                BindingExpression bindingExpresson = GetBindingExpression(ContentProperty);
                return (ListBoxItemWithCheckBox)bindingExpresson.DataItem;
            }
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);

            CallSetCheckBoxContent();

            OnCheckBoxCheckedChanged();
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnUnchecked(e);

            CallSetCheckBoxContent();

            OnCheckBoxCheckedChanged();
        }

        private void CallSetCheckBoxContent()
        {
            ParentListBoxItem.SetCheckBoxContent();
        }

        private void OnCheckBoxCheckedChanged()
        {
            EventHandler handler = ParentListBoxItem.GetCheckBoxCheckedChangedEvent();
            if (handler != null)
            {
                handler(ParentListBoxItem, null);
            }
        }
    }

    public class ListBoxItemWithCheckBox : ListBoxItemWithControl
    {
        public event EventHandler CheckBoxCheckedChangedEvent;

        public ListBoxItemWithCheckBox() : base()
        {
            SetCheckBoxContent();
        }

        public static readonly DependencyProperty CheckBoxIsCheckedProperty = DependencyProperty.Register("CheckBoxIsChecked", typeof(bool), typeof(BaseListBoxItem));

        public bool CheckBoxIsChecked
        {
            get
            {
                return (bool)GetValue(CheckBoxIsCheckedProperty);
            }
            set
            {
                SetValue(CheckBoxIsCheckedProperty, value);

                OnPropertyChanged("CheckBoxIsChecked");

                OnContentChanged();
            }
        }

        public string CheckBoxContent
        {
            get
            {
                return checkBoxContent;
            }
            set
            {
                checkBoxContent = value;

                OnPropertyChanged("CheckBoxContent");

                OnContentChanged();
            }
        }
        private string checkBoxContent;

        protected override void SetDisableMessage(bool isEnabled)
        {
            if (ControlDisabledMessage == null)
            {
                return;
            }

            SetCheckBoxContent();
        }

        public void SetCheckBoxContent()
        {
            if (!ControlIsEnabled)
            {
                CheckBoxContent = ControlDisabledMessage;

                return;
            }

            if (CheckBoxIsChecked)
            {
                CheckBoxContent = "ON ";
            }
            else
            {
                CheckBoxContent = "OFF";
            }
        }

        public EventHandler GetCheckBoxCheckedChangedEvent()
        {
            return CheckBoxCheckedChangedEvent;
        }
    }

    public class ListBoxItemTextBox : TextBox
    {
        private ListBoxItemWithTextBox ParentListBoxItem
        {
            get
            {
                BindingExpression bindingExpresson = GetBindingExpression(TextProperty);
                return (ListBoxItemWithTextBox)bindingExpresson.DataItem;
            }
        }

        public ListBoxItemTextBox()
        {
            DataObject.AddPastingHandler(this, OnPaste);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
            if (!isText) return;

            string pastedText = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;

            for (int i = 0; i < pastedText.Length; i++)
            {
                char target = pastedText[i];

                if (IsDoubleByteChar(target))
                {
                    continue;
                }

                string textInTextBox = AppendTextForCheck(target.ToString());

                if (SelectionLength != 0)
                {
                    CaretIndex = SelectionStart;
                }

                int previousCaretIndex = CaretIndex;
                if (CanUpdateText(textInTextBox))
                {
                    Text = textInTextBox;
                    CaretIndex = previousCaretIndex + 1;
                }
            }

            e.CancelCommand();
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            DeleteDoubleByteChars();

            string textInTextBox = AppendTextForCheck(e.Text);

            e.Handled = !CanUpdateText(textInTextBox);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                string textInTextBox = AppendTextForCheck(" ");

                e.Handled = !CanUpdateText(textInTextBox);
            }
        }

        private void DeleteDoubleByteChars()
        {
            int previousCaretIndex = CaretIndex;

            int deleteCount = 0;
            StringBuilder builder = new StringBuilder();
            foreach (char textInTextBoxChar in Text.ToCharArray())
            {
                if (!IsDoubleByteChar(textInTextBoxChar))
                {
                    builder.Append(textInTextBoxChar);
                }
                else
                {
                    deleteCount++;
                }
            }

            Text = ParentListBoxItem.GetFilteredText(builder.ToString());

            CaretIndex = previousCaretIndex - deleteCount;
        }

        private bool IsDoubleByteChar(char target)
        {
            return (Encoding.GetEncoding("Shift_JIS").GetByteCount(target.ToString()) % 2 == 0);
        }

        private string AppendTextForCheck(string inputText)
        {
            string textInTextBox;

            if (SelectionLength != 0)
            {
                int selectionEnd = SelectionStart + SelectionLength;

                textInTextBox = Text.Substring(0, SelectionStart) + inputText + Text.Substring(selectionEnd, (Text.Length - selectionEnd));
            }
            else
            {
                if (CaretIndex == 0)
                {
                    textInTextBox = inputText + Text;
                }
                else if (CaretIndex == Text.Length)
                {
                    textInTextBox = Text + inputText;
                }
                else
                {
                    textInTextBox = Text.Substring(0, CaretIndex) + inputText + Text.Substring(CaretIndex, (Text.Length - CaretIndex));
                }
            }

            return textInTextBox;
        }

        private bool CanUpdateText(string updatedText)
        {
            string filteredText = ParentListBoxItem.GetFilteredText(updatedText);

            bool isUpdate;
            if (!filteredText.Equals(updatedText))
            {
                isUpdate = false;
            }
            else
            {
                isUpdate = true;
            }

            return isUpdate;
        }
    }

    public class ListBoxItemWithTextBox : ListBoxItemWithControl
    {
        public ListBoxItemWithTextBox() : base()
        {
            Filter = "";
            MaxTextLength = -1;
        }

        public string TextBoxText
        {
            get
            {
                return textBoxText;
            }
            set
            {
                textBoxText = GetFilteredText(value);

                OnPropertyChanged("TextBoxText");

                OnContentChanged();
            }
        }
        private string textBoxText;

        public string GetFilteredText(string text)
        {
            if (text.Equals(ControlDisabledMessage) || text.Equals(""))
            {
                return text;
            }

            if (MaxTextLength != -1 && text.Length > MaxTextLength)
            {
                text = text.Substring(0, MaxTextLength);
            }

            if (!Filter.Equals(""))
            {
                if (!Regex.IsMatch(text, Filter))
                {
                    return textBoxText;
                }
            }

            return text;
        }


        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;

                OnPropertyChanged("Filter");
            }
        }
        private string filter;

        public int MaxTextLength
        {
            get
            {
                return maxTextLength;
            }
            set
            {
                maxTextLength = value;

                OnPropertyChanged("MaxTextLength");
            }
        }
        private int maxTextLength;

        public InputMethodState TextBoxPreferredImeState { get; private set; }

        public ImeConversionModeValues TextBoxPreferredImeConversionMode
        {
            get
            {
                return textBoxPreferredImeConversionMode;
            }
            set
            {
                textBoxPreferredImeConversionMode = value;
                TextBoxPreferredImeState = InputMethodState.On;
            }
        }
        private ImeConversionModeValues textBoxPreferredImeConversionMode;

        protected override void SetDisableMessage(bool isEnabled)
        {
            if (ControlDisabledMessage == null)
            {
                return;
            }

            if (isEnabled)
            {
                TextBoxText = "";
            }
            else
            {
                TextBoxText = ControlDisabledMessage;
            }
        }
    }

    public class ListBoxItemWithComboBox : ListBoxItemWithControl
    {
        public ListBoxItemWithComboBox() : base() { }

        public string[] ComboBoxContents
        {
            get
            {
                return comboBoxContents;
            }
            set
            {
                comboBoxContents = new string[value.Length];

                Array.Copy(value, 0, comboBoxContents, 0, comboBoxContents.Length);

                OnPropertyChanged("ComboBoxContents");

                OnContentChanged();
            }
        }
        public string[] comboBoxContents;

        public int SelectedIndex
        {
            get
            {
                if (selectedIndex == -1)
                {
                    SelectedIndex = 0;
                }

                return selectedIndex;
            }
            set
            {
                selectedIndex = value;

                OnPropertyChanged("SelectedIndex");

                OnContentChanged();
            }
        }
        private int selectedIndex;

        private bool isAddDisabledMessage;

        protected override void SetDisableMessage(bool isEnabled)
        {
            if (ControlDisabledMessage == null)
            {
                return;
            }

            List<string> comboBoxContentsList = new List<string>();

            foreach (string content in ComboBoxContents)
            {
                comboBoxContentsList.Add(content);
            }

            if (isEnabled && isAddDisabledMessage)
            {
                comboBoxContentsList.RemoveAt(comboBoxContentsList.Count - 1);

                isAddDisabledMessage = false;
            }

            if (!isEnabled && !isAddDisabledMessage)
            {
                comboBoxContentsList.Add(ControlDisabledMessage);

                SelectedIndex = comboBoxContentsList.Count - 1;

                isAddDisabledMessage = true;
            }

            ComboBoxContents = comboBoxContentsList.ToArray();
        }

        public BluetoothSecurityTypeManager[] BluetoothSecurities
        {
            get
            {
                return bluetoothSecurities;
            }
            set
            {
                bluetoothSecurities = new BluetoothSecurityTypeManager[value.Length];

                Array.Copy(value, 0, bluetoothSecurities, 0, bluetoothSecurities.Length);

                BluetoothSecuritiesToString();
            }

        }
        private BluetoothSecurityTypeManager[] bluetoothSecurities;

        public StarBluetoothManager.StarBluetoothSecurity SelectedBluetoothSecurity
        {
            get
            {
                if (bluetoothSecurities.Length < SelectedIndex + 1)
                {
                    return StarBluetoothManager.StarBluetoothSecurity.DISABLE;
                }
                else
                {
                    return bluetoothSecurities[SelectedIndex].Type;
                }
            }
            set
            {
                SelectedIndex = GetBluetoothSecurityIndex(value);
            }
        }

        private void BluetoothSecuritiesToString()
        {
            List<string> descriptions = new List<string>();

            foreach (BluetoothSecurityTypeManager security in bluetoothSecurities)
            {
                descriptions.Add(security.Description);
            }

            ComboBoxContents = descriptions.ToArray();
        }

        private int GetBluetoothSecurityIndex(StarBluetoothManager.StarBluetoothSecurity securityType)
        {
            int index = 0;

            foreach (BluetoothSecurityTypeManager security in bluetoothSecurities)
            {
                if (security.Type == securityType)
                {
                    return index;
                }

                index++;
            }

            return 0;
        }
    }

    public class ListBoxItemWithDetail : BaseListBoxItem
    {
        public ListBoxItemWithDetail(string title, string detail) : base()
        {
            Title = title;
            Detail = detail;
        }

        public ListBoxItemWithDetail(string title) : this(title, "") { }

        public ListBoxItemWithDetail() : this("", "") { }

        public string Detail { get; set; }
    }

    public class BaseCommand : DependencyObject, ICommand, INotifyPropertyChanged
    {
        public BaseCommand()
        {
            DependencyPropertyDescriptor descripter = DependencyPropertyDescriptor.FromProperty(ExecutableProperty, typeof(BaseListBoxItem));

            descripter.AddValueChanged(this, OnExecutablePropertyChanged);
        }

        public static readonly DependencyProperty ExecutableProperty = DependencyProperty.Register("Executable", typeof(bool), typeof(BaseCommand));

        public bool Executable
        {
            get
            {
                return (bool)GetValue(ExecutableProperty);
            }
            set
            {
                SetValue(ExecutableProperty, value);
            }
        }

        public virtual void Execute(object parameter) // Implemented in a derived class
        {
        }

        public bool CanExecute(object parameter)
        {
            return Executable;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event EventHandler ExuecutableChangedEvent;

        protected virtual void OnExecutableChanged(EventArgs e)
        {
            EventHandler handler = ExuecutableChangedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnExecutablePropertyChanged(object sender, EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();

            OnExecutableChanged(null);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class GoSearchPortPageCommand : BaseCommand
    {
        public int PrinterPriority { get; set; }

        public Uri SourceUri { get; set; }

        public GoSearchPortPageCommand() : base()
        {
            PrinterPriority = 0;

            SourceUri = null;
        }

        public override void Execute(object parameter)
        {
            SearchPortSamplePage searchPortPage = new SearchPortSamplePage();
            searchPortPage.PrinterPriority = PrinterPriority;
            searchPortPage.SourceUri = SourceUri;

            Util.GetMainWindow().NavigationService.Navigate(searchPortPage);
        }
    }

    public class GoNextPageCommand : BaseCommand
    {
        public Uri NavigationUri { get; set; }

        public override void Execute(object parameter)
        {
            Util.GoNextPage(NavigationUri);
        }
    }

    public class GoNextPageCommandWithSelectSetting : GoNextPageCommand
    {
        public SelectSettingWindow SelectLanguageWindow { get; set; }

        public GoNextPageCommandWithSelectSetting() { }

        public override void Execute(object parameter)
        {
            if (!ShowSelectLanguageWindowIfNeed())
            {
                return;
            }

            base.Execute(parameter);
        }

        private bool ShowSelectLanguageWindowIfNeed()
        {
            if (SelectLanguageWindow != null)
            {
                Language selectedLanguage = ShowSelectLanguageWindow();

                if (selectedLanguage.Type == LanguageType.Unknown)
                {
                    return false;
                }
                else
                {
                    SharedInformationManager.SelectedLanguage = selectedLanguage;
                }
            }

            return true;
        }

        private Language ShowSelectLanguageWindow()
        {
            Language language = new Language();

            SelectSettingWindow selectLanguageWindow = new SelectSettingWindow(SelectLanguageWindow);

            bool result = (bool)selectLanguageWindow.ShowDialog();

            if (result)
            {
                language = selectLanguageWindow.SelectedLanguage;
            }

            return language;
        }
    }

    public class GoNextPageWithSetReceiptTypeCommand : GoNextPageCommand
    {
        public ReceiptInformationManager.ReceiptType ReceiptType { get; set; }

        public override void Execute(object parameter)
        {
            SharedInformationManager.ReceiptInformationManager.Type = ReceiptType;

            base.Execute(parameter);
        }
    }

    public class GoNextPageWithSetCashDrawerOpenParameter : GoNextPageCommand
    {
        public PeripheralChannel Channel { get; set; }

        public bool CheckCondition { get; set; }

        public override void Execute(object parameter)
        {
            SharedInformationManager.PeripheralChannel = Channel;

            SharedInformationManager.CheckCondition = CheckCondition;

            base.Execute(parameter);
        }
    }
}
