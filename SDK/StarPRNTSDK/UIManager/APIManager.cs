using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public class APIManager
    {
        public enum APIType
        {
            Generic,
            FontStyle,
            Initialization,
            CodePage,
            International,
            Feed,
            CharacterSpace,
            LineSpace,
            TopMargin,
            Emphasis,
            Invert,
            UnderLine,
            Multiple,
            AbsolutePosition,
            Alignment,
            HorizontalTab,
            Logo,
            CutPaper,
            Peripheral,
            Sound,
            Bitmap,
            Barcode,
            Pdf417,
            QrCode,
            BlackMark,
            PageMode,
            PrintableArea
        }

        public APIManager()
        {
        }

        public APIManager(APIType type)
        {
            Type = type;
        }

        public APIType Type { get; set; }

        public string Title
        {
            get
            {
                return GetTitle();
            }
        }

        public CallAPIClickEvent APICaller
        {
            get
            {
                return CreateAPICaller();
            }
        }

        private string GetTitle()
        {
            string title;

            switch (Type)
            {
                default:
                case APIType.Generic:
                    title = "Generic";
                    break;

                case APIType.FontStyle:
                    title = "Font Style";
                    break;

                case APIType.Initialization:
                    title = "Initialization";
                    break;

                case APIType.CodePage:
                    title = "Code Page";
                    break;

                case APIType.International:
                    title = "International";
                    break;

                case APIType.Feed:
                    title = "Feed";
                    break;

                case APIType.CharacterSpace:
                    title = "Character Space";
                    break;

                case APIType.LineSpace:
                    title = "Line Space";
                    break;

                case APIType.TopMargin:
                    title = "Top Margin";
                    break;

                case APIType.Emphasis:
                    title = "Emphasis";
                    break;

                case APIType.Invert:
                    title = "Invert";
                    break;

                case APIType.UnderLine:
                    title = "Under Line";
                    break;

                case APIType.Multiple:
                    title = "Multiple";
                    break;

                case APIType.AbsolutePosition:
                    title = "Absolute Position";
                    break;

                case APIType.Alignment:
                    title = "Alignment";
                    break;

                case APIType.HorizontalTab:
                    title = "Horizontal Tab Position";
                    break;

                case APIType.Logo:
                    title = "Logo";
                    break;

                case APIType.CutPaper:
                    title = "Cut Paper";
                    break;

                case APIType.Peripheral:
                    title = "Peripheral";
                    break;

                case APIType.Sound:
                    title = "Sound";
                    break;

                case APIType.Bitmap:
                    title = "Bitmap";
                    break;

                case APIType.Barcode:
                    title = "Barcode";
                    break;

                case APIType.Pdf417:
                    title = "PDF417";
                    break;

                case APIType.QrCode:
                    title = "QR Code";
                    break;

                case APIType.BlackMark:
                    title = "Black Mark";
                    break;

                case APIType.PageMode:
                    title = "Page Mode";
                    break;

                case APIType.PrintableArea:
                    title = "Printable Area";
                    break;
            }

            return title;
        }

        private CallAPIClickEvent CreateAPICaller()
        {
            return new CallAPIClickEvent(Type);
        }

        public BaseListBoxItem[] AllAPIListBoxItem
        {
            get
            {
                return CreateAllAPIListBoxItem();
            }
        }

        private BaseListBoxItem[] CreateAllAPIListBoxItem()
        {
            List<BaseListBoxItem> listBoxItemList = new List<BaseListBoxItem>();

            foreach (APIType type in Enum.GetValues(typeof(APIType)))
            {
                APIManager apiInfo = new APIManager(type);

                BaseListBoxItem listBoxItem = new BaseListBoxItem();

                listBoxItem.Title = apiInfo.Title;
                listBoxItem.ListBoxItemTouchedCommand = apiInfo.APICaller;

                listBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
                listBoxItem.BorderBlushColor = new SolidColorBrush(Colors.LightGray);

                listBoxItemList.Add(listBoxItem);
            }

            return listBoxItemList.ToArray();
        }
    }

    public class CallAPIClickEvent : BaseCommand
    {

        public APIManager.APIType Type { get; set; }

        public CallAPIClickEvent(APIManager.APIType type)
        {
            Type = type;
            Executable = true;
        }

        public override void Execute(object parameter)
        {
            APIFunctionManager.SendAPICommands(Type);
        }
    }
}
