using System;

using System.Windows.Forms;

namespace MyKai.Gesture
{
    internal class CursorViewPaintHandlerComponent : IGetureViewPaintHandlerComponent
    {
        IGesture2DCursorViewWF ControlGestureCursorView { get; set; }

        public CursorViewPaintHandlerComponent(IGesture2DCursorViewWF pControlGestureCursorView)
        {
            ControlGestureCursorView = pControlGestureCursorView ?? throw new ArgumentNullException(nameof(pControlGestureCursorView), "ControlGestureCursorView cannot be null.");
        }

        public void AddPaintEvent(Control pControl)
        {
            Panel aPanel = pControl as Panel;
            pControl.Paint += GestureControl_Paint;
        }

        public void GestureControl_Paint(object sender, PaintEventArgs e)
        {
            if (ControlGestureCursorView == null)
                return;

            if (ControlGestureCursorView.ShouldDrawOnPaint)
                if (ControlGestureCursorView.CursorDrawingParameters.DrawingMode == DrawingModeType.DrawOnTargetControlPaint)
                {
                    IDrawableOnPaint drawable = ControlGestureCursorView as IDrawableOnPaint;
                    drawable.DrawOnTargetControlPaint(this, e);
                    ControlGestureCursorView.ShouldDrawOnPaint = false; // Reset the state variable to prevent drawing on the next Paint event
                }
        }

    }
}
