//
// Kai basic - FrmMain.cs
//

using System;
using System.Windows.Forms;
using System.Drawing;

using Kai.Module;

using ShapeVisualizer;
using MyKai.Manager;
using MyKai.Gesture;
using MyKai.Facade;

namespace kaibasic
{
    public partial class FrmMain : Form
    {

        FrmDesktopMode desktopModeForm;
       
        public GestureViewFormOverlayTest DesktopGestureViewForm;
        GLControlShapeVisualizer visualizer;

        KaiCapabilities currentCapabilities = 0;

        public bool IsDesktopModeIsOn = false;

        // Messages
        string messagePYRStart;
        string messageTraceOptionsConfigured;
        string messageKaiSDKNotRunning;

        public FrmMain()
        {
            Initializer initializer = new Initializer(this);
            initializer.PerformInitActions();
        }

        private void ExitApplication()
        {
            KaiFacade.Get.KaiManager.StopEventAcquisition();

            niMain.Visible = false; // Remove tray icon before exit
            Application.Exit();
        }

        private void RetrieveSelectedCapabilities()
        {
            int intCap = 1;
            currentCapabilities = 0;

            // Iterate through the list and set cap bites 
            // NOTE: the order of capabilities in the listBox is same as in the enum: KaiCapabilities, 
            // so we can calculate succesive capabilities using an int and multiplication by 2
            foreach ( string itemString in clbCapabilities.Items)
            {
                // Read the check state
                bool isChecked = clbCapabilities.GetItemChecked(clbCapabilities.Items.IndexOf(itemString));

                // If item checked set bite
                if (isChecked)
                    currentCapabilities = currentCapabilities | (KaiCapabilities)intCap;

                // Next capability flag
                intCap *= 2;
            }

            if ( currentCapabilities == 0 )
                ucKaiLoggingMainForm.AddLogMessage($"Current capabilities: (none)");
            else
                ucKaiLoggingMainForm.AddLogMessage($"Current capabilities: {currentCapabilities}");
        }

        private void UncheckAllCapabilityItems()
        {
            for (int i = 0; i < clbCapabilities.Items.Count; i++)
                clbCapabilities.SetItemChecked(i, false);
        }

        private void ConfigureForPYRVisualization()
        {
            cbReducePYRENumber.Checked = true;
            bStartPYRVisualization.Enabled = false;
            cbVisualizePYRData.Checked = true;

            UncheckAllCapabilityItems();

            clbCapabilities.SetItemCheckState(4, CheckState.Checked);
            currentCapabilities = KaiCapabilities.PYRData;

            KaiFacade.Get.KaiManager.StartEventAcquisition();
            UpdateKaiStatusControls();
        }

        public void ConfigureForPYRGestureCapture()
        {
            ucRawData.ConfigureForPYRGestureCapture();

            cbReducePYRENumber.Checked = true;
            nudReducePYREvNumber.Value = 4;

            ucKaiLoggingMainForm.IsLoggingOn = false;

            UncheckAllCapabilityItems();

            clbCapabilities.SetItemCheckState(4, CheckState.Checked);
            currentCapabilities = KaiCapabilities.PYRData;

            KaiFacade.Get.KaiManager.StartEventAcquisition();
            UpdateKaiStatusControls();
        }

        private void CreateAndShowDesktopModeForm()
        {
            desktopModeForm = new FrmDesktopMode(SwitchDesktopCaptureModeOff);
            desktopModeForm.Show();
        }

        private void HideAndDisposeDesktopModeForm()
        {
            if (desktopModeForm != null)
            {
                desktopModeForm.Hide();
                desktopModeForm.Dispose();
                desktopModeForm = null;
            }
        }

        public void SwitchDesktopCaptureModeOn()
        {
            IsDesktopModeIsOn = true;
            this.ShowInTaskbar = false;
            this.Hide();

            KaiFacade.Action.StopKaiSDKWatchtogTimer(); // Stop checking Kai SDK state in the main form

            CreateAndShowDesktopModeForm();
        }

        public void SwitchDesktopCaptureModeOff()
        {
            HideAndDisposeDesktopModeForm();

            IsDesktopModeIsOn = false;
            this.ShowInTaskbar = true;

            KaiFacade.Action.StartKaiSDKWatchtogTimer(); // Start checking Kai SDK state in the main form

            this.Hide(); // Done to make the form visible again (both Hide and Show)
            this.Show();
        }

        internal int GetPYRDecimationFactor()
        {
            if (cbReducePYRENumber.Checked)
                return (int)nudReducePYREvNumber.Value;
            else
                return 0;
        }

        internal void SetPYRDecimationControls(int pDecimationFactor)
        {
            if (pDecimationFactor > 0)
            {
                cbReducePYRENumber.Checked = true;
                nudReducePYREvNumber.Enabled = true;
                nudReducePYREvNumber.Value = pDecimationFactor;
            }
            else
            {
                cbReducePYRENumber.Checked = false;
                nudReducePYREvNumber.Enabled = false;
                nudReducePYREvNumber.Value = 1;
            }
        }

        // ------------------------------------------------------------------------------
        // Form event handlers
        // ------------------------------------------------------------------------------

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UpdateKaiStatusControls();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            visualizer.CleanUpObjects();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KaiFacade.Get.KaiManager.StopEventAcquisition();
            ExitApplication();
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            KaiFacade.Action.InitKaiConnection(tbProcessName.Text, tbProcessSecret.Text);
        }

        private void clbCapabilities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Do a trick to commit the CheckedListBox selection
                var control = (CheckedListBox)sender;
                // Remove handler
                control.ItemCheck -= clbCapabilities_ItemCheck;
                control.SetItemCheckState(e.Index, e.NewValue);
                // Add handler again
                control.ItemCheck += clbCapabilities_ItemCheck;

            // Then set capabilities
            RetrieveSelectedCapabilities();
            KaiFacade.Get.KaiManager.ActiveCapabilities = currentCapabilities;
        }

        private void cbReduceQENumber_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbReduceQENumber.Checked )
            {
                nudReduceQEvNumber.Enabled = true;
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.QuaternionEvent, (int)nudReduceQEvNumber.Value);
            }
            else
            {
                nudReduceQEvNumber.Enabled = false;
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.QuaternionEvent, 0);
            }
        }

        private void nudReduceQENumber_ValueChanged(object sender, EventArgs e)
        {
            if (cbReduceQENumber.Checked)
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.QuaternionEvent, (int)nudReduceQEvNumber.Value);
        }

        private void cbReducePYRENumber_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReducePYRENumber.Checked)
            {
                nudReducePYREvNumber.Enabled = true;
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.PYREvent, (int)nudReducePYREvNumber.Value);
            }
            else
            {
                nudReducePYREvNumber.Enabled = false;
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.PYREvent, 0);
            }
        }
        
        private void nudReducePYRENumber_ValueChanged(object sender, EventArgs e)
        {
            if (cbReducePYRENumber.Checked)
                KaiFacade.Get.KaiManager.SetEventDecimation(KaiEventType.PYREvent, (int)nudReducePYREvNumber.Value);
        }

        private void glcVisualize_Load(object sender, EventArgs e)
        {
            visualizer.GLControlOnLoad();
        }

        private void glcVisualize_Resize(object sender, EventArgs e)
        {
            visualizer.GLControlOnResize();
        }

        private void glcVisualize_Paint(object sender, PaintEventArgs e)
        {
            visualizer.GLControlOnPaint();
        }

        private void bStartPYRVisualization_Click(object sender, EventArgs e)
        {
            MessageBox.Show(messagePYRStart);
            ucKaiLoggingMainForm.AddLogMessage(messageTraceOptionsConfigured);
            ConfigureForPYRVisualization();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            KaiFacade.Get.KaiManager.StartEventAcquisition();
            UpdateKaiStatusControls();
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            KaiFacade.Get.KaiManager.StopEventAcquisition();
            UpdateKaiStatusControls();
        }

        // Disable editing in rbLoggedMessages
        private void rbLoggedMessages_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //private void tmCheckKaiSDK_Tick(object sender, EventArgs e)
        //{
        //    tmCheckKaiSDK.Interval = 1000; // from now check SDK process once a second

        //    if (KaiSession.Query.IsKaiSessionInRunningOrUnsetState())
        //        if (!KaiSession.CheckAndUpdateKaiSessionState())
        //        {
        //            MessageBox.Show(this, messageKaiSDKNotRunning, "Kaibasic: information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            UpdateKaiStatusControls();
        //        }

        //    if (KaiSession.Query.IsKaiSessionStateSet())
        //        if (KaiSession.CheckAndUpdateKaiSessionState())
        //        {
        //            UpdateKaiStatusControls();
        //        }
        //}

        private void bRunSDK_Click(object sender, EventArgs e)
        {
            RunKaiSDK();
        }

        private void tsmExitApplication_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void switchOffDesktopModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchDesktopCaptureModeOff();
        }

        private void tsmCopyImageToClipboard_Click(object sender, EventArgs e)
        {

        }
    }
}
