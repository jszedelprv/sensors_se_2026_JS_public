using System.Drawing;

namespace MyKai.Gesture
{
    public static class ShowImage
    {
        public static void ShowTestViewer(Image image)
        {
            using (var form = new FrmBitmapTestViewer(image))
            {
                form.ShowDialog();
            }
        }
    }
}
