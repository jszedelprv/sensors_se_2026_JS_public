namespace MyKai.Manager
{
    public interface IKaiSDKWatchdog
    {
        UpdateSDKStatusFunctionType UpdateSDKStatusFunction { get; set; }
        void StartWatchdogTimer();
        void StopWatchdogTimer();
    }
}