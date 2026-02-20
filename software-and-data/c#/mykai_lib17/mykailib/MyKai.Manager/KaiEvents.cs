using System;
using Newtonsoft.Json.Linq;
using Kai.Module;
using MyKai.Communicator;

namespace MyKai.Manager
{
    // Gesture event
    internal class GestureEvent : KaiRegularEvent<GestureEventArgs>
    {
        public GestureEvent(GestureEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // LinearFlick event
    internal class LinearFlickEvent : KaiRegularEvent<LinearFlickEventArgs>
    {
        public LinearFlickEvent(LinearFlickEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // FingerShortcut event
    internal class FingerShortcutEvent : KaiRegularEvent<FingerShortcutEventArgs>
    {
        public FingerShortcutEvent(FingerShortcutEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // FingerShortcut event
    internal class FingerPositionalEvent : KaiRegularEvent<FingerShortcutEventArgs>
    {
        public FingerPositionalEvent(FingerShortcutEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    //PYR event
    internal class PYREvent : KaiRegularEvent<PYREventArgs>
    {
        public PYREvent(PYREventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // Quaternion event
    internal class QuaternionEvent : KaiRegularEvent<QuaternionEventArgs>
    {
        public QuaternionEvent(QuaternionEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // Accelerometer event
    internal class AccelerometerEvent : KaiRegularEvent<AccelerometerEventArgs>
    {
        public AccelerometerEvent(AccelerometerEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // Gyroscope event
    internal class GyroscopeEvent : KaiRegularEvent<GyroscopeEventArgs>
    {
        public GyroscopeEvent(GyroscopeEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // Magnetometer event
    internal class MagnetometerEvent : KaiRegularEvent<MagnetometerEventArgs>
    {
        public MagnetometerEvent(MagnetometerEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }
        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    class ErrorEvent : KaiRegularEvent<Kai.Module.ErrorEventArgs>
    {      
        public ErrorEvent(Kai.Module.ErrorEventArgs pEventArgs, KaiCommunicatorBase pCommunicator) : base(pEventArgs, pCommunicator)
        {
        }

        public override void HandleEvent()
        {
            if (lastEventArgs != null && lastEventArgs is Kai.Module.ErrorEventArgs)
                if (lastEventArgs.Error == eventArgs.Error) // prevent multiple error events of same type 
                    return;

            base.HandleEvent();
        }

        public override string ToString() => KaiEventStringAdapter.EventArgsToString(eventArgs);
    }

    // Unhandled data event
    class UnknownDataEvent : KaiEventBase
    {
        protected JObject data;

        public UnknownDataEvent(JObject pData, KaiCommunicatorBase pCommunicator) : base(pCommunicator)
        {
            data = pData;
        }

        public override void HandleEvent()
        {
            handlerEventMessage = TextMessage();
            handlerEventArgs = null;
            handlerUnhandledEventArgs = data;
            CheckAndHandleSpecialAction();
            InformCommunicatorOfEventRaised();
        }

        protected void CheckAndHandleSpecialAction()
        {
            string success = (string)data.SelectToken("success");
            string type = (string)data.SelectToken("type");

            if (success == "True" )
                if (type == "setCapabilities" && KaiSession.Query.CanEnterSensorConnected())
                {
                    KaiSession.StateMachine.TrySwitchSensorConnected();
                    InformCommunicatorOfSpecialAction();
                }

            if (type == "kaiDisconnected" && KaiSession.Query.CanEnterSensorDisconnected())
            {
                KaiSession.StateMachine.SwtichSensorDisconnected();
                InformCommunicatorOfSpecialAction();
            }

        }

        public override string ToString() => KaiEventStringAdapter.EventArgsToString(data);
    }
}
