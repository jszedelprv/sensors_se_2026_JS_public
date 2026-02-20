
using System.Drawing;

namespace MyKai.Gesture
{
    internal class Gesture2DBitmaps
    {      
        ~Gesture2DBitmaps()
        {
            if (TrailBitmap != null)
            {
                TrailBitmap.Dispose();
                TrailBitmap = null;
            }
            if (BezierBitmap != null)
            {
                BezierBitmap.Dispose();
                BezierBitmap = null;
            }
        }

        public Bitmap TrailBitmap { get; set; } = null;
        public Bitmap BezierBitmap { get; set; } = null;
    }
}
