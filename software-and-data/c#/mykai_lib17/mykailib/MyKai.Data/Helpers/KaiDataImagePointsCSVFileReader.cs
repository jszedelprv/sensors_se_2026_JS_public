using System.Drawing;
using MyKai.Data.Entities;
using MyKai.Data.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyKai.Data
{
    internal class KaiDataImagePointsCSVFileReader : IKaiDataSingleObjectFileReader
    {
        public void ReadObject(KaiDataObjectBase pObject)
        {
            if (!(pObject is GestureImage))
                throw new InvalidKaiDataObjectException(pObject, new GestureImage());

            GestureImage gestureImage = (GestureImage)pObject;

            string filePath = gestureImage.PointsFileName();

            DoReadPointsFromCsv(filePath, gestureImage);
        }

        private void DoReadPointsFromCsv(string pFilePath, GestureImage pGestureImage)
        {
            pGestureImage.GesturePoints = new Point[0];
            IEnumerable<Point> points = pGestureImage.GesturePoints;

            var lines = System.IO.File.ReadAllLines(pFilePath);
            
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0].Trim(), out int x) && int.TryParse(parts[1].Trim(), out int y))
                    {
                        points = points.Append( new Point(x, y) );
                    }
                    else
                        throw new InvalidPointsFileContentException(pFilePath, pGestureImage);
                }
            }

            pGestureImage.GesturePoints = new Point[points.Count()];
            Array.Copy(points.ToArray(), pGestureImage.GesturePoints, points.Count());
        }
    }
}
