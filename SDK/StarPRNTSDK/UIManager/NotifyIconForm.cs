using System.Windows.Forms;

namespace StarPRNTSDK
{
    public partial class NotifyIconForm : Form
    {
        public NotifyIconForm()
        {
            InitializeComponent();
        }

        public void ShowNotify(string caption, string message, ToolTipIcon icon)
        {
            notifyIcon.ShowBalloonTip(3000, caption, message, icon);

            notifyIcon.Visible = true;
        }
    }
}
