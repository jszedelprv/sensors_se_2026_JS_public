using Kai.Module;

using MyKai.Communicator;
using MyKai.Facade;
using MyKai.GUI;
using MyKai.Manager;
using MyKai.SimpleProfiler;

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kaibasic
{
    public partial class FrmMain : IKaiCommunicable, IKaiLoggingAwareClass
    {
        public MyKaiFacade KaiFacade;

        public IKaiEventLogger KaiEventLogger
        {
            get
            {
                KaiMessageLogUserControl loggingControl = ucKaiLoggingMainForm;
                return loggingControl.KaiEventLogger;
            }
        }

        public IKaiMessageLogUserControl KaiMessageLogUserControl { get => ucKaiLoggingMainForm; }

        // Managing Kai connection and SDK status
        #region

        private void RunKaiSDK()
        {
            KaiSession.RUNKaiSDK(this);
        }

        #endregion

        // IKaiCommunicable interface implementation
        #region

        public void ResponseKaiEvent()
        {
            if (ucKaiLoggingMainForm.IsLoggingOn)
                ucKaiLoggingMainForm.AddLogMessage(KaiFacade.Get.KaiManager.GetLastEventMessage());

            GestureEventArgs geArgs = (GestureEventArgs)KaiFacade.Get.KaiManager.GetLastEventArgsIfType<GestureEventArgs>();
            if (geArgs != null)
                ResponseGestureEvent(geArgs);

            FingerShortcutEventArgs fsArgs = (FingerShortcutEventArgs)KaiFacade.Get.KaiManager.GetLastEventArgsIfType<FingerShortcutEventArgs>();
            if (fsArgs != null)
                ResponseFingerShortcutEvent(fsArgs);

            PYREventArgs pyrArgs = (PYREventArgs)KaiFacade.Get.KaiManager.GetLastEventArgsIfType<PYREventArgs>();
            if (pyrArgs != null)
                ResponsePYREvent(pyrArgs);

            QuaternionEventArgs quaternionArgs = (QuaternionEventArgs)KaiFacade.Get.KaiManager.GetLastEventArgsIfType<QuaternionEventArgs>();
            if (quaternionArgs != null)
                ResponseQuaternionEvent(quaternionArgs);
        }

        public void ResponseSpecialAction()
        {
            if (KaiSession.Query.IsSensorConnected())
                KaiFacade.Action.StartKaiEventAcquisition();

            UpdateKaiStatusControls();
        }

        public ControlResponseDelegateType GetKaiMessagetDelegate()
        {
            return ResponseKaiEvent;
        }

        public ControlResponseDelegateType GetKaiSpecialActionDelegate()
        {
            return ResponseSpecialAction;
        }

        public bool CheckIfFormExists()
        {
            return Application.OpenForms.OfType<FrmMain>().Any(f => f.Visible);
        }

        #endregion

        // Kai event response functions
        #region

        private void ResponseGestureEvent(GestureEventArgs pEventArgs)
        {
            object[] data = { pEventArgs.Gesture };
            ucRawData.AddDataRow(data, "GES");
        }

        private void ResponseFingerShortcutEvent(FingerShortcutEventArgs pFingerShortcutArgs)
        {
            int l, m, r, i;

            l = pFingerShortcutArgs.LittleFinger ? 1 : 0;
            m = pFingerShortcutArgs.MiddleFinger ? 1 : 0;
            r = pFingerShortcutArgs.RingFinger ? 1 : 0;
            i = pFingerShortcutArgs.IndexFinger ? 1 : 0;

            object[] data = { l, m, r, i };

            if (ucRawData.IsRawDataCapturingOn)
                ucRawData.AddDataRow(data, "FSH");
        }

        private void ResponsePYREvent(PYREventArgs pPYREvenArgs)
        {
            float pitch = pPYREvenArgs.Pitch / 180.0f * (float)Math.PI; // y!
            float yaw = -pPYREvenArgs.Yaw / 180.0f * (float)Math.PI;  // x!
            float roll = pPYREvenArgs.Roll / 180.0f * (float)Math.PI; // z

            object[] data = { pitch, yaw, roll };

            if (ucRawData.IsRawDataCapturingOn)
                ucRawData.AddDataRow(data, "PYR");

            if (cbVisualizePYRData.Checked)
            {

                roll *= -1;

                lbPYR_Pitch.Text = pitch.ToString(@"F2");
                lbPYR_Yaw.Text = yaw.ToString(@"F2");
                lbPYR_Roll.Text = roll.ToString(@"F2");

                if (cbVisualizeYaw.Checked)
                    visualizer.CurrentViewParameters.XRotationAngle = yaw;

                if (cbVisualizePich.Checked)
                    visualizer.CurrentViewParameters.YRotationAngle = pitch;

                if (cbVisualizeRoll.Checked)
                    visualizer.CurrentViewParameters.ZRotationAngle = roll;

                visualizer.UpdateView();
            }

            if (ucGestures2D.IsGesture2DCapturingOn)
            {
                KaiFacade.Get.Gesture2DCapture.PerformCaptureProcedureStep(pitch, yaw);

                /* Profiling gesture 2D capture performance
                MyKaiSimpleProfiler.InstantProfiler.Stop();
                MyKaiSimpleProfiler.InstantProfiler.AddMeasurementText();
                MyKaiSimpleProfiler.InstantProfiler.Reset();
                MyKaiSimpleProfiler.InstantProfiler.Start();
                
                ucGestures2D.AddProfilingResult(MyKaiSimpleProfiler.InstantProfiler.GetLastMesurementText());
                */
            }
        }

        private void ResponseQuaternionEvent(QuaternionEventArgs pQuaternionEventArgs)
        {
            object[] data = {   pQuaternionEventArgs.Quaternion.w,
                                pQuaternionEventArgs.Quaternion.x,
                                pQuaternionEventArgs.Quaternion.y,
                                pQuaternionEventArgs.Quaternion.z };

            if (ucRawData.IsRawDataCapturingOn)
                ucRawData.AddDataRow(data, "QUA");
        }

        #endregion

        public void UpdateKaiStatusControls()
        {
            lbSDKConnectionStatus.Text = KaiSession.ConnectionStateToString();
            lbSensorStatus.Text = KaiSession.SensorStateToString();
            lbAcquisitionStatus.Text = KaiSession.AcquisitionStateToString();
            lbSDKStatus.Text = KaiSession.SDKStateToString();

            if (KaiSession.Query.IsSDKConnected())
            {
                bConnect.Enabled = false;
                lbSDKConnectionStatus.ForeColor = Color.DarkGreen;
            }

            if (KaiSession.Query.IsSensorConnected())
            {
                lbSensorStatus.ForeColor = Color.DarkGreen;
                bStartPYRVisualization.Enabled = true;
                ucGestures2D.bPrepareAndStart.Enabled = true;
            }
            else
            {
                lbSensorStatus.ForeColor = Color.Red;
                bStartPYRVisualization.Enabled = false;
                ucGestures2D.bPrepareAndStart.Enabled = false;
            }

            if (KaiSession.Query.IsAcquisitionOn())
            {
                lbAcquisitionStatus.ForeColor = Color.DarkGreen;
                bPause.Enabled = true;
                bStart.Enabled = false;
            }
            else
            {
                lbAcquisitionStatus.ForeColor = Color.Red;
                bPause.Enabled = false;
                bStart.Enabled = true;
            }

            if (KaiSession.Query.IsKaiSessionInRunningState())
            {
                lbSDKStatus.ForeColor = Color.DarkGreen;
                bRunSDK.Enabled = false;
            }
            else
            {
                lbSDKStatus.ForeColor = Color.Red;
                bRunSDK.Enabled = true;
            }
        }

    }
}