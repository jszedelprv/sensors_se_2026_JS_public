

using MyKai.Gesture;

namespace MyKai.Facade
{
    public partial class MyKaiFacade
    {
        public class QuerySubclass
        {
            MyKaiFacade parent;

            public QuerySubclass(MyKaiFacade pParent)
            {
                this.parent = pParent;
            }

            public bool IsCursorInJustEndedState() 
                => parent.ComponentHolder.gesture2DCapture.Get.GestureCursor.StateMachine.State ==
                   Gesture2DCursorStateMachine.StateType.JustEndedDrawing;
        }
    }
}
