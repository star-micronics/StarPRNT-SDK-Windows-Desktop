using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace StarPRNTSDK
{
    public partial class ProgressBarWindow : Window
    {
        public Action BackgroundAction { get; set; }

        public ProgressBarWindow()
        {
            InitializeComponent();

            SetPosition();
        }

        public ProgressBarWindow(string title, Action action)
        {
            InitializeComponent();

            Title = title;

            BackgroundAction = action;

            DoBackgroundAction();

            SetPosition();
        }

        public ProgressBarWindow(string title) : this(title, null) { }

        public void DoBackgroundAction()
        {
            if(BackgroundAction == null)
            {
                return;
            }

            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private void SetPosition()
        {
            MainWindow mainWindow = Util.GetMainWindow();

            if (mainWindow.ActualHeight != 0)
            {
                Owner = mainWindow;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(BackgroundAction != null) 
            {
                BackgroundAction.Invoke();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
