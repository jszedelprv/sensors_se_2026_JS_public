using MyKai.Data.Attributes;

namespace kaibasic
{
    partial class FrmMainGesture2D
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnTop = new System.Windows.Forms.Panel();
            this.gbDesktopMode = new System.Windows.Forms.GroupBox();
            this.bSwitchToDesktopMode = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbSegmenterState = new System.Windows.Forms.TextBox();
            this.lbSegmenterState = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbIndividualsLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIndividual = new System.Windows.Forms.ComboBox();
            this.cmbImageDataset = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnSpace1 = new System.Windows.Forms.Panel();
            this.gbMessageParams = new System.Windows.Forms.GroupBox();
            this.cbRecordImages = new System.Windows.Forms.CheckBox();
            this.cbCapture2DGestures = new System.Windows.Forms.CheckBox();
            this.bPrepareAndStart = new System.Windows.Forms.Button();
            this.cbOverwriteExistingImages = new System.Windows.Forms.CheckBox();
            this.tbImageCounter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnBotoomRight = new System.Windows.Forms.Panel();
            this.tcCapture = new System.Windows.Forms.TabControl();
            this.tpCapture = new System.Windows.Forms.TabPage();
            this.tcCaptureTabs = new System.Windows.Forms.TabControl();
            this.tpCaptureResults = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rbBitmapBasedDrawingMode = new System.Windows.Forms.RadioButton();
            this.rbPointBasedDrawingMode = new System.Windows.Forms.RadioButton();
            this.gbBitmapDrawingModes = new System.Windows.Forms.GroupBox();
            this.rbDrawBezierBitmap = new System.Windows.Forms.RadioButton();
            this.rbDrawTrailBitmap = new System.Windows.Forms.RadioButton();
            this.gbPointsDrawingModes = new System.Windows.Forms.GroupBox();
            this.cbDrawGesturePoints = new System.Windows.Forms.CheckBox();
            this.cbDrawBoundingRectangle = new System.Windows.Forms.CheckBox();
            this.cbDrawBeziers = new System.Windows.Forms.CheckBox();
            this.cbDrawGesture = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bDeleteSelected = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCapturedGestures = new System.Windows.Forms.ListBox();
            this.bResetCounter = new System.Windows.Forms.Button();
            this.tpGestureCaptureTuning = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtProfilingResult = new System.Windows.Forms.RichTextBox();
            this.bStopInstantProfiling = new System.Windows.Forms.Button();
            this.bStartInstantProfiling = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbLowPassFilterFactor = new System.Windows.Forms.TextBox();
            this.lbLowPassFilterFactor = new System.Windows.Forms.Label();
            this.lbNumberOfPoints_filtering = new System.Windows.Forms.Label();
            this.nudNumberOfPoints_Filtering = new System.Windows.Forms.NumericUpDown();
            this.cbApplyLoPasFilterOnEnding = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nudMaxStabilizingCounterValue = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbDrawingMode = new System.Windows.Forms.GroupBox();
            this.rbDrawOnTargetControlPaint = new System.Windows.Forms.RadioButton();
            this.rbEraseAndDrawOnCapture = new System.Windows.Forms.RadioButton();
            this.nudMinStabilizingMarkRadius = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStandardCursorSize = new System.Windows.Forms.NumericUpDown();
            this.nudCrossmarkSize = new System.Windows.Forms.NumericUpDown();
            this.nudStabilizingCrossmarkSizeInterval = new System.Windows.Forms.NumericUpDown();
            this.nudMaxStabilizingMarkRadius = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudRedrawMargin = new System.Windows.Forms.NumericUpDown();
            this.pnGestureDraw = new System.Windows.Forms.Panel();
            this.cmsImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tscCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tpDatasetLookup = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnBottomLeft = new System.Windows.Forms.Panel();
            this.lbDrawnOwnGesture = new System.Windows.Forms.Label();
            this.cmbOwnGesture = new System.Windows.Forms.ComboBox();
            this.cbOwnGesture = new System.Windows.Forms.CheckBox();
            this.tbPatternClassLabel = new System.Windows.Forms.TextBox();
            this.pbGesturePattern = new System.Windows.Forms.PictureBox();
            this.cmbGesturePattern = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnTop.SuspendLayout();
            this.gbDesktopMode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbMessageParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnBotoomRight.SuspendLayout();
            this.tcCapture.SuspendLayout();
            this.tpCapture.SuspendLayout();
            this.tcCaptureTabs.SuspendLayout();
            this.tpCaptureResults.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbBitmapDrawingModes.SuspendLayout();
            this.gbPointsDrawingModes.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpGestureCaptureTuning.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPoints_Filtering)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStabilizingCounterValue)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbDrawingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStabilizingMarkRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStandardCursorSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossmarkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStabilizingCrossmarkSizeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStabilizingMarkRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRedrawMargin)).BeginInit();
            this.cmsImage.SuspendLayout();
            this.pnBottomLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGesturePattern)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.gbDesktopMode);
            this.pnTop.Controls.Add(this.panel3);
            this.pnTop.Controls.Add(this.groupBox5);
            this.pnTop.Controls.Add(this.panel2);
            this.pnTop.Controls.Add(this.groupBox2);
            this.pnTop.Controls.Add(this.pnSpace1);
            this.pnTop.Controls.Add(this.gbMessageParams);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1904, 81);
            this.pnTop.TabIndex = 8;
            // 
            // gbDesktopMode
            // 
            this.gbDesktopMode.Controls.Add(this.bSwitchToDesktopMode);
            this.gbDesktopMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbDesktopMode.Location = new System.Drawing.Point(984, 0);
            this.gbDesktopMode.Name = "gbDesktopMode";
            this.gbDesktopMode.Size = new System.Drawing.Size(369, 81);
            this.gbDesktopMode.TabIndex = 30;
            this.gbDesktopMode.TabStop = false;
            this.gbDesktopMode.Text = "Desktop capture mode";
            // 
            // bSwitchToDesktopMode
            // 
            this.bSwitchToDesktopMode.Location = new System.Drawing.Point(18, 23);
            this.bSwitchToDesktopMode.Name = "bSwitchToDesktopMode";
            this.bSwitchToDesktopMode.Size = new System.Drawing.Size(137, 23);
            this.bSwitchToDesktopMode.TabIndex = 0;
            this.bSwitchToDesktopMode.Text = "Switch to desktop mode";
            this.bSwitchToDesktopMode.UseVisualStyleBackColor = true;
            this.bSwitchToDesktopMode.Click += new System.EventHandler(this.bSwitchToDesktopMode_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(978, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(6, 81);
            this.panel3.TabIndex = 29;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbSegmenterState);
            this.groupBox5.Controls.Add(this.lbSegmenterState);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(681, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 81);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Capture details";
            // 
            // tbSegmenterState
            // 
            this.tbSegmenterState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSegmenterState.Location = new System.Drawing.Point(105, 23);
            this.tbSegmenterState.Name = "tbSegmenterState";
            this.tbSegmenterState.Size = new System.Drawing.Size(149, 20);
            this.tbSegmenterState.TabIndex = 3;
            // 
            // lbSegmenterState
            // 
            this.lbSegmenterState.AutoSize = true;
            this.lbSegmenterState.Location = new System.Drawing.Point(15, 25);
            this.lbSegmenterState.Name = "lbSegmenterState";
            this.lbSegmenterState.Size = new System.Drawing.Size(84, 13);
            this.lbSegmenterState.TabIndex = 2;
            this.lbSegmenterState.Text = "Segmenter state";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(675, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 81);
            this.panel2.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbIndividualsLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbIndividual);
            this.groupBox2.Controls.Add(this.cmbImageDataset);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(257, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 81);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Files";
            // 
            // tbIndividualsLabel
            // 
            this.tbIndividualsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbIndividualsLabel.Location = new System.Drawing.Point(294, 50);
            this.tbIndividualsLabel.Name = "tbIndividualsLabel";
            this.tbIndividualsLabel.ReadOnly = true;
            this.tbIndividualsLabel.Size = new System.Drawing.Size(64, 20);
            this.tbIndividualsLabel.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Individual";
            // 
            // cmbIndividual
            // 
            this.cmbIndividual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIndividual.FormattingEnabled = true;
            this.cmbIndividual.Location = new System.Drawing.Point(74, 49);
            this.cmbIndividual.Name = "cmbIndividual";
            this.cmbIndividual.Size = new System.Drawing.Size(214, 21);
            this.cmbIndividual.TabIndex = 27;
            this.cmbIndividual.SelectedIndexChanged += new System.EventHandler(this.cbIndividual_SelectedIndexChanged);
            // 
            // cmbImageDataset
            // 
            this.cmbImageDataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageDataset.FormattingEnabled = true;
            this.cmbImageDataset.Location = new System.Drawing.Point(74, 21);
            this.cmbImageDataset.Name = "cmbImageDataset";
            this.cmbImageDataset.Size = new System.Drawing.Size(214, 21);
            this.cmbImageDataset.TabIndex = 26;
            this.cmbImageDataset.SelectedIndexChanged += new System.EventHandler(this.cbDataset_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Datset";
            // 
            // pnSpace1
            // 
            this.pnSpace1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSpace1.Location = new System.Drawing.Point(251, 0);
            this.pnSpace1.Name = "pnSpace1";
            this.pnSpace1.Size = new System.Drawing.Size(6, 81);
            this.pnSpace1.TabIndex = 3;
            // 
            // gbMessageParams
            // 
            this.gbMessageParams.Controls.Add(this.cbRecordImages);
            this.gbMessageParams.Controls.Add(this.cbCapture2DGestures);
            this.gbMessageParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbMessageParams.Location = new System.Drawing.Point(0, 0);
            this.gbMessageParams.Name = "gbMessageParams";
            this.gbMessageParams.Size = new System.Drawing.Size(251, 81);
            this.gbMessageParams.TabIndex = 1;
            this.gbMessageParams.TabStop = false;
            this.gbMessageParams.Text = "Options";
            // 
            // cbRecordImages
            // 
            this.cbRecordImages.AutoSize = true;
            this.cbRecordImages.Checked = true;
            this.cbRecordImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecordImages.Location = new System.Drawing.Point(12, 48);
            this.cbRecordImages.Name = "cbRecordImages";
            this.cbRecordImages.Size = new System.Drawing.Size(97, 17);
            this.cbRecordImages.TabIndex = 1;
            this.cbRecordImages.Text = "Record images";
            this.cbRecordImages.UseVisualStyleBackColor = true;
            // 
            // cbCapture2DGestures
            // 
            this.cbCapture2DGestures.AutoSize = true;
            this.cbCapture2DGestures.Location = new System.Drawing.Point(12, 25);
            this.cbCapture2DGestures.Name = "cbCapture2DGestures";
            this.cbCapture2DGestures.Size = new System.Drawing.Size(123, 17);
            this.cbCapture2DGestures.TabIndex = 0;
            this.cbCapture2DGestures.Text = "Capture 2D gestures";
            this.cbCapture2DGestures.UseVisualStyleBackColor = true;
            // 
            // bPrepareAndStart
            // 
            this.bPrepareAndStart.Enabled = false;
            this.bPrepareAndStart.Location = new System.Drawing.Point(16, 22);
            this.bPrepareAndStart.Name = "bPrepareAndStart";
            this.bPrepareAndStart.Size = new System.Drawing.Size(98, 22);
            this.bPrepareAndStart.TabIndex = 17;
            this.bPrepareAndStart.Tag = "Add function start visualization that would configure FrmMain and MyKai instantly" +
    " for PYR visualization.\nSomething has to be done with the connection state of th" +
    "e application.";
            this.bPrepareAndStart.Text = "Prepare and start";
            this.bPrepareAndStart.UseVisualStyleBackColor = true;
            this.bPrepareAndStart.Click += new System.EventHandler(this.bStartPYRGestureCapture_Click);
            // 
            // cbOverwriteExistingImages
            // 
            this.cbOverwriteExistingImages.AutoSize = true;
            this.cbOverwriteExistingImages.Location = new System.Drawing.Point(124, 60);
            this.cbOverwriteExistingImages.Name = "cbOverwriteExistingImages";
            this.cbOverwriteExistingImages.Size = new System.Drawing.Size(130, 17);
            this.cbOverwriteExistingImages.TabIndex = 24;
            this.cbOverwriteExistingImages.Text = "Overwrite existing files";
            this.cbOverwriteExistingImages.UseVisualStyleBackColor = true;
            // 
            // tbImageCounter
            // 
            this.tbImageCounter.Location = new System.Drawing.Point(112, 15);
            this.tbImageCounter.Name = "tbImageCounter";
            this.tbImageCounter.Size = new System.Drawing.Size(61, 20);
            this.tbImageCounter.TabIndex = 23;
            this.tbImageCounter.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Image file number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnBotoomRight);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.pnBottomLeft);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1904, 711);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // pnBotoomRight
            // 
            this.pnBotoomRight.Controls.Add(this.tcCapture);
            this.pnBotoomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBotoomRight.Location = new System.Drawing.Point(675, 13);
            this.pnBotoomRight.Name = "pnBotoomRight";
            this.pnBotoomRight.Size = new System.Drawing.Size(1224, 693);
            this.pnBotoomRight.TabIndex = 5;
            // 
            // tcCapture
            // 
            this.tcCapture.Controls.Add(this.tpCapture);
            this.tcCapture.Controls.Add(this.tpDatasetLookup);
            this.tcCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCapture.Location = new System.Drawing.Point(0, 0);
            this.tcCapture.Name = "tcCapture";
            this.tcCapture.SelectedIndex = 0;
            this.tcCapture.Size = new System.Drawing.Size(1224, 693);
            this.tcCapture.TabIndex = 0;
            // 
            // tpCapture
            // 
            this.tpCapture.Controls.Add(this.tcCaptureTabs);
            this.tpCapture.Controls.Add(this.pnGestureDraw);
            this.tpCapture.Location = new System.Drawing.Point(4, 22);
            this.tpCapture.Name = "tpCapture";
            this.tpCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tpCapture.Size = new System.Drawing.Size(1216, 667);
            this.tpCapture.TabIndex = 0;
            this.tpCapture.Text = "Gesture capture";
            this.tpCapture.UseVisualStyleBackColor = true;
            // 
            // tcCaptureTabs
            // 
            this.tcCaptureTabs.Controls.Add(this.tpCaptureResults);
            this.tcCaptureTabs.Controls.Add(this.tpGestureCaptureTuning);
            this.tcCaptureTabs.Location = new System.Drawing.Point(669, 23);
            this.tcCaptureTabs.Name = "tcCaptureTabs";
            this.tcCaptureTabs.SelectedIndex = 0;
            this.tcCaptureTabs.Size = new System.Drawing.Size(541, 640);
            this.tcCaptureTabs.TabIndex = 37;
            // 
            // tpCaptureResults
            // 
            this.tpCaptureResults.Controls.Add(this.groupBox10);
            this.tpCaptureResults.Controls.Add(this.gbBitmapDrawingModes);
            this.tpCaptureResults.Controls.Add(this.gbPointsDrawingModes);
            this.tpCaptureResults.Controls.Add(this.groupBox7);
            this.tpCaptureResults.Controls.Add(this.groupBox6);
            this.tpCaptureResults.Controls.Add(this.label4);
            this.tpCaptureResults.Controls.Add(this.tbImageCounter);
            this.tpCaptureResults.Controls.Add(this.label1);
            this.tpCaptureResults.Controls.Add(this.lbCapturedGestures);
            this.tpCaptureResults.Controls.Add(this.bResetCounter);
            this.tpCaptureResults.Location = new System.Drawing.Point(4, 22);
            this.tpCaptureResults.Name = "tpCaptureResults";
            this.tpCaptureResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaptureResults.Size = new System.Drawing.Size(533, 614);
            this.tpCaptureResults.TabIndex = 0;
            this.tpCaptureResults.Text = "Results and files";
            this.tpCaptureResults.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rbBitmapBasedDrawingMode);
            this.groupBox10.Controls.Add(this.rbPointBasedDrawingMode);
            this.groupBox10.Location = new System.Drawing.Point(252, 291);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(266, 85);
            this.groupBox10.TabIndex = 39;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Drawing mode";
            // 
            // rbBitmapBasedDrawingMode
            // 
            this.rbBitmapBasedDrawingMode.AutoSize = true;
            this.rbBitmapBasedDrawingMode.Location = new System.Drawing.Point(16, 51);
            this.rbBitmapBasedDrawingMode.Name = "rbBitmapBasedDrawingMode";
            this.rbBitmapBasedDrawingMode.Size = new System.Drawing.Size(117, 17);
            this.rbBitmapBasedDrawingMode.TabIndex = 1;
            this.rbBitmapBasedDrawingMode.Text = "Draw using bitmaps";
            this.rbBitmapBasedDrawingMode.UseVisualStyleBackColor = true;
            this.rbBitmapBasedDrawingMode.CheckedChanged += new System.EventHandler(this.rbBitmapBasedDrawingMode_CheckedChanged);
            // 
            // rbPointBasedDrawingMode
            // 
            this.rbPointBasedDrawingMode.AutoSize = true;
            this.rbPointBasedDrawingMode.Checked = true;
            this.rbPointBasedDrawingMode.Location = new System.Drawing.Point(16, 28);
            this.rbPointBasedDrawingMode.Name = "rbPointBasedDrawingMode";
            this.rbPointBasedDrawingMode.Size = new System.Drawing.Size(109, 17);
            this.rbPointBasedDrawingMode.TabIndex = 0;
            this.rbPointBasedDrawingMode.TabStop = true;
            this.rbPointBasedDrawingMode.Text = "Draw using points";
            this.rbPointBasedDrawingMode.UseVisualStyleBackColor = true;
            this.rbPointBasedDrawingMode.CheckedChanged += new System.EventHandler(this.rbPointBasedDrawingMode_CheckedChanged);
            // 
            // gbBitmapDrawingModes
            // 
            this.gbBitmapDrawingModes.Controls.Add(this.rbDrawBezierBitmap);
            this.gbBitmapDrawingModes.Controls.Add(this.rbDrawTrailBitmap);
            this.gbBitmapDrawingModes.Enabled = false;
            this.gbBitmapDrawingModes.Location = new System.Drawing.Point(252, 517);
            this.gbBitmapDrawingModes.Name = "gbBitmapDrawingModes";
            this.gbBitmapDrawingModes.Size = new System.Drawing.Size(266, 82);
            this.gbBitmapDrawingModes.TabIndex = 4;
            this.gbBitmapDrawingModes.TabStop = false;
            this.gbBitmapDrawingModes.Text = "Bitmap based drawing options";
            // 
            // rbDrawBezierBitmap
            // 
            this.rbDrawBezierBitmap.AutoSize = true;
            this.rbDrawBezierBitmap.Location = new System.Drawing.Point(16, 51);
            this.rbDrawBezierBitmap.Name = "rbDrawBezierBitmap";
            this.rbDrawBezierBitmap.Size = new System.Drawing.Size(159, 17);
            this.rbDrawBezierBitmap.TabIndex = 1;
            this.rbDrawBezierBitmap.Text = "Draw gesture Beziers bitmap";
            this.rbDrawBezierBitmap.UseVisualStyleBackColor = true;
            this.rbDrawBezierBitmap.CheckedChanged += new System.EventHandler(this.rbDrawBezierBitmap_CheckedChanged);
            // 
            // rbDrawTrailBitmap
            // 
            this.rbDrawTrailBitmap.AutoSize = true;
            this.rbDrawTrailBitmap.Checked = true;
            this.rbDrawTrailBitmap.Location = new System.Drawing.Point(16, 28);
            this.rbDrawTrailBitmap.Name = "rbDrawTrailBitmap";
            this.rbDrawTrailBitmap.Size = new System.Drawing.Size(142, 17);
            this.rbDrawTrailBitmap.TabIndex = 0;
            this.rbDrawTrailBitmap.TabStop = true;
            this.rbDrawTrailBitmap.Text = "Draw gesture trail Bitmap";
            this.rbDrawTrailBitmap.UseVisualStyleBackColor = true;
            this.rbDrawTrailBitmap.CheckedChanged += new System.EventHandler(this.rbDrawTrailBitmap_CheckedChanged);
            // 
            // gbPointsDrawingModes
            // 
            this.gbPointsDrawingModes.Controls.Add(this.cbDrawGesturePoints);
            this.gbPointsDrawingModes.Controls.Add(this.cbDrawBoundingRectangle);
            this.gbPointsDrawingModes.Controls.Add(this.cbDrawBeziers);
            this.gbPointsDrawingModes.Controls.Add(this.cbDrawGesture);
            this.gbPointsDrawingModes.Location = new System.Drawing.Point(252, 382);
            this.gbPointsDrawingModes.Name = "gbPointsDrawingModes";
            this.gbPointsDrawingModes.Size = new System.Drawing.Size(266, 129);
            this.gbPointsDrawingModes.TabIndex = 38;
            this.gbPointsDrawingModes.TabStop = false;
            this.gbPointsDrawingModes.Text = "Point based drawing options";
            // 
            // cbDrawGesturePoints
            // 
            this.cbDrawGesturePoints.AutoSize = true;
            this.cbDrawGesturePoints.Location = new System.Drawing.Point(16, 77);
            this.cbDrawGesturePoints.Name = "cbDrawGesturePoints";
            this.cbDrawGesturePoints.Size = new System.Drawing.Size(120, 17);
            this.cbDrawGesturePoints.TabIndex = 3;
            this.cbDrawGesturePoints.Text = "Draw gesture points";
            this.cbDrawGesturePoints.UseVisualStyleBackColor = true;
            this.cbDrawGesturePoints.CheckedChanged += new System.EventHandler(this.cbDrawGesturePoints_CheckedChanged);
            // 
            // cbDrawBoundingRectangle
            // 
            this.cbDrawBoundingRectangle.AutoSize = true;
            this.cbDrawBoundingRectangle.Location = new System.Drawing.Point(16, 100);
            this.cbDrawBoundingRectangle.Name = "cbDrawBoundingRectangle";
            this.cbDrawBoundingRectangle.Size = new System.Drawing.Size(145, 17);
            this.cbDrawBoundingRectangle.TabIndex = 2;
            this.cbDrawBoundingRectangle.Text = "Draw bounding rectangle";
            this.cbDrawBoundingRectangle.UseVisualStyleBackColor = true;
            this.cbDrawBoundingRectangle.CheckedChanged += new System.EventHandler(this.cbDrawBoundingRectangle_CheckedChanged);
            // 
            // cbDrawBeziers
            // 
            this.cbDrawBeziers.AutoSize = true;
            this.cbDrawBeziers.Location = new System.Drawing.Point(16, 54);
            this.cbDrawBeziers.Name = "cbDrawBeziers";
            this.cbDrawBeziers.Size = new System.Drawing.Size(88, 17);
            this.cbDrawBeziers.TabIndex = 1;
            this.cbDrawBeziers.Text = "Draw Beziers";
            this.cbDrawBeziers.UseVisualStyleBackColor = true;
            this.cbDrawBeziers.CheckedChanged += new System.EventHandler(this.cbDrawBeziers_CheckedChanged);
            // 
            // cbDrawGesture
            // 
            this.cbDrawGesture.AutoSize = true;
            this.cbDrawGesture.Checked = true;
            this.cbDrawGesture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawGesture.Location = new System.Drawing.Point(16, 31);
            this.cbDrawGesture.Name = "cbDrawGesture";
            this.cbDrawGesture.Size = new System.Drawing.Size(108, 17);
            this.cbDrawGesture.TabIndex = 0;
            this.cbDrawGesture.Text = "Draw gesture trail";
            this.cbDrawGesture.UseVisualStyleBackColor = true;
            this.cbDrawGesture.CheckedChanged += new System.EventHandler(this.cbDrawGesture_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bDeleteSelected);
            this.groupBox7.Controls.Add(this.bSave);
            this.groupBox7.Controls.Add(this.cbOverwriteExistingImages);
            this.groupBox7.Location = new System.Drawing.Point(252, 185);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(266, 100);
            this.groupBox7.TabIndex = 37;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Gesture files storage";
            // 
            // bDeleteSelected
            // 
            this.bDeleteSelected.Location = new System.Drawing.Point(16, 28);
            this.bDeleteSelected.Name = "bDeleteSelected";
            this.bDeleteSelected.Size = new System.Drawing.Size(98, 23);
            this.bDeleteSelected.TabIndex = 35;
            this.bDeleteSelected.Text = "Delete selected";
            this.bDeleteSelected.UseVisualStyleBackColor = true;
            this.bDeleteSelected.Click += new System.EventHandler(this.bDeleteSelected_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(16, 57);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(98, 23);
            this.bSave.TabIndex = 31;
            this.bSave.Text = "Save images";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bPrepareAndStart);
            this.groupBox6.Controls.Add(this.bStop);
            this.groupBox6.Controls.Add(this.bStart);
            this.groupBox6.Location = new System.Drawing.Point(252, 68);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(266, 111);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ajust capturing";
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(16, 79);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(98, 23);
            this.bStop.TabIndex = 33;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(16, 50);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(98, 23);
            this.bStart.TabIndex = 34;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Captured image files";
            // 
            // lbCapturedGestures
            // 
            this.lbCapturedGestures.FormattingEnabled = true;
            this.lbCapturedGestures.Location = new System.Drawing.Point(11, 74);
            this.lbCapturedGestures.Name = "lbCapturedGestures";
            this.lbCapturedGestures.Size = new System.Drawing.Size(227, 524);
            this.lbCapturedGestures.TabIndex = 0;
            this.lbCapturedGestures.SelectedIndexChanged += new System.EventHandler(this.lbCapturedGestures_SelectedIndexChanged);
            // 
            // bResetCounter
            // 
            this.bResetCounter.Location = new System.Drawing.Point(188, 13);
            this.bResetCounter.Name = "bResetCounter";
            this.bResetCounter.Size = new System.Drawing.Size(93, 23);
            this.bResetCounter.TabIndex = 30;
            this.bResetCounter.Text = "Reset counter";
            this.bResetCounter.UseVisualStyleBackColor = true;
            this.bResetCounter.Click += new System.EventHandler(this.bResetCounter_Click);
            // 
            // tpGestureCaptureTuning
            // 
            this.tpGestureCaptureTuning.Controls.Add(this.groupBox9);
            this.tpGestureCaptureTuning.Controls.Add(this.groupBox8);
            this.tpGestureCaptureTuning.Controls.Add(this.groupBox4);
            this.tpGestureCaptureTuning.Controls.Add(this.groupBox3);
            this.tpGestureCaptureTuning.Location = new System.Drawing.Point(4, 22);
            this.tpGestureCaptureTuning.Name = "tpGestureCaptureTuning";
            this.tpGestureCaptureTuning.Padding = new System.Windows.Forms.Padding(3);
            this.tpGestureCaptureTuning.Size = new System.Drawing.Size(533, 614);
            this.tpGestureCaptureTuning.TabIndex = 1;
            this.tpGestureCaptureTuning.Text = "Tuning (advanced)";
            this.tpGestureCaptureTuning.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.rbtProfilingResult);
            this.groupBox9.Controls.Add(this.bStopInstantProfiling);
            this.groupBox9.Controls.Add(this.bStartInstantProfiling);
            this.groupBox9.Location = new System.Drawing.Point(299, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(216, 481);
            this.groupBox9.TabIndex = 16;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Instant profiling";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Profiling result";
            // 
            // rbtProfilingResult
            // 
            this.rbtProfilingResult.BackColor = System.Drawing.SystemColors.MenuBar;
            this.rbtProfilingResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbtProfilingResult.Location = new System.Drawing.Point(12, 108);
            this.rbtProfilingResult.Name = "rbtProfilingResult";
            this.rbtProfilingResult.Size = new System.Drawing.Size(194, 361);
            this.rbtProfilingResult.TabIndex = 2;
            this.rbtProfilingResult.Text = "";
            // 
            // bStopInstantProfiling
            // 
            this.bStopInstantProfiling.Location = new System.Drawing.Point(12, 56);
            this.bStopInstantProfiling.Name = "bStopInstantProfiling";
            this.bStopInstantProfiling.Size = new System.Drawing.Size(95, 22);
            this.bStopInstantProfiling.TabIndex = 1;
            this.bStopInstantProfiling.Text = "Stop and save";
            this.bStopInstantProfiling.UseVisualStyleBackColor = true;
            this.bStopInstantProfiling.Click += new System.EventHandler(this.bStopInstantProfiling_Click);
            // 
            // bStartInstantProfiling
            // 
            this.bStartInstantProfiling.Location = new System.Drawing.Point(12, 24);
            this.bStartInstantProfiling.Name = "bStartInstantProfiling";
            this.bStartInstantProfiling.Size = new System.Drawing.Size(95, 22);
            this.bStartInstantProfiling.TabIndex = 0;
            this.bStartInstantProfiling.Text = "Start";
            this.bStartInstantProfiling.UseVisualStyleBackColor = true;
            this.bStartInstantProfiling.Click += new System.EventHandler(this.bStartInstantProfiling_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbLowPassFilterFactor);
            this.groupBox8.Controls.Add(this.lbLowPassFilterFactor);
            this.groupBox8.Controls.Add(this.lbNumberOfPoints_filtering);
            this.groupBox8.Controls.Add(this.nudNumberOfPoints_Filtering);
            this.groupBox8.Controls.Add(this.cbApplyLoPasFilterOnEnding);
            this.groupBox8.Location = new System.Drawing.Point(18, 385);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(275, 116);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Additional options";
            // 
            // tbLowPassFilterFactor
            // 
            this.tbLowPassFilterFactor.Location = new System.Drawing.Point(185, 84);
            this.tbLowPassFilterFactor.Name = "tbLowPassFilterFactor";
            this.tbLowPassFilterFactor.Size = new System.Drawing.Size(83, 20);
            this.tbLowPassFilterFactor.TabIndex = 8;
            this.tbLowPassFilterFactor.Text = "0,00";
            this.tbLowPassFilterFactor.TextChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // lbLowPassFilterFactor
            // 
            this.lbLowPassFilterFactor.AutoSize = true;
            this.lbLowPassFilterFactor.Location = new System.Drawing.Point(76, 87);
            this.lbLowPassFilterFactor.Name = "lbLowPassFilterFactor";
            this.lbLowPassFilterFactor.Size = new System.Drawing.Size(59, 13);
            this.lbLowPassFilterFactor.TabIndex = 7;
            this.lbLowPassFilterFactor.Text = "Filter factor";
            // 
            // lbNumberOfPoints_filtering
            // 
            this.lbNumberOfPoints_filtering.AutoSize = true;
            this.lbNumberOfPoints_filtering.Location = new System.Drawing.Point(76, 60);
            this.lbNumberOfPoints_filtering.Name = "lbNumberOfPoints_filtering";
            this.lbNumberOfPoints_filtering.Size = new System.Drawing.Size(87, 13);
            this.lbNumberOfPoints_filtering.TabIndex = 5;
            this.lbNumberOfPoints_filtering.Text = "Number of points";
            // 
            // nudNumberOfPoints_Filtering
            // 
            this.nudNumberOfPoints_Filtering.Location = new System.Drawing.Point(185, 58);
            this.nudNumberOfPoints_Filtering.Name = "nudNumberOfPoints_Filtering";
            this.nudNumberOfPoints_Filtering.Size = new System.Drawing.Size(83, 20);
            this.nudNumberOfPoints_Filtering.TabIndex = 6;
            this.nudNumberOfPoints_Filtering.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // cbApplyLoPasFilterOnEnding
            // 
            this.cbApplyLoPasFilterOnEnding.AutoSize = true;
            this.cbApplyLoPasFilterOnEnding.Location = new System.Drawing.Point(14, 29);
            this.cbApplyLoPasFilterOnEnding.Name = "cbApplyLoPasFilterOnEnding";
            this.cbApplyLoPasFilterOnEnding.Size = new System.Drawing.Size(206, 17);
            this.cbApplyLoPasFilterOnEnding.TabIndex = 0;
            this.cbApplyLoPasFilterOnEnding.Text = "Apply low pass filter on gesture ending";
            this.cbApplyLoPasFilterOnEnding.UseVisualStyleBackColor = true;
            this.cbApplyLoPasFilterOnEnding.CheckedChanged += new System.EventHandler(this.cbApplyLoPasFilterOnEnding_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.nudMaxStabilizingCounterValue);
            this.groupBox4.Location = new System.Drawing.Point(18, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 73);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gesture cursor state machine parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Max. stabilizing counter value";
            // 
            // nudMaxStabilizingCounterValue
            // 
            this.nudMaxStabilizingCounterValue.Location = new System.Drawing.Point(186, 27);
            this.nudMaxStabilizingCounterValue.Name = "nudMaxStabilizingCounterValue";
            this.nudMaxStabilizingCounterValue.Size = new System.Drawing.Size(83, 20);
            this.nudMaxStabilizingCounterValue.TabIndex = 4;
            this.nudMaxStabilizingCounterValue.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbDrawingMode);
            this.groupBox3.Controls.Add(this.nudMinStabilizingMarkRadius);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudStandardCursorSize);
            this.groupBox3.Controls.Add(this.nudCrossmarkSize);
            this.groupBox3.Controls.Add(this.nudStabilizingCrossmarkSizeInterval);
            this.groupBox3.Controls.Add(this.nudMaxStabilizingMarkRadius);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.nudRedrawMargin);
            this.groupBox3.Location = new System.Drawing.Point(18, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 280);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gesture cursor view parameters";
            // 
            // gbDrawingMode
            // 
            this.gbDrawingMode.Controls.Add(this.rbDrawOnTargetControlPaint);
            this.gbDrawingMode.Controls.Add(this.rbEraseAndDrawOnCapture);
            this.gbDrawingMode.Location = new System.Drawing.Point(5, 194);
            this.gbDrawingMode.Name = "gbDrawingMode";
            this.gbDrawingMode.Size = new System.Drawing.Size(263, 79);
            this.gbDrawingMode.TabIndex = 15;
            this.gbDrawingMode.TabStop = false;
            this.gbDrawingMode.Text = "Drawing mode";
            // 
            // rbDrawOnTargetControlPaint
            // 
            this.rbDrawOnTargetControlPaint.AutoSize = true;
            this.rbDrawOnTargetControlPaint.Location = new System.Drawing.Point(14, 50);
            this.rbDrawOnTargetControlPaint.Name = "rbDrawOnTargetControlPaint";
            this.rbDrawOnTargetControlPaint.Size = new System.Drawing.Size(156, 17);
            this.rbDrawOnTargetControlPaint.TabIndex = 1;
            this.rbDrawOnTargetControlPaint.Text = "Draw on target control paint";
            this.rbDrawOnTargetControlPaint.UseVisualStyleBackColor = true;
            // 
            // rbEraseAndDrawOnCapture
            // 
            this.rbEraseAndDrawOnCapture.AutoSize = true;
            this.rbEraseAndDrawOnCapture.Checked = true;
            this.rbEraseAndDrawOnCapture.Location = new System.Drawing.Point(14, 27);
            this.rbEraseAndDrawOnCapture.Name = "rbEraseAndDrawOnCapture";
            this.rbEraseAndDrawOnCapture.Size = new System.Drawing.Size(153, 17);
            this.rbEraseAndDrawOnCapture.TabIndex = 0;
            this.rbEraseAndDrawOnCapture.TabStop = true;
            this.rbEraseAndDrawOnCapture.Text = "Erase and draw on capture";
            this.rbEraseAndDrawOnCapture.UseVisualStyleBackColor = true;
            this.rbEraseAndDrawOnCapture.CheckedChanged += new System.EventHandler(this.rbEraseAndDrawOnCapture_CheckedChanged);
            // 
            // nudMinStabilizingMarkRadius
            // 
            this.nudMinStabilizingMarkRadius.Location = new System.Drawing.Point(186, 132);
            this.nudMinStabilizingMarkRadius.Name = "nudMinStabilizingMarkRadius";
            this.nudMinStabilizingMarkRadius.Size = new System.Drawing.Size(83, 20);
            this.nudMinStabilizingMarkRadius.TabIndex = 13;
            this.nudMinStabilizingMarkRadius.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Min. stabilizing mark radius";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Redraw margin";
            // 
            // nudStandardCursorSize
            // 
            this.nudStandardCursorSize.Location = new System.Drawing.Point(186, 54);
            this.nudStandardCursorSize.Name = "nudStandardCursorSize";
            this.nudStandardCursorSize.Size = new System.Drawing.Size(83, 20);
            this.nudStandardCursorSize.TabIndex = 8;
            this.nudStandardCursorSize.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // nudCrossmarkSize
            // 
            this.nudCrossmarkSize.Location = new System.Drawing.Point(186, 80);
            this.nudCrossmarkSize.Name = "nudCrossmarkSize";
            this.nudCrossmarkSize.Size = new System.Drawing.Size(83, 20);
            this.nudCrossmarkSize.TabIndex = 6;
            this.nudCrossmarkSize.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // nudStabilizingCrossmarkSizeInterval
            // 
            this.nudStabilizingCrossmarkSizeInterval.Location = new System.Drawing.Point(186, 158);
            this.nudStabilizingCrossmarkSizeInterval.Name = "nudStabilizingCrossmarkSizeInterval";
            this.nudStabilizingCrossmarkSizeInterval.Size = new System.Drawing.Size(83, 20);
            this.nudStabilizingCrossmarkSizeInterval.TabIndex = 12;
            this.nudStabilizingCrossmarkSizeInterval.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // nudMaxStabilizingMarkRadius
            // 
            this.nudMaxStabilizingMarkRadius.Location = new System.Drawing.Point(186, 106);
            this.nudMaxStabilizingMarkRadius.Name = "nudMaxStabilizingMarkRadius";
            this.nudMaxStabilizingMarkRadius.Size = new System.Drawing.Size(83, 20);
            this.nudMaxStabilizingMarkRadius.TabIndex = 4;
            this.nudMaxStabilizingMarkRadius.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Standard cursor size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Stab. crossmark redraw interv.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Crossmark size";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Max. stabilizing mark radius";
            // 
            // nudRedrawMargin
            // 
            this.nudRedrawMargin.Location = new System.Drawing.Point(186, 28);
            this.nudRedrawMargin.Name = "nudRedrawMargin";
            this.nudRedrawMargin.Size = new System.Drawing.Size(83, 20);
            this.nudRedrawMargin.TabIndex = 2;
            this.nudRedrawMargin.ValueChanged += new System.EventHandler(this.TuningControls_ValueOrTextChanged);
            // 
            // pnGestureDraw
            // 
            this.pnGestureDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnGestureDraw.ContextMenuStrip = this.cmsImage;
            this.pnGestureDraw.Location = new System.Drawing.Point(12, 23);
            this.pnGestureDraw.Name = "pnGestureDraw";
            this.pnGestureDraw.Size = new System.Drawing.Size(640, 640);
            this.pnGestureDraw.TabIndex = 36;
            // 
            // cmsImage
            // 
            this.cmsImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscCopyToClipboard});
            this.cmsImage.Name = "cmsImage";
            this.cmsImage.Size = new System.Drawing.Size(139, 26);
            // 
            // tscCopyToClipboard
            // 
            this.tscCopyToClipboard.Name = "tscCopyToClipboard";
            this.tscCopyToClipboard.Size = new System.Drawing.Size(138, 22);
            this.tscCopyToClipboard.Text = "Copy image";
            this.tscCopyToClipboard.Click += new System.EventHandler(this.tscCopyToClipboard_Click);
            // 
            // tpDatasetLookup
            // 
            this.tpDatasetLookup.Location = new System.Drawing.Point(4, 22);
            this.tpDatasetLookup.Name = "tpDatasetLookup";
            this.tpDatasetLookup.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatasetLookup.Size = new System.Drawing.Size(1216, 667);
            this.tpDatasetLookup.TabIndex = 1;
            this.tpDatasetLookup.Text = "Saved gesture images";
            this.tpDatasetLookup.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(669, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 693);
            this.panel1.TabIndex = 4;
            // 
            // pnBottomLeft
            // 
            this.pnBottomLeft.Controls.Add(this.lbDrawnOwnGesture);
            this.pnBottomLeft.Controls.Add(this.cmbOwnGesture);
            this.pnBottomLeft.Controls.Add(this.cbOwnGesture);
            this.pnBottomLeft.Controls.Add(this.tbPatternClassLabel);
            this.pnBottomLeft.Controls.Add(this.pbGesturePattern);
            this.pnBottomLeft.Controls.Add(this.cmbGesturePattern);
            this.pnBottomLeft.Controls.Add(this.label2);
            this.pnBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBottomLeft.Location = new System.Drawing.Point(5, 13);
            this.pnBottomLeft.Name = "pnBottomLeft";
            this.pnBottomLeft.Size = new System.Drawing.Size(664, 693);
            this.pnBottomLeft.TabIndex = 0;
            // 
            // lbDrawnOwnGesture
            // 
            this.lbDrawnOwnGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDrawnOwnGesture.Location = new System.Drawing.Point(25, 154);
            this.lbDrawnOwnGesture.Name = "lbDrawnOwnGesture";
            this.lbDrawnOwnGesture.Size = new System.Drawing.Size(616, 23);
            this.lbDrawnOwnGesture.TabIndex = 35;
            this.lbDrawnOwnGesture.Text = "Draw your own shape";
            this.lbDrawnOwnGesture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDrawnOwnGesture.Visible = false;
            // 
            // cmbOwnGesture
            // 
            this.cmbOwnGesture.Enabled = false;
            this.cmbOwnGesture.FormattingEnabled = true;
            this.cmbOwnGesture.Items.AddRange(new object[] {
            "OWN1",
            "OWN2",
            "OWN3",
            "OWN4",
            "OWN5",
            "CAS0"});
            this.cmbOwnGesture.Location = new System.Drawing.Point(461, 12);
            this.cmbOwnGesture.Name = "cmbOwnGesture";
            this.cmbOwnGesture.Size = new System.Drawing.Size(121, 21);
            this.cmbOwnGesture.TabIndex = 34;
            this.cmbOwnGesture.SelectedIndexChanged += new System.EventHandler(this.cmbOwnGesture_SelectedIndexChanged);
            // 
            // cbOwnGesture
            // 
            this.cbOwnGesture.AutoSize = true;
            this.cbOwnGesture.Location = new System.Drawing.Point(352, 14);
            this.cbOwnGesture.Name = "cbOwnGesture";
            this.cbOwnGesture.Size = new System.Drawing.Size(103, 17);
            this.cbOwnGesture.TabIndex = 33;
            this.cbOwnGesture.Text = "User own shape";
            this.cbOwnGesture.UseVisualStyleBackColor = true;
            this.cbOwnGesture.CheckedChanged += new System.EventHandler(this.cbOwnGesture_CheckedChanged);
            // 
            // tbPatternClassLabel
            // 
            this.tbPatternClassLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPatternClassLabel.Location = new System.Drawing.Point(588, 12);
            this.tbPatternClassLabel.Name = "tbPatternClassLabel";
            this.tbPatternClassLabel.ReadOnly = true;
            this.tbPatternClassLabel.Size = new System.Drawing.Size(64, 20);
            this.tbPatternClassLabel.TabIndex = 32;
            // 
            // pbGesturePattern
            // 
            this.pbGesturePattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGesturePattern.Location = new System.Drawing.Point(12, 45);
            this.pbGesturePattern.Name = "pbGesturePattern";
            this.pbGesturePattern.Size = new System.Drawing.Size(640, 640);
            this.pbGesturePattern.TabIndex = 0;
            this.pbGesturePattern.TabStop = false;
            // 
            // cmbGesturePattern
            // 
            this.cmbGesturePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGesturePattern.FormattingEnabled = true;
            this.cmbGesturePattern.Location = new System.Drawing.Point(94, 12);
            this.cmbGesturePattern.Name = "cmbGesturePattern";
            this.cmbGesturePattern.Size = new System.Drawing.Size(252, 21);
            this.cmbGesturePattern.TabIndex = 31;
            this.cmbGesturePattern.SelectedIndexChanged += new System.EventHandler(this.cbPatterns_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Gesture prompt";
            // 
            // FrmMainGesture2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnTop);
            this.DoubleBuffered = true;
            this.Name = "FrmMainGesture2D";
            this.Size = new System.Drawing.Size(1904, 792);
            this.Load += new System.EventHandler(this.FrmMainGesture2D_Load);
            this.pnTop.ResumeLayout(false);
            this.gbDesktopMode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbMessageParams.ResumeLayout(false);
            this.gbMessageParams.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnBotoomRight.ResumeLayout(false);
            this.tcCapture.ResumeLayout(false);
            this.tpCapture.ResumeLayout(false);
            this.tcCaptureTabs.ResumeLayout(false);
            this.tpCaptureResults.ResumeLayout(false);
            this.tpCaptureResults.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbBitmapDrawingModes.ResumeLayout(false);
            this.gbBitmapDrawingModes.PerformLayout();
            this.gbPointsDrawingModes.ResumeLayout(false);
            this.gbPointsDrawingModes.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tpGestureCaptureTuning.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPoints_Filtering)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStabilizingCounterValue)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDrawingMode.ResumeLayout(false);
            this.gbDrawingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStabilizingMarkRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStandardCursorSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossmarkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStabilizingCrossmarkSizeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStabilizingMarkRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRedrawMargin)).EndInit();
            this.cmsImage.ResumeLayout(false);
            this.pnBottomLeft.ResumeLayout(false);
            this.pnBottomLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGesturePattern)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.GroupBox gbMessageParams;
        private System.Windows.Forms.CheckBox cbCapture2DGestures;
        private System.Windows.Forms.Panel pnSpace1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOverwriteExistingImages;
        private System.Windows.Forms.TextBox tbImageCounter;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button bPrepareAndStart;
        private System.Windows.Forms.Panel pnBottomLeft;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbSegmenterState;
        private System.Windows.Forms.Label lbSegmenterState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbGesturePattern;

        // KaiData managed controls
        private System.Windows.Forms.ComboBox cmbGesturePattern;
        private System.Windows.Forms.ComboBox cmbImageDataset;
        private System.Windows.Forms.ComboBox cmbIndividual;
        private System.Windows.Forms.TextBox tbIndividualsLabel;
        private System.Windows.Forms.Panel pnBotoomRight;
        private System.Windows.Forms.TabControl tcCapture;
        private System.Windows.Forms.TabPage tpCapture;
        private System.Windows.Forms.TabPage tpDatasetLookup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbCapturedGestures;
        private System.Windows.Forms.Button bResetCounter;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Panel pnGestureDraw;
        private System.Windows.Forms.CheckBox cbRecordImages;
        private System.Windows.Forms.TabControl tcCaptureTabs;
        private System.Windows.Forms.TabPage tpCaptureResults;
        private System.Windows.Forms.TabPage tpGestureCaptureTuning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRedrawMargin;
        private System.Windows.Forms.NumericUpDown nudStabilizingCrossmarkSizeInterval;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudStandardCursorSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudCrossmarkSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMaxStabilizingMarkRadius;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudMinStabilizingMarkRadius;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudMaxStabilizingCounterValue;
        private System.Windows.Forms.Button bDeleteSelected;
        private System.Windows.Forms.GroupBox gbDrawingMode;
        private System.Windows.Forms.RadioButton rbDrawOnTargetControlPaint;
        private System.Windows.Forms.RadioButton rbEraseAndDrawOnCapture;
        private System.Windows.Forms.GroupBox gbDesktopMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bSwitchToDesktopMode;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox gbPointsDrawingModes;
        private System.Windows.Forms.CheckBox cbDrawBoundingRectangle;
        private System.Windows.Forms.CheckBox cbDrawBeziers;
        private System.Windows.Forms.CheckBox cbDrawGesture;
        private System.Windows.Forms.CheckBox cbDrawGesturePoints;
        private System.Windows.Forms.GroupBox gbBitmapDrawingModes;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rbBitmapBasedDrawingMode;
        private System.Windows.Forms.RadioButton rbPointBasedDrawingMode;
        private System.Windows.Forms.RadioButton rbDrawBezierBitmap;
        private System.Windows.Forms.RadioButton rbDrawTrailBitmap;
        private System.Windows.Forms.Label lbDrawnOwnGesture;
        private System.Windows.Forms.ComboBox cmbOwnGesture;
        private System.Windows.Forms.CheckBox cbOwnGesture;
        private System.Windows.Forms.TextBox tbPatternClassLabel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lbNumberOfPoints_filtering;
        private System.Windows.Forms.NumericUpDown nudNumberOfPoints_Filtering;
        private System.Windows.Forms.CheckBox cbApplyLoPasFilterOnEnding;
        private System.Windows.Forms.TextBox tbLowPassFilterFactor;
        private System.Windows.Forms.Label lbLowPassFilterFactor;
        private System.Windows.Forms.ContextMenuStrip cmsImage;
        private System.Windows.Forms.ToolStripMenuItem tscCopyToClipboard;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button bStopInstantProfiling;
        private System.Windows.Forms.Button bStartInstantProfiling;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rbtProfilingResult;
    }
}
