using System;
using System.Windows.Forms;

namespace MyKai.Manager 
{
    internal class KaiRichTextEventLogger : KaiEventLoggerBase
    {
        public RichTextBox messageRichTectBox;

        public override void DoClassSpecificAddMessageActions(string pMessage)
        {
            messageRichTectBox.Text += " " + pMessage + Environment.NewLine;

            messageRichTectBox.SelectionStart = messageRichTectBox.Text.Length;
            messageRichTectBox.ScrollToCaret();
            messageRichTectBox.Refresh();
        }
    }
}
