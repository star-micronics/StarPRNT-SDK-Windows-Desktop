using System.Windows;

namespace StarPRNTSDK
{
    public partial class App : Application
    {
        public App()
        {
            SharedInformationManager.SelectedModelManager = new SelectedModelManager();

            SharedInformationManager.ReceiptInformationManager = new ReceiptInformationManager();

            SharedInformationManager.DisplayFunctionManager = new DisplayFunctionManager();

            SharedInformationManager.RestorePreviousInfo();
        }
    }
}
