using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace StarPRNTSDK
{
    public class DisplayFunctionManager : INotifyPropertyChanged
    {
        public enum FunctionType
        {
            CheckStatus,
            Text,
            Graphic,
            TurnOnOff,
            Cursor,
            Contrast,
            CharacterSetInternational,
            CharacterSetCodePage,
            UserDefinedCharacter,
            Invalid
        }

        public enum TextPattern
        {
            Pattern1,
            Pattern2,
            Pattern3,
            Pattern4,
            Pattern5,
            Pattern6,
        }

        public enum GraphicPattern
        {
            Pattern1,
            Pattern2
        }

        public enum UserDefinedCharacterPattern
        {
            Set,
            Reset
        }

        public DisplayFunctionManager()
        {
            if (SharedInformationManager.DisplayFunctionManager != null)
            {
                CopyProperty(SharedInformationManager.DisplayFunctionManager);
            }
            else
            {
                additionType = FunctionType.Invalid;
                SelectedInternationalType = DisplayInternationalType.USA;
                SelectedCodePageType = DisplayCodePageType.CP437;
            }

            SharedInformationManager.DisplayFunctionManager = this;
        }

        private void CopyProperty(DisplayFunctionManager source)
        {
            Type = source.Type;
            AdditionType = source.AdditionType;
        }

        public FunctionType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;

                OnPropertyChanged("Patterns");
            }
        }

        private FunctionType type;

        public FunctionType AdditionType
        {
            get
            {
                return additionType;
            }
            set
            {
                additionType = value;

                OnPropertyChanged("AdditionPatterns");

                OnPropertyChanged("AdditionPatternVisibility");

                OnPropertyChanged("GridColumnSpan");
            }
        }

        private FunctionType additionType;

        public Visibility AdditionPatternVisibility
        {
            get
            {
                return GetAddtionPatternVisibility();
            }
        }

        public string Title
        {
            get
            {
                return GetDescription(Type);
            }
        }

        public string SelectPatternWindowTitle
        {
            get
            {
                return "Select " + GetDescription(Type);
            }
        }

        public string[] Patterns
        {
            get
            {
                return GetPatterns();
            }
        }

        public string[] AdditionPatterns
        {
            get
            {
                return GetPatterns(additionType);
            }
        }

        public int DefaultPatternIndex
        {
            get
            {
                return GetDefaultPatternIndex();
            }
        }

        public int DefaultAdditionPatternIndex
        {
            get
            {
                return GetDefaultPatternIndex(additionType);
            }
        }

        public int GridColumnSpan
        {
            get
            {
                return GetGridColumnSpan();
            }
        }

        private int GetGridColumnSpan()
        {
            if (AdditionPatternVisibility == Visibility.Visible)
            {
                return 1;
            }
            else
            {
                return 3;
            }
        }

        public SelectSettingWindow SelectPatternWindow
        {
            get
            {
                if (Type == FunctionType.CheckStatus)
                {
                    return null;
                }

                selectPatternWindow = new SelectSettingWindow();
                selectPatternWindow.DisplayFunction = this;
                selectPatternWindow.SelectedIndex = 0;

                return selectPatternWindow;
            }
        }

        public DisplayInternationalType SelectedInternationalType { get; set; }

        public DisplayCodePageType SelectedCodePageType { get; set; }


        private SelectSettingWindow selectPatternWindow;

        private string[] GetPatterns(FunctionType type)
        {
            string[] patterns;

            switch (type)
            {
                default:
                    patterns = (string[])Enumerable.Empty<string>();
                    break;

                case FunctionType.Text:
                    patterns = GetTextPatterns();
                    break;

                case FunctionType.Graphic:
                    patterns = GetGraphicPatterns();
                    break;

                case FunctionType.TurnOnOff:
                    patterns = GetTurnOnOffPatterns();
                    break;

                case FunctionType.Cursor:
                    patterns = GetCursorPatterns();
                    break;

                case FunctionType.Contrast:
                    patterns = GetContrastPatterns();
                    break;

                case FunctionType.CharacterSetInternational:
                    patterns = GetCharacterSetInternationalPatterns();
                    break;

                case FunctionType.CharacterSetCodePage:
                    patterns = GetCharacterSetCodePagePatterns();
                    break;

                case FunctionType.UserDefinedCharacter:
                    patterns = GetUserDefinedCharacterPatterns();
                    break;
            }

            return patterns;
        }

        private string[] GetPatterns()
        {
            return GetPatterns(Type);
        }

        private int GetDefaultPatternIndex(FunctionType type)
        {
            int index;

            switch (Type)
            {
                default:
                    index = 0;
                    break;

                case FunctionType.Cursor:
                    index = 2;
                    break;

                case FunctionType.Contrast:
                    index = 3;
                    break;
            }

            return index;
        }

        private int GetDefaultPatternIndex()
        {
            return GetDefaultPatternIndex(Type);
        }

        private Visibility GetAddtionPatternVisibility()
        {
            if (additionType != FunctionType.Invalid)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        private string[] GetTextPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (TextPattern pattern in Enum.GetValues(typeof(TextPattern)))
            {
                patternDescriptionList.Add(GetDescription(pattern));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetGraphicPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (GraphicPattern pattern in Enum.GetValues(typeof(GraphicPattern)))
            {
                patternDescriptionList.Add(GetDescription(pattern));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetTurnOnOffPatterns()
        {
            return new string[] { "On", "Off" };
        }

        private string[] GetCursorPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (DisplayCursorMode cursorMode in Enum.GetValues(typeof(DisplayCursorMode)))
            {
                patternDescriptionList.Add(GetDescription(cursorMode));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetContrastPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (DisplayContrastMode contrastMode in Enum.GetValues(typeof(DisplayContrastMode)))
            {
                patternDescriptionList.Add(GetDescription(contrastMode));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetCharacterSetInternationalPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (DisplayInternationalType internationalType in Enum.GetValues(typeof(DisplayInternationalType)))
            {
                patternDescriptionList.Add(GetDescription(internationalType));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetCharacterSetCodePagePatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (DisplayCodePageType codePageType in Enum.GetValues(typeof(DisplayCodePageType)))
            {
                patternDescriptionList.Add(GetDescription(codePageType));
            }

            return patternDescriptionList.ToArray();
        }

        private string[] GetUserDefinedCharacterPatterns()
        {
            List<string> patternDescriptionList = new List<string>();

            foreach (UserDefinedCharacterPattern pattern in Enum.GetValues(typeof(UserDefinedCharacterPattern)))
            {
                patternDescriptionList.Add(GetDescription(pattern));
            }

            return patternDescriptionList.ToArray();
        }

        private string GetDescription(FunctionType type)
        {
            string description = "";

            switch (type)
            {
                default:
                    description = "";
                    break;

                case FunctionType.CheckStatus:
                    description = "Check Status";
                    break;

                case FunctionType.Text:
                    description = "Text";
                    break;

                case FunctionType.Graphic:
                    description = "Graphic";
                    break;

                case FunctionType.TurnOnOff:
                    description = "Back Light (Turn On / Off)";
                    break;

                case FunctionType.Cursor:
                    description = "Cursor";
                    break;

                case FunctionType.Contrast:
                    description = "Contrast";
                    break;

                case FunctionType.CharacterSetInternational:
                    description = "Character Set (International)";
                    break;

                case FunctionType.CharacterSetCodePage:
                    description = "Character Set (Code Page)";
                    break;

                case FunctionType.UserDefinedCharacter:
                    description = "User Defined Character";
                    break;
            }

            return description;
        }

        private string GetDescription(TextPattern pattern)
        {
            string description = "";

            switch (pattern)
            {
                default:
                case TextPattern.Pattern1:
                    description = "Pattern 1";
                    break;

                case TextPattern.Pattern2:
                    description = "Pattern 2";
                    break;

                case TextPattern.Pattern3:
                    description = "Pattern 3";
                    break;

                case TextPattern.Pattern4:
                    description = "Pattern 4";
                    break;

                case TextPattern.Pattern5:
                    description = "Pattern 5";
                    break;

                case TextPattern.Pattern6:
                    description = "Pattern 6";
                    break;
            }

            return description;
        }

        private string GetDescription(GraphicPattern pattern)
        {
            string description = "";

            switch (pattern)
            {
                default:
                case GraphicPattern.Pattern1:
                    description = "Pattern 1";
                    break;

                case GraphicPattern.Pattern2:
                    description = "Pattern 2";
                    break;
            }

            return description;
        }

        private string GetDescription(DisplayCursorMode cursorMode)
        {
            string description = "";

            switch (cursorMode)
            {
                default:
                case DisplayCursorMode.Off:
                    description = "Off";
                    break;

                case DisplayCursorMode.Blink:
                    description = "Blink";
                    break;

                case DisplayCursorMode.On:
                    description = "On";
                    break;
            }

            return description;
        }

        private string GetDescription(DisplayContrastMode contrastMode)
        {
            string description = "";

            switch (contrastMode)
            {
                default:
                case DisplayContrastMode.Minus3:
                    description = "Contrast -3";
                    break;

                case DisplayContrastMode.Minus2:
                    description = "Contrast -2";
                    break;

                case DisplayContrastMode.Minus1:
                    description = "Contrast -1";
                    break;

                case DisplayContrastMode.Default:
                    description = "Default";
                    break;

                case DisplayContrastMode.Plus1:
                    description = "Contrast +1";
                    break;

                case DisplayContrastMode.Plus2:
                    description = "Contrast +2";
                    break;

                case DisplayContrastMode.Plus3:
                    description = "Contrast +3";
                    break;
            }

            return description;
        }

        private string GetDescription(DisplayInternationalType internationalType)
        {
            string description = "";

            switch (internationalType)
            {
                default:
                case DisplayInternationalType.USA:
                    description = "USA";
                    break;

                case DisplayInternationalType.France:
                    description = "France";
                    break;

                case DisplayInternationalType.Germany:
                    description = "Germany";
                    break;

                case DisplayInternationalType.UK:
                    description = "UK";
                    break;

                case DisplayInternationalType.Denmark:
                    description = "Denmark";
                    break;

                case DisplayInternationalType.Sweden:
                    description = "Sweden";
                    break;

                case DisplayInternationalType.Italy:
                    description = "Italy";
                    break;

                case DisplayInternationalType.Spain:
                    description = "Spain";
                    break;

                case DisplayInternationalType.Japan:
                    description = "Japan";
                    break;

                case DisplayInternationalType.Norway:
                    description = "Norway";
                    break;

                case DisplayInternationalType.Denmark2:
                    description = "Denmark 2";
                    break;

                case DisplayInternationalType.Spain2:
                    description = "Spain 2";
                    break;

                case DisplayInternationalType.LatinAmerica:
                    description = "Latin America";
                    break;

                case DisplayInternationalType.Korea:
                    description = "Korea";
                    break;
            }

            return description;
        }

        private string GetDescription(DisplayCodePageType codePageType)
        {
            string description = "";

            switch (codePageType)
            {
                default:
                case DisplayCodePageType.CP437:
                    description = "Code Page 437";
                    break;

                case DisplayCodePageType.Katakana:
                    description = "Katakana";
                    break;

                case DisplayCodePageType.CP850:
                    description = "Code Page 850";
                    break;

                case DisplayCodePageType.CP860:
                    description = "Code Page 860";
                    break;

                case DisplayCodePageType.CP863:
                    description = "Code Page 863";
                    break;

                case DisplayCodePageType.CP865:
                    description = "Code Page 865";
                    break;

                case DisplayCodePageType.CP1252:
                    description = "Code Page 1252";
                    break;

                case DisplayCodePageType.CP866:
                    description = "Code Page 866";
                    break;

                case DisplayCodePageType.CP852:
                    description = "Code Page 852";
                    break;

                case DisplayCodePageType.CP858:
                    description = "Code Page 858";
                    break;

                case DisplayCodePageType.Japanese:
                    description = "Japanese";
                    break;

                case DisplayCodePageType.SimplifiedChinese:
                    description = "Simplified Chinese";
                    break;

                case DisplayCodePageType.TraditionalChinese:
                    description = "Traditional Chinese";
                    break;

                case DisplayCodePageType.Hangul:
                    description = "Hangul";
                    break;
            }

            return description;
        }

        private string GetDescription(UserDefinedCharacterPattern pattern)
        {
            string description = "";

            switch (pattern)
            {
                default:
                case UserDefinedCharacterPattern.Set:
                    description = "Set";
                    break;

                case UserDefinedCharacterPattern.Reset:
                    description = "Reset";
                    break;

            }

            return description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class CallDisplayFunctionClickEvent : BaseCommand
    {
        public DisplayFunctionManager Function { get; set; }

        public override void Execute(object parameter)
        {
            bool isSelected = true;
            SelectSettingWindow selectPatterWindow = Function.SelectPatternWindow;

            if (Function.SelectPatternWindow != null)
            {
                selectPatterWindow.SelectedIndex = Function.DefaultPatternIndex;

                isSelected = (bool)selectPatterWindow.ShowDialog();
            }

            if (isSelected)
            {
                Communication.PeripheralStatus result = CallFunctionWithProgressBar(selectPatterWindow);

                if (result != Communication.PeripheralStatus.Connect ||
                   Function.Type == DisplayFunctionManager.FunctionType.CheckStatus)
                {
                    Communication.ShowPeripheralStatusResultMessage("Display", result);

                    return;
                }

                Communication.ShowCommunicationResultMessage(new CommunicationResult() { Result = Communication.Result.Success, Code = StarResultCode.Succeeded });
            }
        }

        private Communication.PeripheralStatus CallFunction(SelectSettingWindow windowResult, IPort port)
        {
            Communication.PeripheralStatus result = Communication.PeripheralStatus.Invalid;

            switch (Function.Type)
            {
                default:
                case DisplayFunctionManager.FunctionType.CheckStatus:
                    result = DisplaySampleManager.GetDiaplayStatus(port);
                    break;

                case DisplayFunctionManager.FunctionType.Text:
                    result = DisplaySampleManager.DoTextPattern(windowResult.SelectedDisplayTextPattern, port);
                    break;

                case DisplayFunctionManager.FunctionType.Graphic:
                    result = DisplaySampleManager.DoGraphicPattern(windowResult.SelectedDisplayGraphicPattern, port);
                    break;

                case DisplayFunctionManager.FunctionType.TurnOnOff:
                    result = DisplaySampleManager.DoTurnOnOffPattern(windowResult.SelectedDisplayTurnOnOffPattern, port);
                    break;

                case DisplayFunctionManager.FunctionType.Cursor:
                    result = DisplaySampleManager.DoCursorPattern(windowResult.SelectedDisplayCursorPattern, port);
                    break;

                case DisplayFunctionManager.FunctionType.Contrast:
                    result = DisplaySampleManager.DoContrastPattern(windowResult.SelectedDisplayContrastPattern, port);
                    break;

                case DisplayFunctionManager.FunctionType.CharacterSetInternational:
                    DisplayInternationalType internationalType = windowResult.SelectedDisplayCharacterSetInternationalType;

                    result = DisplaySampleManager.DoCharacterSetInternationalPattern(internationalType, port);

                    SharedInformationManager.SelectedDisplayInternationalType = internationalType;
                    break;

                case DisplayFunctionManager.FunctionType.CharacterSetCodePage:
                    DisplayCodePageType codePageType = windowResult.SelectedDisplayCharacterSetCodePageType;

                    result = DisplaySampleManager.DoCharacterSetCodePagePattern(codePageType, port);

                    SharedInformationManager.SelectedDisplayCodePageType = codePageType;
                    break;

                case DisplayFunctionManager.FunctionType.UserDefinedCharacter:
                    bool set;
                    if (windowResult.SelectedDisplayUserDefinedCharacterPattern == DisplayFunctionManager.UserDefinedCharacterPattern.Set)
                    {
                        set = true;
                    }
                    else
                    {
                        set = false;
                    }

                    result = DisplaySampleManager.DoUserDefinedCharacterPattern(set, port);
                    break;
            }

            return result;
        }

        private Communication.PeripheralStatus CallFunctionWithProgressBar(SelectSettingWindow windowResult)
        {
            Communication.PeripheralStatus result = Communication.PeripheralStatus.Invalid;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = Communication.PeripheralStatus.Impossible;

                IPort port = null;

                try
                {
                    string portName = SharedInformationManager.SelectedPortName;
                    string portSettings = SharedInformationManager.SelectedPortSettings;

                    port = Factory.I.GetPort(portName, portSettings, 30000);

                    result = CallFunction(windowResult, port);
                }
                catch (PortException)
                {
                }
                finally
                {
                    if (port != null)
                    {
                        Factory.I.ReleasePort(port);
                    }
                }
            });

            progressBarWindow.ShowDialog();

            return result;
        }
    }

    public class CallDisplayExtFunctionClickEvent : BaseCommand
    {
        public DisplayFunctionManager Function { get; set; }

        public DisplayFunctionManager.FunctionType AdditionType { get; set; }

        public CallDisplayExtFunctionClickEvent()
        {
            AdditionType = DisplayFunctionManager.FunctionType.Invalid;
        }

        public override void Execute(object parameter)
        {
            SharedInformationManager.SelectedDisplayFunctionType = Function.Type;

            SharedInformationManager.SelectedAdditionDisplayFunctionType = AdditionType;
        }
    }
}
