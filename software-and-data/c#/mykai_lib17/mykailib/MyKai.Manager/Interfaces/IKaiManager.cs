using Kai.Module;
using MyKai.Communicator;
using System;
using System.Windows.Forms;

namespace MyKai.Manager
{
    public interface IKaiManager
    {
        KaiCapabilities ActiveCapabilities { get; set; }

        EventArgs GetLastEventArgsIfType<T>();
        string GetLastEventMessage();
        void InitializeManager(string processName, string processSecret);
        void SetEventDecimation(KaiEventType pKaiEventType, int pFrequency);
        void StartEventAcquisition();
        void StopEventAcquisition();
    }
}