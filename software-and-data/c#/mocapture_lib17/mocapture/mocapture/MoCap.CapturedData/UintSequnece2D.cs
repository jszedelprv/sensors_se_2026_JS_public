using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.CapturedData
{
    public class UintSequnece2D : FrameNDSequence<uint>, IBoundingRectProvider
    {
        public (int X, int Y, int Width, int Height) GetBoundingRectangleOfSinglePointFrame()
        {
            var points = GetCloudOfPoints();
            if (points == null || points.Count < 2) // at least two points are needed to define a rectangle
                return (0, 0, 0, 0);

            uint minX = uint.MaxValue, minY = uint.MaxValue, maxX = uint.MinValue, maxY = uint.MinValue;

            foreach (var pt in points)
            {
                // Assumes 2D points: Coordinates[0] = X, Coordinates[1] = Y
                var x = Convert.ToUInt32(pt.Coordinates[0]);
                var y = Convert.ToUInt32(pt.Coordinates[1]);

                if (x < minX) minX = x;
                if (y < minY) minY = y;
                if (x > maxX) maxX = x;
                if (y > maxY) maxY = y;
            }

            int width = (int)(maxX - minX);
            int height = (int)(maxY - minY);

            return ((int)minX-2, (int)minY-2, width+5, height+5); // TODO : remove this magic numbers
        }

        public List<PointND<uint>> AsSequenceOf2DPoints()
        {
            List<PointND<uint>> pointSequence = new List<PointND<uint>>();

            foreach (var frame in Frames)
            {
                if (frame.Points != null && frame.Points.Count > 0)
                {
                    PointND<uint> sequencePoint = frame.Points[0]; // Assuming we take the first point in each frame for the gesture
                    
                    uint x = sequencePoint.Coordinates[0];
                    uint y = sequencePoint.Coordinates[1];

                    PointND<uint> newPoint = new PointND<uint>(2);
                    newPoint.Coordinates[0] = x;
                    newPoint.Coordinates[1] = y;

                    pointSequence.Add(newPoint);
                }
            }

            return pointSequence;
        }

        public void ApplyLowPassFilter(double pMinDiagonalRatio, int pNumberOfEndingPoints)
        {
            List<PointND<uint>> points = AsSequenceOf2DPoints();
            if (points.Count < 2)
                return; // Not enough points to apply filtering

            if (points.Count < pNumberOfEndingPoints)
                return; // Still not enough points to apply filtering

            var boundingRectangle = GetBoundingRectangleOfSinglePointFrame();
            
            double diagonal = Math.Sqrt(boundingRectangle.Width * boundingRectangle.Width + boundingRectangle.Height * boundingRectangle.Height);
            double minLength = diagonal * pMinDiagonalRatio;

            var newFrames = new List<FrameND<uint>>();
            newFrames.AddRange(Frames.Take(points.Count - pNumberOfEndingPoints)); // Keep not filtered part

            // Apply filtering to the ending points
            for (int i = points.Count - pNumberOfEndingPoints; i < points.Count - 1; i++)
            {
                double segmentLength = points[i].DistanceTo(points[i + 1]);

                if (segmentLength >= minLength)
                {
                    newFrames.Add(Frames[i]);
                }
            }

            // Optionally, add the last frame to preserve the endpoint
            if (newFrames.Count > 0 && newFrames.Last() != Frames.Last())
                newFrames.Add(Frames.Last());

            Frames.Clear();
            Frames = newFrames;
        }

        public UintPoint2D[] GetPointsArrayOfSinglePointFrame()
        {
            List<UintPoint2D> pointsArray = new List<UintPoint2D>();
            foreach (var frame in Frames)
            {
                if (frame.Points != null && frame.Points.Count > 0)
                {
                    pointsArray.Add(frame.Points[0] as UintPoint2D); // Assuming we take the first point in each frame for the gesture
                }
            }
            return pointsArray.ToArray();
        }
    }
}
