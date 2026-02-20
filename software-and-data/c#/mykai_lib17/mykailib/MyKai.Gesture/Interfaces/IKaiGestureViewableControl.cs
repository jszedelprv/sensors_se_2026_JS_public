
using System.Drawing;


namespace MyKai.Gesture
{
    public interface IKaiGestureViewableControl
    {
        IGesture2DCursorViewWF ControlGestureCursorView { get; set; }
        IGetureViewPaintHandlerComponent PaintHandlerComponent { get; set; }
        Graphics CreateControlGraphics();
    }
}
