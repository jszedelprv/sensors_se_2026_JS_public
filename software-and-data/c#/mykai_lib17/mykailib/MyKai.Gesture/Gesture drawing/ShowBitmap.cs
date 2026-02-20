using System.Drawing;

namespace MyKai.Gesture
{
    public static class ShowBitmap
    {
        public static void ShowTestViewer(Bitmap bitmap)
        {
            using (var form = new FrmBitmapTestViewer(bitmap))
            {
                form.ShowDialog();
            }
        }
    }
}
