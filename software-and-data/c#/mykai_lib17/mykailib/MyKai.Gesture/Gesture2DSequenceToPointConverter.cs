using MoCap.CapturedData;
using MoCap.Gesture;
using System.Drawing;

namespace MyKai.Gesture
{
    internal class Gesture2DSequenceToPointConverter
    {
        public Point[] ConvertToPointArray(UintGesture2D pGesture)
        {
            int frameIndex;
            
            Point[] pointsArray = new Point[pGesture.Frames.Count];

            for (frameIndex = 0; frameIndex < pGesture.Frames.Count; frameIndex++)
            {
                UintPoint2D pt = (UintPoint2D)pGesture.Frames[frameIndex].Points[0]; // once again, the frame has only one point
                pointsArray[frameIndex] = new Point((int)pt.X, (int)pt.Y);
            }

            return pointsArray;
        }
    }
}
