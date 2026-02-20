
using MyKai.Data.Attributes;
using MyKai.General;
using MyKai.Gesture;
using MyKai.GUI;

namespace kaibasic
{
    partial class FrmMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttConnParams = new System.Windows.Forms.ToolTip(this.components);
            this.tbProcessSecret = new System.Windows.Forms.TextBox();
            this.tbProcessName = new System.Windows.Forms.TextBox();
            this.ttTraceParams = new System.Windows.Forms.ToolTip(this.components);
            this.cbReducePYRENumber = new System.Windows.Forms.CheckBox();
            this.cbReduceQENumber = new System.Windows.Forms.CheckBox();
            this.clbCapabilities = new System.Windows.Forms.CheckedListBox();
            this.pnUp = new System.Windows.Forms.Panel();
            this.gbCapabilities = new System.Windows.Forms.GroupBox();
            this.nudReducePYREvNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudReduceQEvNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lbAcquisitionStatus = new System.Windows.Forms.Label();
            this.lbSensorStatus = new System.Windows.Forms.Label();
            this.lbSDKConnectionStatus = new System.Windows.Forms.Label();
            this.lbSDKStatus = new System.Windows.Forms.Label();
            this.bRunSDK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bPause = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spMain = new System.Windows.Forms.Splitter();
            this.pnMainBottom = new System.Windows.Forms.Panel();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tpMessagesNew = new System.Windows.Forms.TabPage();
            this.ucKaiLoggingMainForm = new kaibasic.Forms.KaiMessageLogUserControlLocal();
            this.tpRawData = new System.Windows.Forms.TabPage();
            this.ucRawData = new kaibasic.FrmMainRawData();
            this.tpVisualize = new System.Windows.Forms.TabPage();
            this.gbPYRValues = new System.Windows.Forms.GroupBox();
            this.cbVisualizePYRData = new System.Windows.Forms.CheckBox();
            this.bStartPYRVisualization = new System.Windows.Forms.Button();
            this.cbVisualizeRoll = new System.Windows.Forms.CheckBox();
            this.cbVisualizeYaw = new System.Windows.Forms.CheckBox();
            this.cbVisualizePich = new System.Windows.Forms.CheckBox();
            this.lbPYR_Roll = new System.Windows.Forms.Label();
            this.lbPYR_Yaw = new System.Windows.Forms.Label();
            this.lbPYR_Pitch = new System.Windows.Forms.Label();
            this.spcVisualize = new System.Windows.Forms.SplitContainer();
            this.glcVisualize = new OpenTK.GLControl();
            this.tpGesture2DCapture = new System.Windows.Forms.TabPage();
            this.ucGestures2D = new kaibasic.FrmMainGesture2D();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchOffDesktopModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExitApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.pnUp.SuspendLayout();
            this.gbCapabilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReducePYREvNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReduceQEvNumber)).BeginInit();
            this.gbConnection.SuspendLayout();
            this.pnMainBottom.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tpMessagesNew.SuspendLayout();
            this.tpRawData.SuspendLayout();
            this.tpVisualize.SuspendLayout();
            this.gbPYRValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcVisualize)).BeginInit();
            this.spcVisualize.Panel2.SuspendLayout();
            this.spcVisualize.SuspendLayout();
            this.tpGesture2DCapture.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1920, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "Main menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tbProcessSecret
            // 
            this.tbProcessSecret.Location = new System.Drawing.Point(113, 51);
            this.tbProcessSecret.Name = "tbProcessSecret";
            this.tbProcessSecret.ReadOnly = true;
            this.tbProcessSecret.Size = new System.Drawing.Size(163, 20);
            this.tbProcessSecret.TabIndex = 10;
            this.tbProcessSecret.Text = "qwerty";
            this.ttConnParams.SetToolTip(this.tbProcessSecret, "The \"secret\" password used as an initialization parameter (remark: allways use \"q" +
        "werty\" - hardcoded in SDK).");
            // 
            // tbProcessName
            // 
            this.tbProcessName.Location = new System.Drawing.Point(113, 25);
            this.tbProcessName.Name = "tbProcessName";
            this.tbProcessName.Size = new System.Drawing.Size(163, 20);
            this.tbProcessName.TabIndex = 8;
            this.tbProcessName.Text = "test";
            this.ttConnParams.SetToolTip(this.tbProcessName, "The name of the process used as an initialization parameter (remark: not signific" +
        "ant for tracing).");
            // 
            // cbReducePYRENumber
            // 
            this.cbReducePYRENumber.AutoSize = true;
            this.cbReducePYRENumber.Checked = true;
            this.cbReducePYRENumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReducePYRENumber.Location = new System.Drawing.Point(270, 86);
            this.cbReducePYRENumber.Name = "cbReducePYRENumber";
            this.cbReducePYRENumber.Size = new System.Drawing.Size(174, 17);
            this.cbReducePYRENumber.TabIndex = 12;
            this.cbReducePYRENumber.Text = "Reduce number of PYR events";
            this.ttTraceParams.SetToolTip(this.cbReducePYRENumber, "Use this option to reduce the number of PYR (pitch, yaw, roll) events traced to e" +
        "very N-th (set the N using the up-down number control below).");
            this.cbReducePYRENumber.UseVisualStyleBackColor = true;
            this.cbReducePYRENumber.CheckedChanged += new System.EventHandler(this.cbReducePYRENumber_CheckedChanged);
            // 
            // cbReduceQENumber
            // 
            this.cbReduceQENumber.AutoSize = true;
            this.cbReduceQENumber.Checked = true;
            this.cbReduceQENumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReduceQENumber.Location = new System.Drawing.Point(270, 28);
            this.cbReduceQENumber.Name = "cbReduceQENumber";
            this.cbReduceQENumber.Size = new System.Drawing.Size(202, 17);
            this.cbReduceQENumber.TabIndex = 7;
            this.cbReduceQENumber.Text = "Reduce number of quaternion events";
            this.ttTraceParams.SetToolTip(this.cbReduceQENumber, "Use this option to reduce the number of quaternion events traced to every N-th (s" +
        "et the N using the up-down number control below).");
            this.cbReduceQENumber.UseVisualStyleBackColor = true;
            this.cbReduceQENumber.CheckedChanged += new System.EventHandler(this.cbReduceQENumber_CheckedChanged);
            // 
            // clbCapabilities
            // 
            this.clbCapabilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbCapabilities.FormattingEnabled = true;
            this.clbCapabilities.Items.AddRange(new object[] {
            "GestureData \t\t(M)",
            "LinearFlickData \t\t()",
            "FingerShortcutData \t(M,D)",
            "FingerPositionalData \t()",
            "PYRData \t\t(M,D,V)\t",
            "QuaternionData \t\t(M,D)",
            "AccelerometerData \t()",
            "GyroscopeData \t\t()",
            "MagnetometerData \t()"});
            this.clbCapabilities.Location = new System.Drawing.Point(17, 25);
            this.clbCapabilities.Name = "clbCapabilities";
            this.clbCapabilities.Size = new System.Drawing.Size(240, 152);
            this.clbCapabilities.TabIndex = 0;
            this.clbCapabilities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCapabilities_ItemCheck);
            // 
            // pnUp
            // 
            this.pnUp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnUp.Controls.Add(this.gbCapabilities);
            this.pnUp.Controls.Add(this.gbConnection);
            this.pnUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnUp.Location = new System.Drawing.Point(0, 24);
            this.pnUp.Name = "pnUp";
            this.pnUp.Padding = new System.Windows.Forms.Padding(3);
            this.pnUp.Size = new System.Drawing.Size(1920, 206);
            this.pnUp.TabIndex = 2;
            // 
            // gbCapabilities
            // 
            this.gbCapabilities.BackColor = System.Drawing.Color.Transparent;
            this.gbCapabilities.Controls.Add(this.nudReducePYREvNumber);
            this.gbCapabilities.Controls.Add(this.label4);
            this.gbCapabilities.Controls.Add(this.cbReducePYRENumber);
            this.gbCapabilities.Controls.Add(this.nudReduceQEvNumber);
            this.gbCapabilities.Controls.Add(this.label5);
            this.gbCapabilities.Controls.Add(this.cbReduceQENumber);
            this.gbCapabilities.Controls.Add(this.clbCapabilities);
            this.gbCapabilities.Location = new System.Drawing.Point(429, 7);
            this.gbCapabilities.Name = "gbCapabilities";
            this.gbCapabilities.Size = new System.Drawing.Size(478, 193);
            this.gbCapabilities.TabIndex = 4;
            this.gbCapabilities.TabStop = false;
            this.gbCapabilities.Text = "Capabilities";
            // 
            // nudReducePYREvNumber
            // 
            this.nudReducePYREvNumber.Location = new System.Drawing.Point(333, 109);
            this.nudReducePYREvNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudReducePYREvNumber.Name = "nudReducePYREvNumber";
            this.nudReducePYREvNumber.Size = new System.Drawing.Size(45, 20);
            this.nudReducePYREvNumber.TabIndex = 14;
            this.nudReducePYREvNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudReducePYREvNumber.ValueChanged += new System.EventHandler(this.nudReducePYRENumber_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(267, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Trace every";
            // 
            // nudReduceQEvNumber
            // 
            this.nudReduceQEvNumber.Location = new System.Drawing.Point(333, 51);
            this.nudReduceQEvNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudReduceQEvNumber.Name = "nudReduceQEvNumber";
            this.nudReduceQEvNumber.Size = new System.Drawing.Size(45, 20);
            this.nudReduceQEvNumber.TabIndex = 11;
            this.nudReduceQEvNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudReduceQEvNumber.ValueChanged += new System.EventHandler(this.nudReduceQENumber_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(267, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Trace every";
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.lbAcquisitionStatus);
            this.gbConnection.Controls.Add(this.lbSensorStatus);
            this.gbConnection.Controls.Add(this.lbSDKConnectionStatus);
            this.gbConnection.Controls.Add(this.lbSDKStatus);
            this.gbConnection.Controls.Add(this.bRunSDK);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.bStart);
            this.gbConnection.Controls.Add(this.label6);
            this.gbConnection.Controls.Add(this.bPause);
            this.gbConnection.Controls.Add(this.Label8);
            this.gbConnection.Controls.Add(this.label7);
            this.gbConnection.Controls.Add(this.bConnect);
            this.gbConnection.Controls.Add(this.tbProcessSecret);
            this.gbConnection.Controls.Add(this.label3);
            this.gbConnection.Controls.Add(this.tbProcessName);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Location = new System.Drawing.Point(6, 6);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(417, 193);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "SDK && device connection";
            // 
            // lbAcquisitionStatus
            // 
            this.lbAcquisitionStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbAcquisitionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAcquisitionStatus.ForeColor = System.Drawing.Color.Red;
            this.lbAcquisitionStatus.Location = new System.Drawing.Point(113, 161);
            this.lbAcquisitionStatus.Name = "lbAcquisitionStatus";
            this.lbAcquisitionStatus.Size = new System.Drawing.Size(163, 20);
            this.lbAcquisitionStatus.TabIndex = 26;
            this.lbAcquisitionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSensorStatus
            // 
            this.lbSensorStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbSensorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSensorStatus.ForeColor = System.Drawing.Color.Red;
            this.lbSensorStatus.Location = new System.Drawing.Point(113, 135);
            this.lbSensorStatus.Name = "lbSensorStatus";
            this.lbSensorStatus.Size = new System.Drawing.Size(163, 20);
            this.lbSensorStatus.TabIndex = 25;
            this.lbSensorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSDKConnectionStatus
            // 
            this.lbSDKConnectionStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbSDKConnectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSDKConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lbSDKConnectionStatus.Location = new System.Drawing.Point(113, 109);
            this.lbSDKConnectionStatus.Name = "lbSDKConnectionStatus";
            this.lbSDKConnectionStatus.Size = new System.Drawing.Size(163, 20);
            this.lbSDKConnectionStatus.TabIndex = 24;
            this.lbSDKConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSDKStatus
            // 
            this.lbSDKStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbSDKStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSDKStatus.ForeColor = System.Drawing.Color.Red;
            this.lbSDKStatus.Location = new System.Drawing.Point(113, 83);
            this.lbSDKStatus.Name = "lbSDKStatus";
            this.lbSDKStatus.Size = new System.Drawing.Size(163, 20);
            this.lbSDKStatus.TabIndex = 23;
            this.lbSDKStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bRunSDK
            // 
            this.bRunSDK.Location = new System.Drawing.Point(287, 82);
            this.bRunSDK.Name = "bRunSDK";
            this.bRunSDK.Size = new System.Drawing.Size(123, 22);
            this.bRunSDK.TabIndex = 22;
            this.bRunSDK.Text = "Run Kai SDK service";
            this.bRunSDK.UseVisualStyleBackColor = true;
            this.bRunSDK.Click += new System.EventHandler(this.bRunSDK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "SDK status";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(287, 161);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(58, 22);
            this.bStart.TabIndex = 18;
            this.bStart.Text = "Start >";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Acquisition status";
            // 
            // bPause
            // 
            this.bPause.Enabled = false;
            this.bPause.Location = new System.Drawing.Point(352, 161);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(58, 22);
            this.bPause.TabIndex = 17;
            this.bPause.Text = "Stop []";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(10, 137);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(71, 13);
            this.Label8.TabIndex = 13;
            this.Label8.Text = "Sensor status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "SDK service status";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(287, 108);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(123, 22);
            this.bConnect.TabIndex = 11;
            this.bConnect.Text = "Initialize && connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Process secret";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Process name";
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.spMain.Location = new System.Drawing.Point(0, 230);
            this.spMain.Name = "spMain";
            this.spMain.Size = new System.Drawing.Size(1920, 3);
            this.spMain.TabIndex = 3;
            this.spMain.TabStop = false;
            // 
            // pnMainBottom
            // 
            this.pnMainBottom.Controls.Add(this.tbMain);
            this.pnMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMainBottom.Location = new System.Drawing.Point(0, 233);
            this.pnMainBottom.Name = "pnMainBottom";
            this.pnMainBottom.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnMainBottom.Size = new System.Drawing.Size(1920, 824);
            this.pnMainBottom.TabIndex = 4;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tpMessagesNew);
            this.tbMain.Controls.Add(this.tpRawData);
            this.tbMain.Controls.Add(this.tpVisualize);
            this.tbMain.Controls.Add(this.tpGesture2DCapture);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(2, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Padding = new System.Drawing.Point(3, 3);
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1918, 824);
            this.tbMain.TabIndex = 2;
            // 
            // tpMessagesNew
            // 
            this.tpMessagesNew.Controls.Add(this.ucKaiLoggingMainForm);
            this.tpMessagesNew.Location = new System.Drawing.Point(4, 22);
            this.tpMessagesNew.Name = "tpMessagesNew";
            this.tpMessagesNew.Padding = new System.Windows.Forms.Padding(3);
            this.tpMessagesNew.Size = new System.Drawing.Size(1910, 798);
            this.tpMessagesNew.TabIndex = 4;
            this.tpMessagesNew.Text = "Messages";
            this.tpMessagesNew.UseVisualStyleBackColor = true;
            // 
            // ucKaiLoggingMainForm
            // 
            this.ucKaiLoggingMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKaiLoggingMainForm.IsLoggingOn = true;
            this.ucKaiLoggingMainForm.Location = new System.Drawing.Point(3, 3);
            this.ucKaiLoggingMainForm.Name = "ucKaiLoggingMainForm";
            this.ucKaiLoggingMainForm.Size = new System.Drawing.Size(1904, 792);
            this.ucKaiLoggingMainForm.TabIndex = 0;
            // 
            // tpRawData
            // 
            this.tpRawData.Controls.Add(this.ucRawData);
            this.tpRawData.Location = new System.Drawing.Point(4, 22);
            this.tpRawData.Name = "tpRawData";
            this.tpRawData.Padding = new System.Windows.Forms.Padding(3);
            this.tpRawData.Size = new System.Drawing.Size(1910, 798);
            this.tpRawData.TabIndex = 2;
            this.tpRawData.Text = " Raw event data";
            this.tpRawData.UseVisualStyleBackColor = true;
            // 
            // ucRawData
            // 
            this.ucRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRawData.Location = new System.Drawing.Point(3, 3);
            this.ucRawData.Name = "ucRawData";
            this.ucRawData.Size = new System.Drawing.Size(1904, 792);
            this.ucRawData.TabIndex = 0;
            // 
            // tpVisualize
            // 
            this.tpVisualize.Controls.Add(this.gbPYRValues);
            this.tpVisualize.Controls.Add(this.spcVisualize);
            this.tpVisualize.Location = new System.Drawing.Point(4, 22);
            this.tpVisualize.Name = "tpVisualize";
            this.tpVisualize.Padding = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.tpVisualize.Size = new System.Drawing.Size(1910, 798);
            this.tpVisualize.TabIndex = 1;
            this.tpVisualize.Text = " 3D Visualization ";
            this.tpVisualize.UseVisualStyleBackColor = true;
            // 
            // gbPYRValues
            // 
            this.gbPYRValues.Controls.Add(this.cbVisualizePYRData);
            this.gbPYRValues.Controls.Add(this.bStartPYRVisualization);
            this.gbPYRValues.Controls.Add(this.cbVisualizeRoll);
            this.gbPYRValues.Controls.Add(this.cbVisualizeYaw);
            this.gbPYRValues.Controls.Add(this.cbVisualizePich);
            this.gbPYRValues.Controls.Add(this.lbPYR_Roll);
            this.gbPYRValues.Controls.Add(this.lbPYR_Yaw);
            this.gbPYRValues.Controls.Add(this.lbPYR_Pitch);
            this.gbPYRValues.Location = new System.Drawing.Point(4, 6);
            this.gbPYRValues.Name = "gbPYRValues";
            this.gbPYRValues.Size = new System.Drawing.Size(599, 84);
            this.gbPYRValues.TabIndex = 2;
            this.gbPYRValues.TabStop = false;
            this.gbPYRValues.Text = "PYR based visualization";
            // 
            // cbVisualizePYRData
            // 
            this.cbVisualizePYRData.Location = new System.Drawing.Point(13, 60);
            this.cbVisualizePYRData.Name = "cbVisualizePYRData";
            this.cbVisualizePYRData.Size = new System.Drawing.Size(116, 17);
            this.cbVisualizePYRData.TabIndex = 16;
            this.cbVisualizePYRData.Text = "Visualize PYR data";
            this.cbVisualizePYRData.UseVisualStyleBackColor = true;
            // 
            // bStartPYRVisualization
            // 
            this.bStartPYRVisualization.Enabled = false;
            this.bStartPYRVisualization.Location = new System.Drawing.Point(480, 56);
            this.bStartPYRVisualization.Name = "bStartPYRVisualization";
            this.bStartPYRVisualization.Size = new System.Drawing.Size(113, 22);
            this.bStartPYRVisualization.TabIndex = 15;
            this.bStartPYRVisualization.Tag = "Add function start visualization that would configure FrmMain and MyKai instantly" +
    " for PYR visualization.\nSomething has to be done with the connection state of th" +
    "e application.";
            this.bStartPYRVisualization.Text = "Prepare and start";
            this.bStartPYRVisualization.UseVisualStyleBackColor = true;
            this.bStartPYRVisualization.Click += new System.EventHandler(this.bStartPYRVisualization_Click);
            // 
            // cbVisualizeRoll
            // 
            this.cbVisualizeRoll.AutoSize = true;
            this.cbVisualizeRoll.Checked = true;
            this.cbVisualizeRoll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualizeRoll.Location = new System.Drawing.Point(293, 26);
            this.cbVisualizeRoll.Name = "cbVisualizeRoll";
            this.cbVisualizeRoll.Size = new System.Drawing.Size(58, 17);
            this.cbVisualizeRoll.TabIndex = 14;
            this.cbVisualizeRoll.Text = "Roll (z)";
            this.cbVisualizeRoll.UseVisualStyleBackColor = true;
            // 
            // cbVisualizeYaw
            // 
            this.cbVisualizeYaw.AutoSize = true;
            this.cbVisualizeYaw.Checked = true;
            this.cbVisualizeYaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualizeYaw.Location = new System.Drawing.Point(153, 26);
            this.cbVisualizeYaw.Name = "cbVisualizeYaw";
            this.cbVisualizeYaw.Size = new System.Drawing.Size(70, 17);
            this.cbVisualizeYaw.TabIndex = 13;
            this.cbVisualizeYaw.Text = "Yaw (x!?)";
            this.cbVisualizeYaw.UseVisualStyleBackColor = true;
            // 
            // cbVisualizePich
            // 
            this.cbVisualizePich.AutoSize = true;
            this.cbVisualizePich.Checked = true;
            this.cbVisualizePich.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualizePich.Location = new System.Drawing.Point(13, 26);
            this.cbVisualizePich.Name = "cbVisualizePich";
            this.cbVisualizePich.Size = new System.Drawing.Size(73, 17);
            this.cbVisualizePich.TabIndex = 12;
            this.cbVisualizePich.Text = "Pitch (y!?)";
            this.cbVisualizePich.UseVisualStyleBackColor = true;
            // 
            // lbPYR_Roll
            // 
            this.lbPYR_Roll.BackColor = System.Drawing.SystemColors.Control;
            this.lbPYR_Roll.Location = new System.Drawing.Point(357, 24);
            this.lbPYR_Roll.Name = "lbPYR_Roll";
            this.lbPYR_Roll.Size = new System.Drawing.Size(51, 19);
            this.lbPYR_Roll.TabIndex = 11;
            this.lbPYR_Roll.Text = "0.0";
            this.lbPYR_Roll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPYR_Yaw
            // 
            this.lbPYR_Yaw.BackColor = System.Drawing.SystemColors.Control;
            this.lbPYR_Yaw.Location = new System.Drawing.Point(226, 24);
            this.lbPYR_Yaw.Name = "lbPYR_Yaw";
            this.lbPYR_Yaw.Size = new System.Drawing.Size(51, 19);
            this.lbPYR_Yaw.TabIndex = 9;
            this.lbPYR_Yaw.Text = "0.0";
            this.lbPYR_Yaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPYR_Pitch
            // 
            this.lbPYR_Pitch.BackColor = System.Drawing.SystemColors.Control;
            this.lbPYR_Pitch.Location = new System.Drawing.Point(85, 24);
            this.lbPYR_Pitch.Name = "lbPYR_Pitch";
            this.lbPYR_Pitch.Size = new System.Drawing.Size(51, 19);
            this.lbPYR_Pitch.TabIndex = 7;
            this.lbPYR_Pitch.Text = "0.0";
            this.lbPYR_Pitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spcVisualize
            // 
            this.spcVisualize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVisualize.Location = new System.Drawing.Point(2, 3);
            this.spcVisualize.Name = "spcVisualize";
            this.spcVisualize.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcVisualize.Panel2
            // 
            this.spcVisualize.Panel2.Controls.Add(this.glcVisualize);
            this.spcVisualize.Size = new System.Drawing.Size(1905, 792);
            this.spcVisualize.SplitterDistance = 104;
            this.spcVisualize.TabIndex = 1;
            // 
            // glcVisualize
            // 
            this.glcVisualize.BackColor = System.Drawing.Color.Black;
            this.glcVisualize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glcVisualize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.glcVisualize.Location = new System.Drawing.Point(0, 0);
            this.glcVisualize.Name = "glcVisualize";
            this.glcVisualize.Size = new System.Drawing.Size(1905, 684);
            this.glcVisualize.TabIndex = 1;
            this.glcVisualize.VSync = false;
            this.glcVisualize.Load += new System.EventHandler(this.glcVisualize_Load);
            this.glcVisualize.Paint += new System.Windows.Forms.PaintEventHandler(this.glcVisualize_Paint);
            this.glcVisualize.Resize += new System.EventHandler(this.glcVisualize_Resize);
            // 
            // tpGesture2DCapture
            // 
            this.tpGesture2DCapture.Controls.Add(this.ucGestures2D);
            this.tpGesture2DCapture.Location = new System.Drawing.Point(4, 22);
            this.tpGesture2DCapture.Name = "tpGesture2DCapture";
            this.tpGesture2DCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tpGesture2DCapture.Size = new System.Drawing.Size(1910, 798);
            this.tpGesture2DCapture.TabIndex = 5;
            this.tpGesture2DCapture.Text = "Gesture 2D Capture";
            this.tpGesture2DCapture.UseVisualStyleBackColor = true;
            // 
            // ucGestures2D
            // 
            this.ucGestures2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGestures2D.Location = new System.Drawing.Point(3, 3);
            this.ucGestures2D.Name = "ucGestures2D";
            this.ucGestures2D.Size = new System.Drawing.Size(1904, 792);
            this.ucGestures2D.TabIndex = 0;
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmsMain;
            this.niMain.Icon = ((System.Drawing.Icon)(resources.GetObject("niMain.Icon")));
            this.niMain.Text = "Kaibasic";
            this.niMain.Visible = true;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchOffDesktopModeToolStripMenuItem,
            this.tsmExitApplication});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(187, 48);
            // 
            // switchOffDesktopModeToolStripMenuItem
            // 
            this.switchOffDesktopModeToolStripMenuItem.Name = "switchOffDesktopModeToolStripMenuItem";
            this.switchOffDesktopModeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.switchOffDesktopModeToolStripMenuItem.Text = "S&witch to form mode";
            this.switchOffDesktopModeToolStripMenuItem.Click += new System.EventHandler(this.switchOffDesktopModeToolStripMenuItem_Click);
            // 
            // tsmExitApplication
            // 
            this.tsmExitApplication.Name = "tsmExitApplication";
            this.tsmExitApplication.Size = new System.Drawing.Size(186, 22);
            this.tsmExitApplication.Text = "&Exit application";
            this.tsmExitApplication.Click += new System.EventHandler(this.tsmExitApplication_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1057);
            this.Controls.Add(this.pnMainBottom);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.pnUp);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kai Gesture RE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.pnUp.ResumeLayout(false);
            this.gbCapabilities.ResumeLayout(false);
            this.gbCapabilities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReducePYREvNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReduceQEvNumber)).EndInit();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.pnMainBottom.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tpMessagesNew.ResumeLayout(false);
            this.tpRawData.ResumeLayout(false);
            this.tpVisualize.ResumeLayout(false);
            this.gbPYRValues.ResumeLayout(false);
            this.gbPYRValues.PerformLayout();
            this.spcVisualize.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVisualize)).EndInit();
            this.spcVisualize.ResumeLayout(false);
            this.tpGesture2DCapture.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip ttConnParams;
        private System.Windows.Forms.ToolTip ttTraceParams;
        private System.Windows.Forms.Panel pnUp;
        private System.Windows.Forms.Splitter spMain;
        private System.Windows.Forms.Panel pnMainBottom;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox tbProcessSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpVisualize;
        private System.Windows.Forms.SplitContainer spcVisualize;
        private System.Windows.Forms.GroupBox gbPYRValues;
        private System.Windows.Forms.Label lbPYR_Pitch;
        private System.Windows.Forms.Label lbPYR_Roll;
        private System.Windows.Forms.Label lbPYR_Yaw;
        private System.Windows.Forms.CheckBox cbVisualizePich;
        private System.Windows.Forms.CheckBox cbVisualizeRoll;
        private System.Windows.Forms.CheckBox cbVisualizeYaw;
        private System.Windows.Forms.Button bStartPYRVisualization;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbCapabilities;
        private System.Windows.Forms.NumericUpDown nudReducePYREvNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbReducePYRENumber;
        private System.Windows.Forms.NumericUpDown nudReduceQEvNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbReduceQENumber;
        private System.Windows.Forms.CheckedListBox clbCapabilities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Button bRunSDK;
        private System.Windows.Forms.TabPage tpRawData;

        private System.Windows.Forms.Label lbAcquisitionStatus;
        private System.Windows.Forms.Label lbSensorStatus;
        private System.Windows.Forms.Label lbSDKConnectionStatus;
        private System.Windows.Forms.Label lbSDKStatus;

        private System.Windows.Forms.CheckBox cbVisualizePYRData;
        
        // OpenGL drawing control
        private OpenTK.GLControl glcVisualize;
        private FrmMainRawData ucRawData;
        private FrmMainGesture2D ucGestures2D;
        
        
        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmExitApplication;
        private System.Windows.Forms.ToolStripMenuItem switchOffDesktopModeToolStripMenuItem;
        private System.Windows.Forms.TabPage tpMessagesNew;
        private System.Windows.Forms.TabPage tpGesture2DCapture;
        private Forms.KaiMessageLogUserControlLocal ucKaiLoggingMainForm;
    }
}

