
using MoCap.Gesture;
using MyKai.Gesture;
using System.Drawing;

namespace MyKai.General
{
    internal class BuilderOfGesture2DCursorViewWF : MyKaiBuilderBase<Gesture2DCursorViewWF> 
    {
        public BuilderOfGesture2DCursorViewWF() {}

        public BuilderOfGesture2DCursorViewWF WithInitView(WinFormsDrawingParameters pViewParameters)
        {
            instance.InitView(pViewParameters);

            return this;
        }

        public BuilderOfGesture2DCursorViewWF WithViewedCursor(Gesture2DCursorBase pViewedCursor)
        {
            instance.ViewedCursor = pViewedCursor;
            
            return this;
        }

        public BuilderOfGesture2DCursorViewWF WithCaptureGet(IGesture2DCaptureGet pCaptureGet)
        {
            instance.GestureCaptureGet = pCaptureGet;
            return this;
        }

        public BuilderOfGesture2DCursorViewWF WithLocalGesture2DCopy(UintGesture2D pGesture2D)
        {
            instance.localGesture2DCopy = pGesture2D;
            return this;
        }
    }
}
