using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Manager
{
    internal abstract class KaiEventLoggerBase : IKaiEventLogger
    {
        private List<string> Messages { get; } = new List<string>();

        private bool includeMessageCounter;
        public bool IncludeMessageCounter { get => includeMessageCounter; set => includeMessageCounter = value; }
        public void AddMessage(string pMessage)
        {
            string resultMessage = "> ";

            if (includeMessageCounter)
                resultMessage += "[" + (Messages.Count + 1).ToString() + "] ";

            resultMessage += pMessage;

            Messages.Add(resultMessage);
            DoClassSpecificAddMessageActions(resultMessage);
        }

        public abstract void DoClassSpecificAddMessageActions(string pMessage);
    }
}
