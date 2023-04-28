using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Printing;

namespace StarPRNTSDK
{
    public static class PrinterDriverManager
    {
        public static void PrintViaPrinterDriver(PrintQueue printQueue, string text, Font font)
        {
            ShowPrinterQueueJob(printQueue);

            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = printQueue.Name;
                printDocument.PrintPage += (sender, e) =>
                {
                    float fontSizeForPrinterDriver = 7 * font.Size / 15;
                    Font printFont = new Font(font.FontFamily, fontSizeForPrinterDriver);

                    float yPos = 0;
                    int count = 0;
                    float leftMargin = 0;
                    float topMargin = 0;

                    string[] lines = text.Split('\n');
                    foreach (string line in lines)
                    {
                        yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                        e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                        count++;
                    }

                    e.HasMorePages = false;
                };

                printDocument.Print();
            }
            catch (Exception)
            {
            }
        }

        public static void ShowPrinterQueueJob(PrintQueue printQueue)
        {
            Process process = Process.Start("rundll32.exe", "printui.dll,PrintUIEntry /o /n \"" + printQueue.Name + "\"");
        }
    }
}
