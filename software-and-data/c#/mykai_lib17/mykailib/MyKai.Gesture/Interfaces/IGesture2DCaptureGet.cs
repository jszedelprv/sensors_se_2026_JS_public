using MoCap.Gesture;
using System.Drawing;
namespace MyKai.Gesture
{
    public interface IGesture2DCaptureGet
    {
        IGesture2DCursor GestureCursor { get;}
        IGesture2DCursorViewWF GestureCursorView { get;}
        IGesture2DCapture Gesture2DCapture { get; }
        UintGesture2D Gesture2D { get; }
    }
}