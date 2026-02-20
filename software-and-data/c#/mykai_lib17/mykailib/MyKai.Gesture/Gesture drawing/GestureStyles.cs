using System.Drawing;

namespace MyKai.Gesture
{
    internal static class GestureStyles
    {
        internal static class ClearColors
        {
            internal static readonly Color Bitmap = Color.White;
            internal static readonly Color Panel = Color.White;
            internal static readonly Color DesktopModeBitmap = Color.Transparent;
        }

        internal static class Trail
        {
            private static readonly Color PenColor = Color.Black;
            private static readonly int PenWidth = 5;

            private static readonly Color BrushColor = Color.Black;

            internal static SolidBrush TrailBrush = new SolidBrush(BrushColor);
            internal static Pen TrailPen = new Pen(PenColor)
            {
                Width = PenWidth
            };
        }

        internal static class BezierControl
        {
            private static readonly Color PenColor = Color.Red;
            private static readonly int PenWidth = 5;
            
            private static readonly Color BrushColor = Color.Black;

            internal static SolidBrush BezierBrush = new SolidBrush(BrushColor);
            internal static Pen BezierPen = new Pen(PenColor)
            {
                Width = PenWidth

            };

            internal static readonly int BezierXTilt = 0;
        }

        internal static class BezierBitmap
        {
            private static readonly Color PenColor = Color.Black;
            private static readonly int PenWidth = 5;

            private static readonly Color BrushColor = Color.Black;

            internal static SolidBrush BezierBrush = new SolidBrush(BrushColor);
            internal static Pen BezierPen = new Pen(PenColor)
            {
                Width = PenWidth
            };
        }

        internal static class Points
        {
            private static readonly Color PenColor = Color.Black;
            private static readonly int PenWidth = 1;
            internal static readonly int PointSize = 12;

            private static readonly Color BrushColor = Color.Lime;
            
            internal static SolidBrush PointsBrush = new SolidBrush(BrushColor);
            internal static Pen PointsPen = new Pen(PenColor)
            {
                Width = PenWidth
            };
        }

        internal static class BeziersPoints
        {
            private static readonly Color PenColor = Color.Red;
            private static readonly int PenWidth = 0;
            internal static readonly int PointSize = 0;

            private static readonly Color BrushColor = Color.Gray;

            internal static SolidBrush PointsBrush = new SolidBrush(BrushColor);
            internal static Pen PointsPen = new Pen(PenColor)
            {
                Width = PenWidth
            };
        }
        
        internal static class BoundingRectangle
        {
            private static readonly Color PenColor = Color.Red;
            private static readonly int PenWidth = 1;
            
            internal static Pen BoundingRectanglePen = new Pen(PenColor)
            {
                Width = PenWidth
            };
        }
    }
}
