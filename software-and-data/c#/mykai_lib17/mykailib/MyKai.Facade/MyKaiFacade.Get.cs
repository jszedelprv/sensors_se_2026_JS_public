using System.Drawing;
using MyKai.Communicator;
using MyKai.Gesture;
using MyKai.Manager;

namespace MyKai.Facade
{
    public partial class MyKaiFacade
    {
        public class GetSubclass
        {
            MyKaiFacade parent;
    
            public GetSubclass(MyKaiFacade pParent)
            {
                this.parent = pParent;
            }

            public IKaiManager KaiManager { get => parent.ComponentHolder.kaiManager; }
            public IKaiCommunicator KaiCommunicator { get => parent.ComponentHolder.kaiCommunicator; }
            public IGesture2DCapture Gesture2DCapture { get => parent.ComponentHolder.gesture2DCapture;}
            public IKaiGestureViewableControl GestureViewControl { get => parent.ComponentHolder.gestureViewControl; }
            internal IGesture2DCaptureQuery Query { get => parent.ComponentHolder.gesture2DCapture.Query; }
            
            public WinFormsDrawingParameters CursorDrawingParameters
            {
                get => parent.ComponentHolder.gesture2DCapture.Get.GestureCursorView.CursorDrawingParameters;// WinFormsDrawingParameters;
                set => parent.ComponentHolder.gesture2DCapture.Get.GestureCursorView.CursorDrawingParameters = value;
            }

            public IGesture2DCursorViewWF GestureCursorView
            {
                get => parent.ComponentHolder.gesture2DCapture.Get.GestureCursorView;
            }

            public Gesture2DCursorStateMachine.StateType GestureCursorState
            {
                get => parent.ComponentHolder.gesture2DCapture.Get.GestureCursor.StateMachine.State;
            }

            public Gesture2DCursorData GestureCursorData
            {
                get => parent.ComponentHolder.gesture2DCapture.Get.GestureCursor.GestureData;
            }

            public Gesture2DCursorStateMachine.StateParamsStruct GestureCursorStateMachineParams
            {
                get => parent.ComponentHolder.gesture2DCapture.Get.GestureCursor.StateMachine.StateParams;
                set => parent.ComponentHolder.gesture2DCapture.Get.GestureCursor.StateMachine.StateParams = value;
            }

            public Bitmap TrailBitmap
            {
                get 
                {
                    Gesture2DCapture g2dCapture = parent.ComponentHolder.gesture2DCapture as Gesture2DCapture;
                    
                    return g2dCapture?.GestureBitmaps.TrailBitmap;
                }
            }
            public Bitmap BezierBitmap
            {
                get 
                {
                    Gesture2DCapture g2dCapture = parent.ComponentHolder.gesture2DCapture as Gesture2DCapture;
                    
                    return g2dCapture?.GestureBitmaps.BezierBitmap;
                }
            }
        }
    }
}
