using System.Drawing;
using System.Windows.Forms;

namespace MyKai.Gesture
{
    internal partial class FrmBitmapTestViewer : Form
    {
        public FrmBitmapTestViewer()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Image image;

        public FrmBitmapTestViewer(Bitmap pBitmap)
        {
            InitializeComponent();
            bitmap = pBitmap;
            image = null;
        }

        public FrmBitmapTestViewer(Image pImage)
        {
            InitializeComponent();
            image = pImage;
            bitmap = null;
        }

        private void pnBitmap_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);

            if (bitmap != null)
            {
                // Convert Bitmap to Image
                Image localImage = (Image)bitmap.Clone();
                graphics.DrawImage(localImage, 0, 0);
                localImage.Dispose();
            }
            if (image != null)
            {
                graphics.DrawImage(image, 0, 0);
            }

            graphics.DrawEllipse(Pens.Blue, 0, 0, 640, 640);

            base.OnPaint(e);
        }
    }
}
