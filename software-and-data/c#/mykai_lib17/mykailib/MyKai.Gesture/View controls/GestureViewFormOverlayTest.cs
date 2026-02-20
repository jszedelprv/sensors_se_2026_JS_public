using System.Windows.Forms;
using System.Drawing;

namespace MyKai.Gesture
{
    public class GestureViewFormOverlayTest : Form
    {
        // Temporary: Test drawing a cursor
        Bitmap gestureCursor;
        Point gestureCursorPosition;

        private Gesture2DCursorViewWF ControlGestureCursorView { get; set; }

        public GestureViewFormOverlayTest()
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

            this.Paint += GestureViewFormOverlay_Paint;

            PrepareTemporaryGestureCursorTest();
        }

        void PrepareTemporaryGestureCursorTest()
        {
            // Temporary : Test drawing a cursor

            Rectangle bounds = Screen.FromPoint(Cursor.Position).Bounds;
            this.Bounds = bounds;

            // Load your custom gesture cursor image here
            gestureCursor = Properties.MyKaiResources.cursor_unstable_32; // Replace with your actual image
            gestureCursorPosition = new Point(bounds.Width / 2, bounds.Height / 2);

            // Timer to simulate updates (replace with actual Kai sensor updates)
            Timer timer = new Timer();
            timer.Interval = 16; // ~60 FPS
            timer.Tick += (s, e) =>
            {
                // Simulate movement (replace with gesture update)
                gestureCursorPosition.X = (gestureCursorPosition.X + 2) % bounds.Width;

                Invalidate();
            };
            timer.Start();

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80000 | 0x20; // WS_EX_LAYERED | WS_EX_TRANSPARENT
                return cp;
            }
        }

        private void GestureViewFormOverlay_Paint(object sender, PaintEventArgs e)
        {
            // Temporary : Test drawing a cursor
            if (gestureCursor != null)
            {
                e.Graphics.DrawImage(gestureCursor, gestureCursorPosition);
            }

            if (ControlGestureCursorView == null)
                return;

            if (ControlGestureCursorView.ShouldDrawOnPaint)
                if (ControlGestureCursorView.CursorDrawingParameters.DrawingMode == DrawingModeType.DrawOnTargetControlPaint)
                {
                    ControlGestureCursorView.DrawOnTargetControlPaint(this, e);
                    ControlGestureCursorView.ShouldDrawOnPaint = false; // Reset the state variable to prevent drawing on the next Paint event
                }
        }
    }
}
