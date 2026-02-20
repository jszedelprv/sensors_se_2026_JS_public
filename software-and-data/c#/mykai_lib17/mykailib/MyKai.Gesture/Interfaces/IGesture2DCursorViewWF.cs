using System.Drawing;
using System.Windows.Forms;


namespace MyKai.Gesture
{
    public struct WinFormsDrawingParameters
    {
        public Control TargetControl;
        public Graphics TargetControlGraphics;

        public DrawingModeType DrawingMode;

        public int RedrawMargin;
        public int StdCursorSize;
        public int CrossmarkSize;
        public int MaxStabilizingMarkRadius;
        public int MinStabilizingMarkRadius;
        public int StabilizingCursorRedrawInterval;
        public int UnstableOrIdleTimeLimit;

        public bool ApplyLowPassFilterOnEnding;
        public int NumberOfPoints_Filtering;
        public float LowPassFilterFactor;
    }

    public interface IGesture2DCursorViewWF
    {
        IGesture2DCursor ViewedCursor { get; set; }
        WinFormsDrawingParameters CursorDrawingParameters { get; set; }
        bool ShouldDrawOnPaint { get; set; }
        void ClearPreviousCursor();
        void DrawCurrentCursor();
        void InitView(WinFormsDrawingParameters pViewParameters);
    }
}