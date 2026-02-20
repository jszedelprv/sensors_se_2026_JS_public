using System.Drawing;
using System.Windows.Forms;

using MoCap.Gesture;

namespace MyKai.Gesture
{
    public interface IGesture2DCapture
    {
        IGesture2DCaptureQuery Query { get; set; }
        IGesture2DCaptureGet Get { get; set; } 
        UintGesture2D Gesture { get; set; }

        void EnablePanelDrawingType(MyKaiGestureDrawingType pDrawingType);
        void DisablePanelDrawingType(MyKaiGestureDrawingType pDrawingType);
        void BuildGestureCursor(GestureCursorParams pCursorParams);
        void BuildGestureCursorView(Control pControl, Graphics pGraphics);
        void PerformCaptureProcedureStep(float pXAngle, float pYAngle);
        void SwitchGestureCapturingOff();
        void SwitchGestureCapturingOn();
    }
}