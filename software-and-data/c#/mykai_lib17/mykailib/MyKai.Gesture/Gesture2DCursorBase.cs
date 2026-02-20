using System.Windows.Forms;
using MyKai.General;

namespace MyKai.Gesture
{
    public class GestureCursorParams
    {
        public Control OwnerControl;        
        public KaiControlNotifier.OnNotifyFunctionDelegate OnStateChanged;
        public (int Width, int Height ) ViewPortSize;
    }

    internal abstract class Gesture2DCursorBase : IGesture2DCursor
    {
        public Gesture2DCursorStateMachine StateMachine;

        public float AngleLimit;

        public KaiControlNotifier StepMadeNotifier;   // Used to notify a GUI control whether a step is performed

        // public KaiControlNotifier DrawingEndedNotifier; // To be used to notify a GUI control whether drawing is ended 
                                                           // Now is not used, so we comment it out to avoid warnings

        Gesture2DCursorStateMachine IGesture2DCursor.StateMachine { get => StateMachine; set => throw new System.NotImplementedException(); }
        
        public Gesture2DCursorStateMachine.StateType LastState { get; set; }
        
        public Gesture2DCursorData GestureData { get; set; }
        
        private Gesture2DCursorData lastData; // Used becouse it's not possible to use 'ref' in properties
        public Gesture2DCursorData LastData { get => lastData; set { lastData = value; } }
        
        private IGesture2DIsStableChecker isStableChecker;
        public IGesture2DIsStableChecker IsStableChcecker { get => isStableChecker; set {isStableChecker = value;} }

        public void PushData()
        {
            GestureData.CopyDataTo(ref lastData);
            LastState = StateMachine.State;
        }

        public void InformTargetControlOfStateChanged()
        {
            object[] args = { StateMachine.State };
            StepMadeNotifier.SendMessage(args);
        }

        public abstract void SetPosition(float pXNormalized, float pYNormalized);
        public abstract void SetPositionInPixels(int pXInPixels, int pYInPixels);
        public abstract void SetPositionUsingAngularData(float pXAngle, float pYAngle);
        public abstract void SetViewportSize(int pWidthInPixels, int pHeightInPixels);
        public abstract void PerformGestureFrameAction();

        public abstract (uint X, uint Y) GetPositionInPixels();
    }
}
