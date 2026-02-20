using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKai.Gesture
{
    internal partial class Gesture2DCapture
    {
        public class Gesture2DCaptureQuery : IGesture2DCaptureQuery
        {
            private readonly Gesture2DCapture parent = null;

            public Gesture2DCaptureQuery(Gesture2DCapture pParent)
            {
                parent = pParent;
            }

            public bool IsGestureCapturingOn() => parent.isGestureCapturingOn;
            public bool IsViewCursorNull() => parent.GestureCursorView == null;

            public bool IsGestureBeingDrawn() => parent.GestureCursor.StateMachine.State == Gesture2DCursorStateMachine.StateType.JustStabilized ||
                                                 parent.GestureCursor.StateMachine.State == Gesture2DCursorStateMachine.StateType.Drawing ||
                                                 parent.GestureCursor.StateMachine.State == Gesture2DCursorStateMachine.StateType.TryingToEndDraw;
        }
    }
}
