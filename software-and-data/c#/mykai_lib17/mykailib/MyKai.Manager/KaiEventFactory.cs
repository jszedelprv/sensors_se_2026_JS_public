using System;
using Newtonsoft.Json.Linq;
using MyKai.Communicator;

namespace MyKai.Manager
{
    /// <summary>Class <c>KaiEventFactory</c> creates an instance of a particular smart Kai event.</summary>
    /// <typeparam name="T"> is the type of a Kai event argument, that is wrapped by the class to be created.</typeparam>    
    internal static class KaiEventFactory<T> where T : EventArgs
    {
        static public KaiRegularEvent<T> CreateRegularEvent(T pEventArgs, IKaiCommunicator pCommunicator)
        {
            object[] args = { pEventArgs, pCommunicator };
            var kaiSmartRegularEvent = (KaiRegularEvent<T>)Activator.CreateInstance(GetTypeOfSmartEventForThisFactory(), args);
            return kaiSmartRegularEvent;
        }

        static public UnknownDataEvent CreateUnhandledDataEvent(JObject pData, IKaiCommunicator pCommunicator)
        {
            object[] args = { pData, pCommunicator };
            var kaiUnhandledDataEvent = (UnknownDataEvent)Activator.CreateInstance(typeof(UnknownDataEvent), args);
            return kaiUnhandledDataEvent;
        }

        static public Type GetTypeOfSmartEventForThisFactory()
        {
            return KaiEventRegistry.DefKaiEventParameters.SmartEventTypeByEventArgsType(typeof(T));
        }
    }
}
