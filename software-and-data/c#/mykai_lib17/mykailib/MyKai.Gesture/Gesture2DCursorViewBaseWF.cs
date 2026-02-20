
using MoCap.Gesture;

namespace MyKai.Gesture
{
    public enum DrawingModeType
    {
        EraseAndDrawOnCapture,
        DrawOnTargetControlPaint
    }

    internal abstract class Gesture2DCursorViewBaseWF : IGesture2DCursorViewWF
    {
        protected struct curPosStruct
        {
            public int x, lastX;
            public int y, lastY;
            public int shift;
        }
        protected curPosStruct curPos = new curPosStruct();

        public IGesture2DCursor ViewedCursor { get; set; }

        public UintGesture2D localGesture2DCopy;
        internal IGesture2DCaptureGet GestureCaptureGet { get; set; }

        public bool ShouldDrawOnPaint { get; set; } // State variable to indicate if drawing should be done on Paint event of targetControl

        internal WinFormsDrawingParameters cursorDrawingParams = new WinFormsDrawingParameters();
        public WinFormsDrawingParameters CursorDrawingParameters 
        { 
            get => cursorDrawingParams;
            set { cursorDrawingParams = value; } 
        }

        public abstract void InitView(WinFormsDrawingParameters pViewParameters);
        public abstract void DrawCurrentCursor();
        public abstract void ClearPreviousCursor();
    }
}
