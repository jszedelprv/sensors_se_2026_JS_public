using System;
using System.Drawing;
using System.Collections.Generic;

using MoCap.CapturedData;
using MoCap.Gesture;



namespace MyKai.Gesture
{
    public enum MyKaiGestureDrawingType
    {
        GestureTrail,
        Points,
        Bezier,
        BoundingRectangle,
        TrailBitmap,
        BezierBitmap
    }

    public static class MyKaiGestureDrawingParams
    {
        public static HashSet<MyKaiGestureDrawingType> EnabledPanelDrawingTypes = new HashSet<MyKaiGestureDrawingType>
        {
            MyKaiGestureDrawingType.GestureTrail
        };  

        public static void EnablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
        {
            EnabledPanelDrawingTypes.Add(pDrawingType);
        }

        public static void DisablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
        {
            EnabledPanelDrawingTypes.Remove(pDrawingType);
        }

        public static void ResetPanelDrawingTypes()
        {
            EnabledPanelDrawingTypes.Clear();
        }
    }

    public class Gesture2DDrawer
    {
        // Clear methods
        internal void ClearBitmap(Graphics pGraphics)
        {
            pGraphics.Clear(GestureStyles.ClearColors.Bitmap);
        }

        internal void ClearBitmapColor(Graphics pGraphics, Color pColor)
        {
            pGraphics.Clear(pColor);
        }

        internal static void ClearPanelGraphics(Graphics pGraphics)
        {
            pGraphics.Clear(GestureStyles.ClearColors.Panel);
        }

        // Trail drawing methods
        public void DrawGestureTrailOnBitmap(Bitmap pBitmap, UintGesture2D pGesture)
        {
            Graphics bmpGraphics = Graphics.FromImage(pBitmap);
            DoDrawGestureTrail(bmpGraphics, pGesture, GestureStyles.Trail.TrailPen, GestureStyles.Trail.TrailBrush);

            bmpGraphics.Dispose();
        }

        public void DrawGestureTrailOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
        {
            DoDrawGestureTrail(pGraphics, pGesture, GestureStyles.Trail.TrailPen, GestureStyles.Trail.TrailBrush);
        }

        // Bezier drawing methods
        public void DrawGestureBeziersOnBitmap(Bitmap pBitmap, UintGesture2D pGesture)
        {
            Graphics bmpGraphics = Graphics.FromImage(pBitmap);
            DoDrawGestureBeziers(bmpGraphics, pGesture, GestureStyles.BezierBitmap.BezierPen, GestureStyles.BezierBitmap.BezierBrush, false);

            bmpGraphics.Dispose();
        }

        public void DrawGestureBeziersOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
        {
            DoDrawGestureBeziers(pGraphics, pGesture, GestureStyles.BezierControl.BezierPen, GestureStyles.BezierControl.BezierBrush, true);
        }

        // Points drawing methods
        private void DrawGesturePointsOnBitmap(Bitmap pBitmap, UintGesture2D pGesture)
        {
            Graphics bmpGraphics = Graphics.FromImage(pBitmap);
            DoDrawGesturePoints(bmpGraphics, pGesture, GestureStyles.Points.PointsPen, GestureStyles.Points.PointsBrush);

            bmpGraphics.Dispose();
        }

        public void DrawGesturePointsOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
        {
            DoDrawGesturePoints(pGraphics, pGesture, GestureStyles.Points.PointsPen, GestureStyles.Points.PointsBrush);
        }

        public void DrawGestureBoundingRectangleOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
        {
            var frameSequence = (UintSequnece2D)pGesture;

            (int x, int y, int width, int height) br = frameSequence.GetBoundingRectangleOfSinglePointFrame();

            pGraphics.DrawRectangle(GestureStyles.BoundingRectangle.BoundingRectanglePen, br.x, br.y, br.width - 1, br.height - 1);
        }

        // Private methods
        private void DoDrawGestureTrail(Graphics pGraphics, UintGesture2D pGesture, Pen pPen, Brush pBrush)
        {
            float penWidth = pPen.Width;
            int frameIndex;
            UintPoint2D startingPoint;
            UintPoint2D endingPoint;

            // Note: The UintGesture2D is a 2D gesture that consists of frames with single points
            // In contrast, the frame sequence for Kinect 1 would consist of frames having 18 points

            if (pGesture.Frames.Count < 2)
                return;

            for (frameIndex = 0; frameIndex < pGesture.Frames.Count; frameIndex++)
            {
                if (frameIndex > 0)
                {
                    startingPoint = (UintPoint2D)pGesture.Frames[frameIndex - 1].Points[0];
                    endingPoint = (UintPoint2D)pGesture.Frames[frameIndex].Points[0]; // once again, the frame has only one point

                    pGraphics.DrawLine(pPen, startingPoint.X, startingPoint.Y, endingPoint.X, endingPoint.Y);
                    pGraphics.FillEllipse(pBrush, startingPoint.X - penWidth / 2, startingPoint.Y - penWidth / 2, penWidth, penWidth);
                }
            }
        }

        private void DoDrawGesturePoints(Graphics pGraphics, UintGesture2D pGesture, Pen pPen, Brush pBrush)
        {
            int penWidth = (int)pPen.Width;
            UintPoint2D point;

            for (int frameIndex = 0; frameIndex < pGesture.Frames.Count; frameIndex++)
            {
                point = (UintPoint2D)pGesture.Frames[frameIndex].Points[0]; // once again, the frame has only one point
                Rectangle rect = new Rectangle((int)(point.X - GestureStyles.Points.PointSize / 2), 
                                               (int)(point.Y - GestureStyles.Points.PointSize / 2), 
                                               GestureStyles.Points.PointSize, 
                                               GestureStyles.Points.PointSize);
                
                pGraphics.FillEllipse(pBrush, rect);
                pGraphics.DrawEllipse(pPen, rect);
            }
        }

        private void DoDrawGestureBeziers(Graphics pGraphics, UintGesture2D pGesture, Pen pPen, Brush pBrush, bool pXTilt)
        {
            int bezierXTilt = pXTilt ? GestureStyles.BezierControl.BezierXTilt : 0;
            Gesture2DSequenceToPointConverter converter = new Gesture2DSequenceToPointConverter();

            Point[] points = converter.ConvertToPointArray(pGesture);
            Point[] bezierValidatedPoints = PrepareBezierValidPointArray(points, bezierXTilt);

            if (bezierValidatedPoints == null)
                return;

            pGraphics.DrawBeziers(pPen, bezierValidatedPoints);

            for ( int i = 0; i < bezierValidatedPoints.Length; i+=4)
            {
                Rectangle rect = new Rectangle (bezierValidatedPoints[i].X - GestureStyles.BeziersPoints.PointSize / 2, 
                                                bezierValidatedPoints[i].Y - GestureStyles.BeziersPoints.PointSize / 2, 
                                                GestureStyles.BeziersPoints.PointSize, 
                                                GestureStyles.BeziersPoints.PointSize);

                pGraphics.FillEllipse(GestureStyles.BeziersPoints.PointsBrush, rect);
                pGraphics.DrawEllipse(GestureStyles.BeziersPoints.PointsPen, rect);
            }
        }

        private Point[] PrepareBezierValidPointArray(Point[] pPointsToValidate, int pBezierXTilt)
        {
            if (pPointsToValidate == null || pPointsToValidate.Length < 4)
                return null;

            if ((pPointsToValidate.Length - 1) % 3 != 0)
            {
                // Trim to the largest valid length: validLength = 1 + 3 * ((points.Length - 1) / 3)
                int validLength = 1 + 3 * ((pPointsToValidate.Length - 1) / 3);

                if (validLength < 4)
                    return null;

                if (validLength != pPointsToValidate.Length)
                {
                    Point[] trimmed = new Point[validLength];
                    Array.Copy(pPointsToValidate, trimmed, validLength);

                    // change the last point of the trimmed array to be the same as the last point of the original one
                    if (trimmed[validLength - 1] != pPointsToValidate[pPointsToValidate.Length - 1])
                        trimmed[validLength - 1] = pPointsToValidate[pPointsToValidate.Length - 1];

                    return AddBezierXTiltToPoints(pBezierXTilt, trimmed);
                }
            }

            return AddBezierXTiltToPoints(pBezierXTilt, pPointsToValidate); // if noting was done, return the unchanged array
        }

        Point[] AddBezierXTiltToPoints(int pXTilt, Point[] pPoints)
        {
            if (pXTilt == 0 || pPoints == null || pPoints.Length == 0)
                return pPoints;

            Point[] tiltedPoints = new Point[pPoints.Length];
            
            for (int i = 0; i < pPoints.Length; i++)
            {
                tiltedPoints[i] = new Point(pPoints[i].X + pXTilt, pPoints[i].Y + pXTilt);
            }
            return tiltedPoints;
        }

        public void DrawBitmapOnGraphics(Graphics pGraphics, Bitmap pBitmap)
        {
            pGraphics.DrawImage(pBitmap, 0, 0);
        }
    }
}