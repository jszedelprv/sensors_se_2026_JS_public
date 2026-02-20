using System;
using System.Windows.Forms;
using Kai.Module;
using MyKai.Communicator;
using MyKai.GUI;

namespace MyKai.Manager
{
    internal abstract class KaiManagerBase : IKaiManager, IKaiLoggingAwareClass
    {
        protected KaiCapabilities activeCapabilities;
        public IKaiEventLogger KaiEventLogger { get; set; }
        public IKaiMessageLogUserControl KaiMessageLogUserControl { get; set; }

        protected IKaiCommunicator communicator; // dependency used to invoke client own reaction to messages

        protected ContainerControl parentControl; // dependecy used to access the parent form or user control

        protected KaiEventHandler kaiEventHandler = new KaiEventHandler(); // dependency used to invoke client own reaction to messages
        
        protected bool isManagerActive;

        public KaiCapabilities ActiveCapabilities

        {
            get
            {
                return activeCapabilities;
            }

            set
            {
                SetTracedCapabilities(value);
            }
        }

        protected KaiManagerBase()
        {
            activeCapabilities = 0;
            isManagerActive = false;
        }

        public void SetKaiCommunicator(IKaiCommunicator pCommunicator)
        {
            communicator = pCommunicator;
            kaiEventHandler.Communicator = pCommunicator;
        }

        public void SetParentControl(ContainerControl pParentControl)
        {
            this.parentControl = pParentControl;
        }

        public abstract string GetLastEventMessage();

        public abstract EventArgs GetLastEventArgsIfType<T>();

        // Sets the decimation of a prticular event type (only each Nth (N=pFerquency) 
        // event will generate actions.
        public abstract void SetEventDecimation(KaiEventType pKaiEventType, int pFrequency);

        protected void InitializeKaiSDK(string processName, string processSecret)
        {

            if (KaiSession.Query.IsSDKDisconnected())
            {
                KaiSDK.Initialise(processName, processSecret);
                KaiSession.StateMachine.SwitchSDKInitialized();
            }
        }

        public abstract void InitializeManager(string processName, string processSecret);

        public abstract void StartEventAcquisition();

        public abstract void StopEventAcquisition();

        protected abstract void SetTracedCapabilities(KaiCapabilities pCapabilities);
    }
}

