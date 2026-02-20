using System;
using System.Collections.Generic;
using Kai.Module;

namespace MyKai.Manager
{
    public enum KaiEventType
    {
        GestureEvent = 0, LinearFlickEvent, FingerShortcutEvent, FingerPositionalEvent, PYREvent, QuaternionEvent,
        AccelerometerEvent, GyroscopeEvent, MagnetometerEvent, ErrorEvent
    }

    public class KaiEventAdditionalParams
    {
        public Type KaiEventArgsType;
        public Type KaiSmartEventType;
        public int EventHandlingFrequency; // 1 - handle each event, 2 handle every second event, and so on        
    }

    internal class KaiEventRegistry
    {
        public Dictionary<KaiEventType, KaiEventAdditionalParams> KaiEventItems = new Dictionary<KaiEventType, KaiEventAdditionalParams>();

        public static KaiEventRegistry DefKaiEventParameters = new KaiEventRegistry();

        public KaiEventRegistry()
        {
            CreateItems();
            InitializeItems();
        }

        private void CreateItems()
        {
            foreach (var eventType in Enum.GetValues(typeof(KaiEventType)))
                KaiEventItems.Add((KaiEventType)eventType, new KaiEventAdditionalParams());
        }

        private void InitializeItems()
        {
            InitializeParameterValues();
            InitializeKaiEventArgsTypes();
            InitializeKaiSmartEventTypes();
        }

        private void InitializeParameterValues()
        {
            foreach (KeyValuePair<KaiEventType, KaiEventAdditionalParams> item in KaiEventItems)
            {
                item.Value.EventHandlingFrequency = 0;
            }
        }

        private void InitializeKaiEventArgsTypes()
        {
            KaiEventItems[KaiEventType.GestureEvent].KaiEventArgsType = typeof(GestureEventArgs);
            KaiEventItems[KaiEventType.LinearFlickEvent].KaiEventArgsType = typeof(LinearFlickEventArgs);
            KaiEventItems[KaiEventType.FingerShortcutEvent].KaiEventArgsType = typeof(FingerShortcutEventArgs);
            KaiEventItems[KaiEventType.FingerPositionalEvent].KaiEventArgsType = typeof(FingerPositionalEventArgs);
            KaiEventItems[KaiEventType.PYREvent].KaiEventArgsType = typeof(PYREventArgs);
            KaiEventItems[KaiEventType.QuaternionEvent].KaiEventArgsType = typeof(QuaternionEventArgs);
            KaiEventItems[KaiEventType.AccelerometerEvent].KaiEventArgsType = typeof(AccelerometerEventArgs);
            KaiEventItems[KaiEventType.GyroscopeEvent].KaiEventArgsType = typeof(GyroscopeEventArgs);
            KaiEventItems[KaiEventType.MagnetometerEvent].KaiEventArgsType = typeof(MagnetometerEventArgs);
            KaiEventItems[KaiEventType.ErrorEvent].KaiEventArgsType = typeof(Kai.Module.ErrorEventArgs);
        }

        private void InitializeKaiSmartEventTypes()
        {
            KaiEventItems[KaiEventType.GestureEvent].KaiSmartEventType = typeof(GestureEvent);
            KaiEventItems[KaiEventType.LinearFlickEvent].KaiSmartEventType = typeof(LinearFlickEvent);
            KaiEventItems[KaiEventType.FingerShortcutEvent].KaiSmartEventType = typeof(FingerShortcutEvent);
            KaiEventItems[KaiEventType.FingerPositionalEvent].KaiSmartEventType = typeof(FingerPositionalEvent);
            KaiEventItems[KaiEventType.PYREvent].KaiSmartEventType = typeof(PYREvent);
            KaiEventItems[KaiEventType.QuaternionEvent].KaiSmartEventType = typeof(QuaternionEvent);
            KaiEventItems[KaiEventType.AccelerometerEvent].KaiSmartEventType = typeof(AccelerometerEvent);
            KaiEventItems[KaiEventType.GyroscopeEvent].KaiSmartEventType = typeof(GyroscopeEvent);
            KaiEventItems[KaiEventType.MagnetometerEvent].KaiSmartEventType = typeof(MagnetometerEvent);
            KaiEventItems[KaiEventType.ErrorEvent].KaiSmartEventType = typeof(ErrorEvent);
        }

        public Type SmartEventTypeByEventArgsType(Type pEventArgsType)
        {
            foreach (KeyValuePair<KaiEventType, KaiEventAdditionalParams> item in KaiEventItems)
                if (pEventArgsType == item.Value.KaiEventArgsType)
                    return item.Value.KaiSmartEventType;

            throw new NotSupportedException($"Kai event argument {pEventArgsType.GetType().Name} is not supported by MyKai.{this.GetType().Name}.");
        }

        public KaiEventAdditionalParams ParamsByEventArgsType(Type pEventArgsType)
        {
            foreach (KeyValuePair<KaiEventType, KaiEventAdditionalParams> item in KaiEventItems)
                if (pEventArgsType == item.Value.KaiEventArgsType)
                    return item.Value;

            throw new NotSupportedException($"Kai event argument {pEventArgsType.GetType().Name} is not supported by MyKai.{this.GetType().Name}.");
        }
    }
}
