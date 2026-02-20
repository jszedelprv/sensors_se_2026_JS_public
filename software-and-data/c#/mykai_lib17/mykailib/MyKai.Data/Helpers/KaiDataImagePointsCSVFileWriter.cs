using MyKai.Data.Entities;
using MyKai.Data.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MyKai.Data
{
    internal class KaiDataImagePointsCSVFileWriter : IKaiDataSingleObjectFileWriter
    {
        public void SaveObject(KaiDataObjectBase pObject)
        {
            if ( !(pObject is GestureImage) )
                throw new InvalidKaiDataObjectException(pObject, new GestureImage());

            GestureImage gestureImage = (GestureImage)pObject;
            
            string filePath = gestureImage.PointsFileName();

            DoSavePointsToCsv (filePath, gestureImage.GesturePoints);
        }

        public void PrepareSave(string pFilename)
        {
            try
            {
                File.Delete(pFilename);
            }
            catch (Exception e)
            {
                throw new Exception($"Error deleting image points' file: {pFilename}. {e.Message}");
            }
        }

        private void DoSavePointsToCsv(string filePath, IEnumerable<Point> pPoints)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var point in pPoints)
                {
                    writer.WriteLine($"{point.X}; {point.Y}");
                }
            }
        }
    }
}
