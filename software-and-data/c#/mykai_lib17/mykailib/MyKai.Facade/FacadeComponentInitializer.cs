using MyKai.Communicator;
using MyKai.General;
using MyKai.Gesture;
using MyKai.Manager;
using System.Drawing;
using System.Windows.Forms; 

namespace MyKai.Facade
{
    internal class FacadeComponentInitializer
    {
        private MyKaiFacade facade;

        internal FacadeComponentInitializer(MyKaiFacade pFacade) 
        {
            facade = pFacade;
        }

        internal void PerformInitActions()
        {
                      
            facade.ComponentHolder.kaiCommunicator = MakeKaiCommunicator();
            MakeKaiManager(facade.ComponentHolder.kaiCommunicator);
            MakeGesture2DCapture();
            MakeGestureCursor();
            MakeGestureCursorView();
            
            facade.ComponentHolder.gestureViewControl.ControlGestureCursorView = facade.ComponentHolder.gesture2DCapture.Get.GestureCursorView;
            facade.ComponentHolder.gestureViewControl.PaintHandlerComponent = new CursorViewPaintHandlerComponent(facade.ComponentHolder.gesture2DCapture.Get.GestureCursorView);
            facade.ComponentHolder.gestureViewControl.PaintHandlerComponent.AddPaintEvent((Control)(facade.ComponentHolder.gestureViewControl));
        }

        private void MakeKaiManager(IKaiCommunicator pKaiCommunicator)
        {
            facade.ComponentHolder.kaiManager = new BuilderOfDefKaiManager().WithParentControl(facade.ComponentHolder.ownerControl)
                                                                            .WithKaiCommunicator(pKaiCommunicator)  // Bug detected: covers the first communicator, why? 
                                                                            .Build();
        }

        private KaiCommunicatorBase MakeKaiCommunicator()
        {
            KaiCommunicatorBase kaiCommunicator;

            object[] pArgs = { facade.ComponentHolder.ownerControl };
            
            kaiCommunicator = new MyKaiDefaultBuilder<FormKaiCommunicator>(pArgs).Build();
            kaiCommunicator.ManagerID = (2);

            return kaiCommunicator;
        }

        private void MakeGesture2DCapture()
        {
            int ViewPortWidth = facade.ComponentHolder.gestureCursorParams.ViewPortSize.Width;
            int ViewPortHeight = facade.ComponentHolder.gestureCursorParams.ViewPortSize.Height;

            facade.ComponentHolder.gesture2DCapture = new BuilderOfGesture2DCapture()
                                                         .WithNewQuery()
                                                         .WithNewGet()
                                                         .WithGestureCapturingOn(false)
                                                         .WithNewBitmaps(ViewPortWidth, ViewPortHeight)
                                                         .Build();
        }

        private void MakeGestureCursor()
        {
            facade.ComponentHolder.gesture2DCapture.BuildGestureCursor(facade.ComponentHolder.gestureCursorParams);
        }

        void MakeGestureCursorView()
        {
            Graphics drawControlGraphics = ((Control)(facade.ComponentHolder.gestureViewControl)).CreateGraphics();
            facade.ComponentHolder.gesture2DCapture.BuildGestureCursorView((Control)(facade.ComponentHolder.gestureViewControl), drawControlGraphics);
        }
    }
}
