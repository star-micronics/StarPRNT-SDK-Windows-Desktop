using System.Windows.Media;

namespace StarPRNTSDK.UIManager
{
    public class ListBoxItemWithDetail
    {
        public ListBoxItemWithDetail(string title, string detail)
        {
            Title = title;
            Detail = detail;
        }

        public ListBoxItemWithDetail(string title) : this(title, "") { }

        public ListBoxItemWithDetail() : this("", "") { }

        public string Title { get; set; }

        public string Detail { get; set; }

        public Brush ForeGroundColor
        {
            get
            {
                return GetForeGroungColor();
            }
            set
            {
                foreGroundColor = value;
            }
        }

        private Brush foreGroundColor;

        private Brush GetForeGroungColor()
        {
            if(foreGroundColor == null)
            {
                return new SolidColorBrush(Colors.Blue);
            }
            else
            {
                return foreGroundColor;
            }
        }
    }
}
