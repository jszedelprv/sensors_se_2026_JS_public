namespace MyKai.Manager
{
    public partial class KaiSession
    {
        public class Query
        {
            public static bool IsSDKConnected() => SDKconnectionState == KaiSDKConnectionStateType.Connected;
            public static bool IsSDKDisconnected() => SDKconnectionState == KaiSDKConnectionStateType.Disconnected;
            public static bool IsSDKInitialized() => SDKconnectionState == KaiSDKConnectionStateType.Initialized;

            public static bool IsSensorConnected() => sensorState == SensorStateType.Connected;
            public static bool CanEnterSensorConnected()
                => SDKconnectionState == KaiSDKConnectionStateType.Connected &&
                   (sensorState == SensorStateType.Disconnected);
            public static bool CanEnterSensorDisconnected()
                => SDKconnectionState == KaiSDKConnectionStateType.Connected &&
                   (sensorState == SensorStateType.Connected);

            public static bool IsAcquisitionOn() => acquisitionState == AcquisitionStateType.On;
            public static bool IsKaiSessionInRunningOrUnsetState()
                => kaiSessionState == KaiSessionStateType.None || kaiSessionState == KaiSessionStateType.Running;
            public static bool IsKaiSessionStateSet()
                => kaiSessionState == KaiSessionStateType.NotRunning || kaiSessionState == KaiSessionStateType.Running;
            public static bool IsKaiSessionInRunningState() => kaiSessionState == KaiSessionStateType.Running;

            public static bool IsKaiSessionInNotRunningState() => kaiSessionState == KaiSessionStateType.NotRunning;

            public static bool HasKaiSessionStageChanged() => kaiSessionState != kaiSessionPreviousState;
        }
    }
}
