using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.CapturedData
{
    public class FrameNDSequence<T>
    {
        public List<FrameND<T>> Frames { get; set; } = new List<FrameND<T>>();
        public int Count => Frames.Count;

        public void ClearFrames()
        {
            foreach (var frame in Frames)
            {
                frame.ClearPoints();
            }

            Frames.Clear();
        }

        protected List<PointND<T>> GetCloudOfPoints()
        {
            List<PointND<T>> pointsCloud = new List<PointND<T>>();
            foreach (var frame in Frames)
            {
                if (frame.Points != null && frame.Points.Count > 0)
                {
                    pointsCloud.AddRange(frame.Points);
                }
            }
            return pointsCloud;
        }
    }
}
