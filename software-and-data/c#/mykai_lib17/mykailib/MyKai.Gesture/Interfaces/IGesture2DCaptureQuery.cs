namespace MyKai.Gesture
{
    public interface IGesture2DCaptureQuery
    {
        bool IsGestureCapturingOn();
        bool IsViewCursorNull();
        bool IsGestureBeingDrawn();
    }
}