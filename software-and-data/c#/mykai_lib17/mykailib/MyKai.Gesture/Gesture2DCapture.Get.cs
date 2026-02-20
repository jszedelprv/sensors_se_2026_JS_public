
using MoCap.Gesture;
using System.Drawing;

namespace MyKai.Gesture
{
    internal partial class Gesture2DCapture
    {
        public class Gesture2DCaptureGet : IGesture2DCaptureGet
        {
            private readonly Gesture2DCapture parent = null;

            public Gesture2DCaptureGet(Gesture2DCapture pParent)
            {
                parent = pParent;
            }

            public UintGesture2D Gesture2D
            {
                get => parent.Gesture;
            }

            IGesture2DCursor IGesture2DCaptureGet.GestureCursor
            {
                get => parent.GestureCursor;
            }

            IGesture2DCursorViewWF IGesture2DCaptureGet.GestureCursorView
            {
                get => parent.GestureCursorView;
            }

            IGesture2DCapture IGesture2DCaptureGet.Gesture2DCapture { get => parent; }
        }
    }
}
