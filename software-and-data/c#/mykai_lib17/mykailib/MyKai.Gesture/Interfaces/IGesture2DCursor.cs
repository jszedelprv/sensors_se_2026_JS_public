using MoCap.Gesture;

namespace MyKai.Gesture
{
    public interface IGesture2DCursor
    {
        Gesture2DCursorStateMachine.StateType LastState { get; set; }
        Gesture2DCursorStateMachine StateMachine { get; set; }
        Gesture2DCursorData GestureData { get; set; }
        Gesture2DCursorData LastData { get; set; }
        IGesture2DIsStableChecker IsStableChcecker { get; set; }

        void InformTargetControlOfStateChanged();
        void PerformGestureFrameAction();
        void PushData();
        void SetPosition(float pXNormalized, float pYNormalized);
        void SetPositionInPixels(int pXInPixels, int pYInPixels);
        void SetPositionUsingAngularData(float pXAngle, float pYAngle);
        (uint X, uint Y) GetPositionInPixels();
        void SetViewportSize(int pWidthInPixels, int pHeightInPixels);
    }
}