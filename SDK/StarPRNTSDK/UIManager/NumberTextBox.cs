using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StarPRNTSDK
{
    public class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            DataObject.AddPastingHandler(this, OnPaste);

            Lower = int.MinValue;

            Upper = int.MaxValue;
        }

        public int Value
        {
            get
            {
                int value = 0;

                try
                {
                    value = Int32.Parse(Text);
                }
                catch (Exception)
                {
                    value = -1;
                }

                return value;
            }
        }

        public int Lower { get; set; }

        public int Upper { get; set; }

        private bool IsAcceptableText(string text)
        {
            bool isAcceptable = false;

            try
            {
                int value = Int32.Parse(text);

                isAcceptable = Util.IsRange(value, Lower, Upper);
            }
            catch (Exception) { }

            return isAcceptable;
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !IsAcceptableText(e.Text);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (Text.Length == 0)
            {
                var isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
                if (!isText) return;

                string pastedText = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;

                if (!IsAcceptableText(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
