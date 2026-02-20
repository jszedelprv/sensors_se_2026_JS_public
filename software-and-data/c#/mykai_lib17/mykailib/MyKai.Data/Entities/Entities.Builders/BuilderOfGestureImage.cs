using MoCap.Gesture;
using MyKai.Gesture;
using System;
using System.Drawing;
using System.IO;

namespace MyKai.Data.Entities
{
    public class BuilderOfGestureImage : KaiDataBuilderBase<GestureImage>
    {
        public BuilderOfGestureImage()
        {
        }

        public BuilderOfGestureImage WithName(string pName)
        {
            instance.Name = pName;
            return this;
        }

        public BuilderOfGestureImage WithFullName(string pFullName)
        {
            instance.ImageFileFullName = pFullName;
            return this;
        }

        public BuilderOfGestureImage WithSamplesDirectoryName(string pSamplesDirectory)
        {
            instance.SamplesDirectory = pSamplesDirectory;

            return this;
        }

        public BuilderOfGestureImage WithImageRead()
        {
            using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(instance.ImageFileFullName)))
            {
                if (instance.GestureImage != null)
                    instance.GestureImage.Dispose();

                instance.GestureImage = Image.FromStream(memoryStream);
            }

            return this;
        }

        public BuilderOfGestureImage WithTrailImageClone(Image pTrailImage)
        {
            if (instance.GestureImage != null)
                instance.GestureImage.Dispose();
            
            instance.GestureImage = (Image)pTrailImage.Clone();

            return this;
        }

        public BuilderOfGestureImage WithBezierImageClone(Image pBezierImage)
        {
            instance.BezierImage = (Image)pBezierImage.Clone();

            return this;
        }

        public BuilderOfGestureImage WithGesturePoints(UintGesture2D pGesture)
        {
            Gesture2DSequenceToPointConverter converter = new Gesture2DSequenceToPointConverter();
            Point[] points = converter.ConvertToPointArray(pGesture);
            instance.GesturePoints = new Point[points.Length];

            Array.Copy(points, instance.GesturePoints, points.Length);

            return this;
        }
    }
}
