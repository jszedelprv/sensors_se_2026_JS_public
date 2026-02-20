using Newtonsoft.Json.Linq;
using System;

namespace MyKai.Communicator
{
    public interface IKaiCommunicator
    {
        EventArgs LastEventArgs { get; set; }
        string LastEventText { get; set; }
        JObject LastUnhandledArgs { get; set; }
        int ManagerID { get; set; }

        void InformKaiEventRaised();
        void InformSpecialActionNeeded();
    }
}