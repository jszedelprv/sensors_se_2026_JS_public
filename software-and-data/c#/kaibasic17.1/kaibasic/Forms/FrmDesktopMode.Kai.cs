
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Linq;

using Kai.Module;

using MyKai.Communicator;
using MyKai.Facade;
using MyKai.GUI;
using MyKai.Manager;
using MyKai.Gesture;


namespace kaibasic
{
    public partial class FrmDesktopMode : IKaiCommunicable, IKaiLoggingAwareClass, IKaiStateChangedUpdatableClass
    {
        public GestureViewFormOverlay DesktopGestureViewForm;

        // KaiFacade instance for managing Kai-related operations
        public MyKaiFacade KaiFacade;

        // IKaiLoggingAwareClass interface implementation
        #region

        public IKaiEventLogger KaiEventLogger
        {
            get
            {
                KaiMessageLogUserControl loggingControl = ucKaiLoggingDesktopForm;
                return loggingControl.KaiEventLogger;
            }
        }

        public IKaiMessageLogUserControl KaiMessageLogUserControl { get => ucKaiLoggingDesktopForm; }
        
        #endregion


        // IKaiCommunicableForm interface implementation
        #region

        public bool CheckIfFormExists()
        {
            return Application.OpenForms.OfType<FrmDesktopMode>().Any(f => f.Visible);
        }

        public ControlResponseDelegateType GetKaiMessagetDelegate()
        {
            return ResponseKaiEvent;
        }

        public ControlResponseDelegateType GetKaiSpecialActionDelegate()
        {
            return ResponseSpecialAction;
        }

        public void ResponseKaiEvent()
        {
            if (ucKaiLoggingDesktopForm.IsLoggingOn)
                ucKaiLoggingDesktopForm.AddLogMessage(KaiFacade.Get.KaiManager.GetLastEventMessage());
            
            PYREventArgs pyrArgs = (PYREventArgs)KaiFacade.Get.KaiManager.GetLastEventArgsIfType<PYREventArgs>();
            if (pyrArgs != null)
                ResponsePYREvent(pyrArgs);
        }

        private void ResponsePYREvent(PYREventArgs pPYREvenArgs)
        {
            float pitch = pPYREvenArgs.Pitch / 180.0f * (float)Math.PI; // y!
            float yaw = -pPYREvenArgs.Yaw / 180.0f * (float)Math.PI;  // x!
            //float roll = pPYREvenArgs.Roll / 180.0f * (float)Math.PI; // z - roll not used

            KaiFacade.Get.Gesture2DCapture.PerformCaptureProcedureStep(pitch, yaw);
        }

        public void ResponseSpecialAction()
        {
            if (KaiSession.Query.IsSensorConnected())
                KaiFacade.Action.StartKaiEventAcquisition();

            UpdateKaiSensorStatusControls();
        }

        public void ReceiveOnStateChanged(object[] pArgs) // Invoked by KaiControllComunicator
        {
            if (pArgs != null && pArgs.Length == 1)
            {
                tbSegmenterState.Text = pArgs[0].ToString();
            }

            if (KaiFacade.Query.IsCursorInJustEndedState())
            //if (KaiFacade.Get.GestureCursorState == Gesture2DCursorStateMachine.StateType.JustEndedDrawing)
                PerformNewCapturedImageActions();
        }

        private void PerformNewCapturedImageActions()
        {
            StopGestureCapture();
            ClearGestureImage();
            StartGestureCapture();
        }

        private void ClearGestureImage()
        {
            Graphics gr = Graphics.FromImage(KaiFacade.Get.TrailBitmap);
            gr.Clear(Color.Transparent); //TODO: change to GestureStyles.ClearColors.DesktopModeBitmap, interface needed?
            gr.Dispose();
        }

        #endregion


        public void RunKaiSDK()
        {
            try
            {       
                KaiSession.RUNKaiSDK(this);
            }
            catch (Exception ex)
            {
                KaiEventLogger.AddMessage($"Error running Kai SDK: {ex.Message}");
            }

            UpdateKaiSDKStatusControls();
        }

        public void UpdateKaiSDKStatusControls()
        {
            lbSDKState.Text = KaiSession.SDKStateToString();

            if (KaiSession.Query.IsKaiSessionInRunningState())
            {
                lbSDKState.ForeColor = Color.DarkGreen;
                bRunSDK.Enabled = false;
            }
            else
            {
                lbSDKState.ForeColor = Color.Red;
                bRunSDK.Enabled = true;
            }
        }

        public void UpdateKaiSensorStatusControls()
        {
            lbSensorState.Text = KaiSession.SensorStateToString();

            if (KaiSession.Query.IsSensorConnected())
                lbSensorState.ForeColor = Color.DarkGreen;
            else
                lbSensorState.ForeColor = Color.Red;
        }

        public void ConfigureForGestureCapture()
        {
            //ucKaiLoggingDesktopForm.IsLoggingOn = false; // Disable logging
            KaiFacade.Get.KaiManager.StartEventAcquisition();
        }

        private void StartGestureCapture()
        {
            Graphics gr = null;

            gr = ((Control)KaiFacade.Get.GestureViewControl).CreateGraphics();
            gr.Clear(Color.White);

            KaiFacade.Get.KaiManager.ActiveCapabilities = KaiCapabilities.PYRData;
        }

        private void StopGestureCapture()
        {
        }
    }
}
