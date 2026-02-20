using System;
using System.Windows.Forms;
using MyKai.General;
using MyKai.Manager;

namespace MyKai.General
{
    internal class BuilderOfRichTextBoxEventLoger : MyKaiBuilderBase<KaiRichTextEventLogger>
    {
        public BuilderOfRichTextBoxEventLoger()
        {
        }

        public BuilderOfRichTextBoxEventLoger WithRichTextBox(RichTextBox pRichTextBox)
        {
            instance.messageRichTectBox = pRichTextBox;
            
            return this;
        }

        public BuilderOfRichTextBoxEventLoger WithIncludeMessageCounter(bool pIncludeMessageCounter)
        {
            instance.IncludeMessageCounter = pIncludeMessageCounter;
            
            return this;
        }
    }
}
