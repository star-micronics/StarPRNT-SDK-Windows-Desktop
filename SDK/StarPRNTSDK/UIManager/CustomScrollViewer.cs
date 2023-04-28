using System.Windows.Controls;
using System.Windows.Input;

namespace StarPRNTSDK
{
    public class CustomScrollViewer : ScrollViewer
    {
        public CustomScrollViewer()
        {
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            ScrollToVerticalOffset(VerticalOffset - e.Delta);
        }
    }
}
