using System;
using System.Diagnostics;
using System.Windows.Forms;
using Kai.Module;
using MyKai.Properties;
using Microsoft.Win32;

namespace MyKai.Manager
{
    public static partial class KaiSession
    {
        // Session state property types
        private enum KaiSessionStateType { None = 0, NotRunning, Running }
        private enum KaiSDKConnectionStateType { Disconnected = 0, Initialized, Connected }
        private enum SensorStateType { Disconnected = 0, Connected }
        private enum AcquisitionStateType { On = 0, Off }
        private enum CapabilityStateType { None = 0, Reset, Set }

        public static bool KaiSDKAuthenticated { get => KaiSDK.Authenticated; }

        // Session state variables
        static KaiSessionStateType kaiSessionState = KaiSessionStateType.None;
        static KaiSessionStateType kaiSessionPreviousState = KaiSessionStateType.None;

        static KaiSDKConnectionStateType SDKconnectionState = KaiSDKConnectionStateType.Disconnected;
        static SensorStateType sensorState = SensorStateType.Disconnected;
        static AcquisitionStateType acquisitionState = AcquisitionStateType.Off;
        static CapabilityStateType capabilityState = CapabilityStateType.None;

        static bool error = false;
        public static bool Error { get => error; }
  
        static string errorName = "";
        public static string ErrorName { get => errorName; }

        private static bool IsKaiSDKProcessRunning()
        {
            Process[] pname = Process.GetProcessesByName("Kai.SDK");
            return pname.Length != 0;
        }
        
        public static void RUNKaiSDK(ContainerControl pParentControl)
        {
            string kaiSDKRegistrySubkey = MyKaiSettings.Default.kaiManagerKAISDKRegistrySubkey;

            using (RegistryKey kaiSDKProcessName = Registry.CurrentUser.OpenSubKey(kaiSDKRegistrySubkey))
            {
                if (kaiSDKProcessName != null)
                {
                    object keyValue = kaiSDKProcessName.GetValue(MyKaiSettings.Default.kaiManagerKAIDSKProccessName);

                    using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
                    {
                        pProcess.StartInfo.FileName = keyValue.ToString();
                        try
                        {
                            pProcess.Start();
                        }
                        catch
                        {
                            MessageBox.Show(pParentControl, MyKaiSettings.Default.kaiManagerMsgCanNotRunKaiSDK, "Kaibasic: information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // CheckAndUpdateKaiSessionState(); eliminated, because of being an unexpected side effect
                    }
                }
                else
                    MessageBox.Show(pParentControl, MyKaiSettings.Default.kaiManagerMsgCanNotRunKaiSDK, "Kaibasic: information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // State name-to-string converters
        public static string SDKStateToString() => kaiSessionState != KaiSessionStateType.NotRunning ? kaiSessionState.ToString() : "Not running";
        public static string ConnectionStateToString() => SDKconnectionState.ToString();
        public static string SensorStateToString() => sensorState.ToString();
        public static string AcquisitionStateToString() => acquisitionState.ToString();
    }
}
