
using System.Drawing;

using MoCap.Gesture;
using MyKai.Gesture;
using MyKai.Data.Entities;

namespace MyKai.Facade
{
    public partial class MyKaiFacade
    {
        public class ActionSubclass
        {
            MyKaiFacade parent;

            public ActionSubclass(MyKaiFacade pParent)
            {
                parent = pParent;
            }

            public void InitKaiConnection(string pProccessName, string pProcessSecret)
            {
                parent.ComponentHolder.kaiMessageLogUserControl.AddInitialLogMessage();
                parent.ComponentHolder.kaiMessageLogUserControl.ActivateConnectionWait();
                parent.ComponentHolder.kaiManager.InitializeManager(pProccessName, pProcessSecret);
            }

            public void EnablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
            {
                parent.ComponentHolder.gesture2DCapture.EnablePanelDrawingType(pDrawingType);
            }

            public void DisablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
            {
                parent.ComponentHolder.gesture2DCapture.DisablePanelDrawingType(pDrawingType);
            }

            public void StartKaiEventAcquisition()
            {
                parent.ComponentHolder.kaiManager.StartEventAcquisition();
            }

            public void StopKaiSDKWatchtogTimer()
            {
                parent.ComponentHolder.kaiSDKWatchdog.StopWatchdogTimer();
            }

            public void StartKaiSDKWatchtogTimer()
            {
                parent.ComponentHolder.kaiSDKWatchdog.StartWatchdogTimer();
            }

            public void ClearGestureBitmaps()
            {
                Gesture2DCapture gesture2DCapture = parent.ComponentHolder.gesture2DCapture as Gesture2DCapture;
                Graphics graphics;

                graphics = Graphics.FromImage(gesture2DCapture.GestureBitmaps.TrailBitmap);
                graphics.Clear(GestureStyles.ClearColors.Bitmap);
                graphics.Dispose();

                graphics = Graphics.FromImage(gesture2DCapture.GestureBitmaps.BezierBitmap);
                graphics.Clear(GestureStyles.ClearColors.Bitmap);
                graphics.Dispose();
            }

            public void RedrawGestureRepresentationOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
            {
                Gesture2DCapture gesture2DCapture = parent.ComponentHolder.gesture2DCapture as Gesture2DCapture;
                gesture2DCapture.RedrawGestureRepresentationOnGraphics(pGraphics, pGesture);
            }

            public void RedrawGestureBitmapsOnGraphics(Graphics pGraphics, GestureImage pGestureImage)
            {
                Gesture2DCapture gesture2DCapture = parent.ComponentHolder.gesture2DCapture as Gesture2DCapture;
                gesture2DCapture.RedrawGestureBitmapsOnGraphics(pGraphics, pGestureImage);
            }
        }
    }
}
