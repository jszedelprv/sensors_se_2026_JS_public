using System;
using System.Drawing;
using System.Windows.Forms;


namespace MyKai.Gesture
{
    public class GestureViewPanelHostedControl : Control, IGestureViewPanelHostedControl
    {
        private Panel hostingPanel;

        public GestureViewPanelHostedControl()
        {
            this.DoubleBuffered = true; // Crucial for flicker-free drawing
            this.BackColor = System.Drawing.Color.White;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.Dock = DockStyle.Fill;
        }


        public Panel HostingPanel
        {
            get => hostingPanel;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Hosting panel cannot be null.");

                IsHosted = true;

                hostingPanel = value;
                hostingPanel.Controls.Clear();
                hostingPanel.Controls.Add(this);
                hostingPanel.Refresh();
            }
        }

        public IGesture2DCursorViewWF ControlGestureCursorView { get; set; }
        public IGetureViewPaintHandlerComponent PaintHandlerComponent { get; set; }
        public bool IsHosted { get; set; } = false;

        public Graphics CreateControlGraphics()
        {
            return this.CreateGraphics();
        }
    }
}
