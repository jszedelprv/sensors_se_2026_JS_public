using System;
using System.Collections.Generic;

namespace MoCap.CapturedData
{
    public class FrameND<T>
    {
        public List <PointND<T>> Points = new List<PointND<T>>();
        public DateTime TimeStamp { get; set; }
        public int NumberOFPoints
        {
            get { return Points.Count; }
        }

        public void ClearPoints()
        {
            Points.Clear();
        }
    }
}
