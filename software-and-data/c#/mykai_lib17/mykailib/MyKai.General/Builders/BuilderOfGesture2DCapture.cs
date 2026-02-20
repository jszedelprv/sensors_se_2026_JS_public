
using MyKai.Gesture;
using System.Drawing;

namespace MyKai.General
{
    internal class BuilderOfGesture2DCapture : MyKaiBuilderBase<Gesture2DCapture>
    {
        public BuilderOfGesture2DCapture()
        {
        }

        public override bool IsInstanceBuildComplette()
        {
            bool res = true;

            res &= ((IGesture2DCapture)instance).Query != null;
            res &= ((IGesture2DCapture)instance).Get != null;
            res &= instance.Gesture != null;

            return res;
        }

        public BuilderOfGesture2DCapture WithGestureCapturingOn(bool pGestureCapruringOn)
        {
            if (pGestureCapruringOn) 
                instance.SwitchGestureCapturingOn();
            else
                instance.SwitchGestureCapturingOff();
            
            return this;
        }

        public BuilderOfGesture2DCapture WithNewQuery()
        {
            ((IGesture2DCapture)instance).Query = new Gesture2DCapture.Gesture2DCaptureQuery(instance);

            return this;
        }

        public BuilderOfGesture2DCapture WithNewGet()
        {
            ((IGesture2DCapture)instance).Get = new Gesture2DCapture.Gesture2DCaptureGet(instance);
            
            return this;
        }

        public BuilderOfGesture2DCapture WithNewBitmaps(int pViewPortWidth, int pViewPortHeight)
        {
            instance.GestureBitmaps.TrailBitmap = new Bitmap(pViewPortWidth, pViewPortHeight);
            instance.GestureBitmaps.BezierBitmap = new Bitmap(pViewPortWidth, pViewPortHeight);

            return this;
        }
    }
}
