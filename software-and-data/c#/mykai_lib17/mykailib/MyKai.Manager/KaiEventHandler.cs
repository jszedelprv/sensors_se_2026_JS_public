using System;
using Newtonsoft.Json.Linq;
using Kai.Module;
using MyKai.Communicator;


namespace MyKai.Manager
{
    /// <summary>Class <c>KaiEventHandler</c> contains handler templates for regular events, 
    /// and a handler for "unhandled data" event. Allows to assign and retract handlers.</summary>
    internal class KaiEventHandler
    {
        public IKaiCommunicator Communicator = null; 
        static int eventIgnoreCount = 0;

        public void HandleEvent<T>(object e, EventArgs pEventArgs) where T : EventArgs
        {
            CheckCommunicatorDependency();

            if ( ShouldHandleEvent<T>() )
            {
                KaiRegularEvent<T> kaiSmartEvent = KaiEventFactory<T>.CreateRegularEvent((T)pEventArgs, Communicator);
                kaiSmartEvent.HandleEvent();
            }
        }

        public void HandleUnknownDataEvent<T>(JObject pData) where T : EventArgs
        {
            CheckCommunicatorDependency();

            UnknownDataEvent unknowDataEvent = KaiEventFactory<T>.CreateUnhandledDataEvent(pData, Communicator);
            unknowDataEvent.HandleEvent();
        }

        private void CheckCommunicatorDependency()
        {
            if (Communicator == null)
                throw new NullReferenceException($"{typeof(KaiEventHandler).Name} communicator dependency not set.");
        }

        private bool ShouldHandleEvent<T>()
        {
            int freq = KaiEventRegistry.DefKaiEventParameters.ParamsByEventArgsType(typeof(T)).EventHandlingFrequency;

            if (freq == 0)
                return true;

            if (eventIgnoreCount++ < freq)
                return false;
            else
            {
                eventIgnoreCount = 0;
                return true;
            }
        }

        // User can decide which type of events should be handled by KaiEventHandler (regular, global, or both)
        // by choosing a proper pair (assign/retract) of the following functions

        public void AssignHandlers(Kai.Module.Kai pKai)
        {
            AssignRegularHandlers(pKai);
            AssignGlobalHandlers();
        }

        public void RetractHandlers(Kai.Module.Kai pKai)
        {
            RetractRegularHandlers(pKai);
            RetractGlobalHandlers();
        }

        
        public void AssignRegularHandlers(Kai.Module.Kai pKai)
        {
            // default kai event handler callbacks
            pKai.Gesture += HandleEvent<GestureEventArgs>;
            pKai.LinearFlick += HandleEvent<LinearFlickEventArgs>;
            pKai.FingerShortcut += HandleEvent<FingerShortcutEventArgs>;
            pKai.FingerPositionalData += HandleEvent<FingerPositionalEventArgs>;
            pKai.PYRData += HandleEvent<PYREventArgs>;
            pKai.QuaternionData += HandleEvent<QuaternionEventArgs>;
            pKai.AccelerometerData += HandleEvent<AccelerometerEventArgs>;
            pKai.MagnetometerData += HandleEvent<MagnetometerEventArgs>;
            pKai.GyroscopeData += HandleEvent<GyroscopeEventArgs>;
        }

        public void AssignGlobalHandlers()
        {
            KaiSDK.UnknownData = HandleUnknownDataEvent<KaiNullEventArgs>;
            KaiSDK.Error += HandleEvent<Kai.Module.ErrorEventArgs>;
        }

        public void RetractRegularHandlers(Kai.Module.Kai pKai)
        {
            // default kai event handler callbacks
            pKai.Gesture -= HandleEvent<GestureEventArgs>;
            pKai.LinearFlick -= HandleEvent<LinearFlickEventArgs>;
            pKai.FingerShortcut -= HandleEvent<FingerShortcutEventArgs>;
            pKai.FingerPositionalData -= HandleEvent<FingerPositionalEventArgs>;
            pKai.PYRData -= HandleEvent<PYREventArgs>;
            pKai.QuaternionData -= HandleEvent<QuaternionEventArgs>;
            pKai.AccelerometerData -= HandleEvent<AccelerometerEventArgs>;
            pKai.MagnetometerData -= HandleEvent<MagnetometerEventArgs>;
            pKai.GyroscopeData -= HandleEvent<GyroscopeEventArgs>;
        }

        public void RetractGlobalHandlers()
        {
            KaiSDK.UnknownData = null;
            KaiSDK.Error -= HandleEvent<Kai.Module.ErrorEventArgs>;
        }
    }
}
