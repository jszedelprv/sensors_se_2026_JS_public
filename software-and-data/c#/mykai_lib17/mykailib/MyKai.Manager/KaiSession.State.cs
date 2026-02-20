namespace MyKai.Manager
{
    public partial class KaiSession
    {
        public class StateMachine
        {
            public static void Reset()
            {
                SDKconnectionState = KaiSDKConnectionStateType.Disconnected;
                sensorState = SensorStateType.Disconnected;
                acquisitionState = AcquisitionStateType.Off;
                capabilityState = CapabilityStateType.None;
                error = false;
                errorName = "";
            }

            public static void SwitchSDKInitialized()
            {
                if (Query.IsSDKDisconnected())
                    SDKconnectionState = KaiSDKConnectionStateType.Initialized;
                else
                {
                    error = true;
                    errorName = "Initialize error";
                }
            }

            public static void SwitchSDKConnected()
            {
                if (Query.IsSDKInitialized())
                    SDKconnectionState = KaiSDKConnectionStateType.Connected;
                else
                {
                    error = true;
                    errorName = "Connect error";
                }
            }

            public static void SwitchSDKDisonnected()
            {
                if (Query.IsSDKConnected())
                    SDKconnectionState = KaiSDKConnectionStateType.Disconnected;
                else
                {
                    error = true;
                    errorName = "Can not set session disconnected";
                }
            }

            public static void VerifyConnected()
            {
                if (Query.IsSDKConnected() && !KaiSDKAuthenticated)
                {
                    SwitchSDKDisonnected();
                }
            }

            public static void TrySwitchSensorConnected()
            {
                if (Query.CanEnterSensorConnected())
                    sensorState = SensorStateType.Connected;
                else
                {
                    error = true;
                    errorName = "Can not enter responding mode.";
                }
            }
            public static void SwtichSensorDisconnected()
            {
                if (Query.CanEnterSensorDisconnected())
                    sensorState = SensorStateType.Disconnected;
                else
                {
                    error = true;
                    errorName = "Can not enter not responding mode.";
                }
            }

            public static void SwitchCapabilitiesSet()
            {
                if (capabilityState == CapabilityStateType.Reset)
                    capabilityState = CapabilityStateType.Set;
                else
                {
                    error = true;
                    errorName = "Capabilities already set";
                }
            }

            public static void SwichCapabilitiesUnset()
            {
                if (capabilityState == CapabilityStateType.None || capabilityState == CapabilityStateType.Set)
                    capabilityState = CapabilityStateType.Reset;
                else
                {
                    error = true;
                    errorName = "Capabilities already set";
                }
            }

            public static void SwichAcquisitionOn()
            {
                if (!Query.IsAcquisitionOn())
                    acquisitionState = AcquisitionStateType.On;
                else
                {
                    error = true;
                    errorName = "Can not switch acquisition on";
                }
            }

            public static void SwichAcquisitionOnOff()
            {
                if (Query.IsAcquisitionOn())
                    acquisitionState = AcquisitionStateType.Off;
                else
                {
                    error = true;
                    errorName = "Can not switch acquisition Off";
                }
            }
        }

        public static bool CheckAndUpdateKaiSessionState()
        {
            bool res;

            RememberKaiSessionState();

            if (res = IsKaiSDKProcessRunning())
                kaiSessionState = KaiSessionStateType.Running;
            else
            {
                kaiSessionState = KaiSessionStateType.NotRunning;
                StateMachine.Reset();
            }

            return res;
        }

        public static void UpdateKaiSessionState()
        {
            RememberKaiSessionState();

            if (IsKaiSDKProcessRunning())
                kaiSessionState = KaiSessionStateType.Running;
            else
            {
                kaiSessionState = KaiSessionStateType.NotRunning;
                StateMachine.Reset();
            }
        }

        private static void RememberKaiSessionState()
        {
            kaiSessionPreviousState = kaiSessionState;
        }
    }
}
