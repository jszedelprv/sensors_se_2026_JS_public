using System;
using Newtonsoft.Json.Linq;

namespace MyKai.Communicator
{
    // The abstraction of KaiCommunicator to be implemented in a program (or a component)
    // that wants to receive messages from the KaiManager.
    internal abstract class KaiCommunicatorBase : IKaiCommunicator
    {
        protected ControlResponseDelegateType KaiMessageDelegate;
        protected ControlResponseDelegateType KaiSpecialActionDelegate;

        // Called if the event is raised.
        public abstract void InformKaiEventRaised();

        // Called if the speciall situation occures (initialized, connected).
        public abstract void InformSpecialActionNeeded();

        // Use the following properties to access last event data.
        public string LastEventText { get; set; }
        public EventArgs LastEventArgs { get; set; }
        public JObject LastUnhandledArgs { get; set; }

        public int ManagerID { get; set; }
    }
}
