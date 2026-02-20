
using System.Drawing;
using System.Windows.Forms;

namespace MyKai.Gesture
{
    public class GestureViewFormOverlay : Form, IKaiGestureViewableControl
    {
        IGesture2DCursorViewWF IKaiGestureViewableControl.ControlGestureCursorView { get; set; }
        public IGetureViewPaintHandlerComponent PaintHandlerComponent { get; set; }

        public GestureViewFormOverlay()
        {
            this.DoubleBuffered = true; // Crucial for flicker-free drawing

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.Dock = DockStyle.Fill;

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.DoubleBuffered = true;

            Rectangle bounds = Screen.FromPoint(Cursor.Position).Bounds;
            this.Bounds = bounds;
        }

        public Graphics CreateControlGraphics()
        {
            return this.CreateGraphics();
        }

        // There are no refernces, but this method is called by the base class - it makes the form layered and transparent.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80000 | 0x20; // WS_EX_LAYERED | WS_EX_TRANSPARENT
                return cp;
            }
        }
    }
}

