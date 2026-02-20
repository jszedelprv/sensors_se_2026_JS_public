using System;
using System.Windows.Forms;

using MyKai.Properties;

namespace MyKai.Manager
{
    public delegate void UpdateSDKStatusFunctionType();

    internal class KaiSDKWatchdog : IKaiSDKWatchdog
    {
        public UpdateSDKStatusFunctionType UpdateSDKStatusFunction { get; set; }

        private readonly Timer WatchdogTimer = new Timer();

        public KaiSDKWatchdog()
        {
            WatchdogTimer.Interval = MyKaiSettings.Default.kaiWatchdogTimerInterval;   
            WatchdogTimer.Enabled = true;
            WatchdogTimer.Tick += WatchdogTimer_Tick;
        }

        public void StartWatchdogTimer()
        {
            if (!WatchdogTimer.Enabled)
                WatchdogTimer.Start();
        }

        public void StopWatchdogTimer()
        {
            if (WatchdogTimer.Enabled)
                WatchdogTimer.Stop();
        }

        private void WatchdogTimer_Tick(object sender, EventArgs e)
        {
            KaiSession.UpdateKaiSessionState();

            if(KaiSession.Query.HasKaiSessionStageChanged())
                if (KaiSession.Query.IsKaiSessionInNotRunningState())
                {
                    UpdateSDKStatusFunction();
                
                    if (KaiSession.Query.HasKaiSessionStageChanged())
                        MessageBox.Show(MyKaiSettings.Default.kaiSDKWasStopped, "Kaibasic: information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (KaiSession.Query.IsKaiSessionInRunningState())
                    {
                        UpdateSDKStatusFunction();
                    }
        }
    }
}