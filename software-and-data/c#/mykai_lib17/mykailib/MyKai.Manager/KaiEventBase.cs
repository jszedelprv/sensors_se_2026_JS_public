using System;
using Newtonsoft.Json.Linq;
using MyKai.Communicator;

namespace MyKai.Manager
{
    /// <summary>Class <c>KaiEventBase</c> is an abstract class for Kai event args wrappers.</summary>
    /// <typeparam name="T"> is the type of a Kai event argument.</typeparam>
    internal abstract class KaiEventBase
    {
        protected KaiCommunicatorBase communicator;
        protected string handlerEventMessage;
        protected EventArgs handlerEventArgs;
        protected JObject handlerUnhandledEventArgs;

        public KaiEventBase(KaiCommunicatorBase pCommunicator)
        {
            communicator = pCommunicator;
        }

        public abstract void HandleEvent();

        protected void InformCommunicatorOfEventRaised()
        {
            communicator.LastEventText = handlerEventMessage;
            communicator.LastEventArgs = handlerEventArgs;
            handlerUnhandledEventArgs = null;
            communicator.InformKaiEventRaised();
        }
        protected void InformCommunicatorOfSpecialAction()
        {
            communicator.LastEventText = handlerEventMessage;
            communicator.LastEventArgs = handlerEventArgs;
            communicator.LastUnhandledArgs = handlerUnhandledEventArgs;
            communicator.InformSpecialActionNeeded();
        }

        protected string TextMessage()
        {
            return this.GetType().Name + " received: " + (this as KaiEventBase).ToString();
        }
    }

    /// <summary>Class <c>KaiSmartRegularEven</c> wraps Kai regular event arguments and associates
    /// them with methods for handling events.</summary>
    /// <typeparam name="T"> is the type of a Kai event argument.</typeparam>
    class KaiRegularEvent<T> : KaiEventBase where T : EventArgs
    {
        protected T eventArgs;
        protected static T lastEventArgs = null; // used by some events for filtering

        public KaiRegularEvent(T pEventArgs, KaiCommunicatorBase pCommunicator) : base (pCommunicator)
        {
            eventArgs = pEventArgs;
        }

        public override void HandleEvent()
        {
            handlerEventMessage = TextMessage();
            handlerEventArgs = eventArgs;
            
            InformCommunicatorOfEventRaised();
            
            lastEventArgs = eventArgs;
        }

        public static void ResetLastError() => lastEventArgs = null;
    }

    class KaiNullEventArgs : EventArgs
    {
        // used as a null type passed to generic classes (functions) in the case of occuring
        // UnhandledDataEvent
    }
}
