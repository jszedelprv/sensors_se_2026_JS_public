using System;
using System.Diagnostics;

namespace MyKai.SimpleProfiler
{
    public class MyKaiSimpleProfiler
    {
        public static MyKaiSimpleProfiler InstantProfiler = new MyKaiSimpleProfiler(); // for quick profiler usage

        private Stopwatch stopwatch;
        private System.Collections.Generic.List<string> textList = new System.Collections.Generic.List<string>();

        public MyKaiSimpleProfiler()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
        }

        public void Stop()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        public void AddMeasurementText()
        {
            textList.Add(stopwatch.ElapsedMilliseconds.ToString() + ";");
        }

        public string GetLastMesurementText()
        {
            return textList[textList.Count - 1];
        }

        public void SaveMeasurementTextListToFile(string filePath)
        {
            if ( System.IO.File.Exists(filePath) )
            {
                System.IO.File.Delete(filePath);
            }

            System.IO.File.WriteAllLines(filePath, textList);
        }

        public void ClearMeasurementTextList()
        {
            textList.Clear();
        }

        public TimeSpan Elapsed => stopwatch.Elapsed;

        public double TotalMilliseconds() => stopwatch.Elapsed.TotalMilliseconds;
    }
}
