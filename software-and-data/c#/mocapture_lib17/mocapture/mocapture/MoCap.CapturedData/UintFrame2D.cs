
using System.Xml;

namespace MoCap.CapturedData
{
    public class UintFrame2D : FrameND<uint>, IBoundingRectProvider
    {
        public (int X, int Y, int Width, int Height) GetBoundingRectangleOfSinglePointFrame()
        {
            if (Points == null || Points.Count < 2)
                return (0, 0, 0, 0);

            uint minX = Points[0].Coordinates[0];
            uint minY = Points[0].Coordinates[1];
            uint maxX = Points[0].Coordinates[0];
            uint maxY = Points[0].Coordinates[1];

            foreach (var pt in Points)
            {
                var x = pt.Coordinates[0];
                var y = pt.Coordinates[1];

                if (x < minX) minX = x;
                if (y < minY) minY = y;
                if (x > maxX) maxX = x;
                if (y > maxY) maxY = y;
            }

            int width = (int)(maxX - minX);
            int height = (int)(maxY - minY);

            return ((int)minX, (int)minY, width, height);
        }
    }
}
