using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StarPRNTSDK
{
    public class InputLimitedTextBox : TextBox
    {
        public InputLimitedTextBox()
        {
            DataObject.AddPastingHandler(this, OnPaste);

            AllowDoubleByteCharacter = true;

            FilterPattern = null;
        }

        public bool AllowDoubleByteCharacter { get; set; }

        public string FilterPattern { get; set; }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            List<char> regectedCharacterList = new List<char>();

            var isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
            if (!isText) return;

            string pastedText = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;

            for (int i = 0; i < pastedText.Length; i++)
            {
                char target = pastedText[i];

                if (!AllowDoubleByteCharacter && IsDoubleByteCharacter(target))
                {
                    regectedCharacterList.Add(target);

                    continue;
                }

                string previousText = Text;

                string textInTextBox = AppendTextAtSelectedLocation(target.ToString());

                if (previousText.Equals(textInTextBox))
                {
                    continue;
                }

                if (SelectionLength != 0)
                {
                    CaretIndex = SelectionStart;
                }

                int previousCaretIndex = CaretIndex;

                if (IsNeedUpdateText(textInTextBox))
                {
                    Text = textInTextBox;
                    CaretIndex = previousCaretIndex + 1;
                }
                else
                {
                    regectedCharacterList.Add(target);
                }
            }

            e.CancelCommand();
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            List<char> regectedCharacterList = new List<char>();

            string inputText = e.Text;

            if (!AllowDoubleByteCharacter)
            {
                char[] deletedCharacters = new char[] { };

                inputText = DeleteDoubleByteCharacters(inputText, ref deletedCharacters);

                regectedCharacterList.AddRange(deletedCharacters);
            }

            string textInTextBox = AppendTextAtSelectedLocation(inputText);

            bool isNeedUpdate = IsNeedUpdateText(textInTextBox);

            if (!isNeedUpdate)
            {
                regectedCharacterList.AddRange(inputText);
            }

            e.Handled = !isNeedUpdate;
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                string textInTextBox = AppendTextAtSelectedLocation(" ");

                e.Handled = !IsNeedUpdateText(textInTextBox);
            }
        }

        private string DeleteDoubleByteCharacters(string inputText, ref char[] deletedCharacters)
        {
            List<char> deletedCharacterList = new List<char>();

            StringBuilder builder = new StringBuilder();

            foreach (char textInTextBoxCharacter in inputText)
            {
                if (!IsDoubleByteCharacter(textInTextBoxCharacter))
                {
                    builder.Append(textInTextBoxCharacter);
                }
                else
                {
                    deletedCharacterList.Add(textInTextBoxCharacter);
                }
            }

            deletedCharacters = deletedCharacterList.ToArray();

            return builder.ToString();
        }

        private bool IsDoubleByteCharacter(char target)
        {
            return (Encoding.GetEncoding("Shift_JIS").GetByteCount(target.ToString()) % 2 == 0);
        }

        private string AppendTextAtSelectedLocation(string inputText)
        {
            if (Text.Length == MaxLength)
            {
                return Text;
            }

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

        private bool IsNeedUpdateText(string updatedText)
        {
            string filteredText = GetFilteredText(updatedText);

            bool isNeedUpdate;

            if (!filteredText.Equals(updatedText))
            {
                isNeedUpdate = false;
            }
            else
            {
                isNeedUpdate = true;
            }

            return isNeedUpdate;
        }

        private string GetFilteredText(string inputText)
        {
            if (FilterPattern != null)
            {
                if (!Regex.IsMatch(inputText, FilterPattern))
                {
                    return Text;
                }
            }

            return inputText;
        }
    }
}
