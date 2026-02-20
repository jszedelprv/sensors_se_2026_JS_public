using MyKai.General;
using MyKai.GUI;

namespace kaibasic
{
    partial class FrmDesktopMode
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnTitleBar = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.gbUserGestures = new System.Windows.Forms.GroupBox();
            this.flpGestures = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDistanceBottom = new System.Windows.Forms.Panel();
            this.pnBottoom = new System.Windows.Forms.Panel();
            this.tbSegmenterState = new System.Windows.Forms.TextBox();
            this.lbSegmenterState = new System.Windows.Forms.Label();
            this.lbDetailLevelDescription = new System.Windows.Forms.Label();
            this.bShowLessMore = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.tcDetails = new System.Windows.Forms.TabControl();
            this.tpLogging = new System.Windows.Forms.TabPage();
            this.ucKaiLoggingDesktopForm = new kaibasic.Forms.KaiMessageLogUserControlLocal();
            this.tpDrawTest = new System.Windows.Forms.TabPage();
            this.pnDrawGestureTmp = new System.Windows.Forms.Panel();
            this.pnDistanceTop = new System.Windows.Forms.Panel();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.bStartGestureCapture = new System.Windows.Forms.Button();
            this.bInitializeAndConnect = new System.Windows.Forms.Button();
            this.lbSensorState = new System.Windows.Forms.Label();
            this.lbSDKState = new System.Windows.Forms.Label();
            this.bRunSDK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnTitleBar.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.gbUserGestures.SuspendLayout();
            this.pnBottoom.SuspendLayout();
            this.tcDetails.SuspendLayout();
            this.tpLogging.SuspendLayout();
            this.tpDrawTest.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTitleBar
            // 
            this.pnTitleBar.Controls.Add(this.pnMain);
            this.pnTitleBar.Controls.Add(this.lbTitle);
            this.pnTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnTitleBar.Name = "pnTitleBar";
            this.pnTitleBar.Size = new System.Drawing.Size(593, 712);
            this.pnTitleBar.TabIndex = 0;
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.gbUserGestures);
            this.pnMain.Controls.Add(this.pnDistanceBottom);
            this.pnMain.Controls.Add(this.pnBottoom);
            this.pnMain.Controls.Add(this.tcDetails);
            this.pnMain.Controls.Add(this.pnDistanceTop);
            this.pnMain.Controls.Add(this.gbTop);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 20);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnMain.Size = new System.Drawing.Size(593, 692);
            this.pnMain.TabIndex = 2;
            // 
            // gbUserGestures
            // 
            this.gbUserGestures.Controls.Add(this.flpGestures);
            this.gbUserGestures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserGestures.Location = new System.Drawing.Point(3, 536);
            this.gbUserGestures.Name = "gbUserGestures";
            this.gbUserGestures.Padding = new System.Windows.Forms.Padding(6);
            this.gbUserGestures.Size = new System.Drawing.Size(587, 156);
            this.gbUserGestures.TabIndex = 7;
            this.gbUserGestures.TabStop = false;
            this.gbUserGestures.Text = "Your gestures";
            // 
            // flpGestures
            // 
            this.flpGestures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGestures.Location = new System.Drawing.Point(6, 19);
            this.flpGestures.Name = "flpGestures";
            this.flpGestures.Size = new System.Drawing.Size(575, 131);
            this.flpGestures.TabIndex = 0;
            // 
            // pnDistanceBottom
            // 
            this.pnDistanceBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDistanceBottom.Location = new System.Drawing.Point(3, 530);
            this.pnDistanceBottom.Name = "pnDistanceBottom";
            this.pnDistanceBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnDistanceBottom.Size = new System.Drawing.Size(587, 6);
            this.pnDistanceBottom.TabIndex = 6;
            // 
            // pnBottoom
            // 
            this.pnBottoom.Controls.Add(this.tbSegmenterState);
            this.pnBottoom.Controls.Add(this.lbSegmenterState);
            this.pnBottoom.Controls.Add(this.lbDetailLevelDescription);
            this.pnBottoom.Controls.Add(this.bShowLessMore);
            this.pnBottoom.Controls.Add(this.bClose);
            this.pnBottoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBottoom.Location = new System.Drawing.Point(3, 500);
            this.pnBottoom.Name = "pnBottoom";
            this.pnBottoom.Size = new System.Drawing.Size(587, 30);
            this.pnBottoom.TabIndex = 5;
            // 
            // tbSegmenterState
            // 
            this.tbSegmenterState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSegmenterState.Location = new System.Drawing.Point(335, 5);
            this.tbSegmenterState.Name = "tbSegmenterState";
            this.tbSegmenterState.Size = new System.Drawing.Size(144, 20);
            this.tbSegmenterState.TabIndex = 30;
            // 
            // lbSegmenterState
            // 
            this.lbSegmenterState.AutoSize = true;
            this.lbSegmenterState.Location = new System.Drawing.Point(235, 8);
            this.lbSegmenterState.Name = "lbSegmenterState";
            this.lbSegmenterState.Size = new System.Drawing.Size(84, 13);
            this.lbSegmenterState.TabIndex = 29;
            this.lbSegmenterState.Text = "Segmenter state";
            // 
            // lbDetailLevelDescription
            // 
            this.lbDetailLevelDescription.AutoSize = true;
            this.lbDetailLevelDescription.Location = new System.Drawing.Point(39, 9);
            this.lbDetailLevelDescription.Name = "lbDetailLevelDescription";
            this.lbDetailLevelDescription.Size = new System.Drawing.Size(62, 13);
            this.lbDetailLevelDescription.TabIndex = 2;
            this.lbDetailLevelDescription.Text = "Hide details";
            // 
            // bShowLessMore
            // 
            this.bShowLessMore.BackColor = System.Drawing.Color.White;
            this.bShowLessMore.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bShowLessMore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bShowLessMore.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bShowLessMore.Location = new System.Drawing.Point(5, 5);
            this.bShowLessMore.Name = "bShowLessMore";
            this.bShowLessMore.Size = new System.Drawing.Size(28, 19);
            this.bShowLessMore.TabIndex = 1;
            this.bShowLessMore.Text = "";
            this.bShowLessMore.UseVisualStyleBackColor = false;
            this.bShowLessMore.Click += new System.EventHandler(this.bShowLessMore_Click);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.Location = new System.Drawing.Point(491, 5);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(92, 21);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "Close module";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // tcDetails
            // 
            this.tcDetails.Controls.Add(this.tpLogging);
            this.tcDetails.Controls.Add(this.tpDrawTest);
            this.tcDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcDetails.Location = new System.Drawing.Point(3, 78);
            this.tcDetails.Name = "tcDetails";
            this.tcDetails.SelectedIndex = 0;
            this.tcDetails.Size = new System.Drawing.Size(587, 422);
            this.tcDetails.TabIndex = 4;
            // 
            // tpLogging
            // 
            this.tpLogging.Controls.Add(this.ucKaiLoggingDesktopForm);
            this.tpLogging.Location = new System.Drawing.Point(4, 22);
            this.tpLogging.Name = "tpLogging";
            this.tpLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogging.Size = new System.Drawing.Size(579, 396);
            this.tpLogging.TabIndex = 0;
            this.tpLogging.Text = "Message log";
            this.tpLogging.UseVisualStyleBackColor = true;
            // 
            // ucKaiLoggingDesktopForm
            // 
            this.ucKaiLoggingDesktopForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKaiLoggingDesktopForm.IsLoggingOn = true;
            this.ucKaiLoggingDesktopForm.Location = new System.Drawing.Point(3, 3);
            this.ucKaiLoggingDesktopForm.Name = "ucKaiLoggingDesktopForm";
            this.ucKaiLoggingDesktopForm.Size = new System.Drawing.Size(573, 390);
            this.ucKaiLoggingDesktopForm.TabIndex = 0;
            // 
            // tpDrawTest
            // 
            this.tpDrawTest.Controls.Add(this.pnDrawGestureTmp);
            this.tpDrawTest.Location = new System.Drawing.Point(4, 22);
            this.tpDrawTest.Name = "tpDrawTest";
            this.tpDrawTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpDrawTest.Size = new System.Drawing.Size(579, 396);
            this.tpDrawTest.TabIndex = 1;
            this.tpDrawTest.Text = "Gesture drawing test";
            this.tpDrawTest.UseVisualStyleBackColor = true;
            // 
            // pnDrawGestureTmp
            // 
            this.pnDrawGestureTmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDrawGestureTmp.Location = new System.Drawing.Point(3, 3);
            this.pnDrawGestureTmp.Name = "pnDrawGestureTmp";
            this.pnDrawGestureTmp.Size = new System.Drawing.Size(573, 390);
            this.pnDrawGestureTmp.TabIndex = 0;
            // 
            // pnDistanceTop
            // 
            this.pnDistanceTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDistanceTop.Location = new System.Drawing.Point(3, 72);
            this.pnDistanceTop.Name = "pnDistanceTop";
            this.pnDistanceTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnDistanceTop.Size = new System.Drawing.Size(587, 6);
            this.pnDistanceTop.TabIndex = 1;
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.bStartGestureCapture);
            this.gbTop.Controls.Add(this.bInitializeAndConnect);
            this.gbTop.Controls.Add(this.lbSensorState);
            this.gbTop.Controls.Add(this.lbSDKState);
            this.gbTop.Controls.Add(this.bRunSDK);
            this.gbTop.Controls.Add(this.label2);
            this.gbTop.Controls.Add(this.label1);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(3, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbTop.Size = new System.Drawing.Size(587, 72);
            this.gbTop.TabIndex = 1;
            this.gbTop.TabStop = false;
            this.gbTop.Text = "Module status";
            // 
            // bStartGestureCapture
            // 
            this.bStartGestureCapture.Location = new System.Drawing.Point(334, 15);
            this.bStartGestureCapture.Name = "bStartGestureCapture";
            this.bStartGestureCapture.Size = new System.Drawing.Size(116, 21);
            this.bStartGestureCapture.TabIndex = 21;
            this.bStartGestureCapture.Text = "Start gesture capture";
            this.bStartGestureCapture.UseVisualStyleBackColor = true;
            this.bStartGestureCapture.Click += new System.EventHandler(this.bStartGestureCapture_Click);
            // 
            // bInitializeAndConnect
            // 
            this.bInitializeAndConnect.Location = new System.Drawing.Point(194, 41);
            this.bInitializeAndConnect.Name = "bInitializeAndConnect";
            this.bInitializeAndConnect.Size = new System.Drawing.Size(125, 21);
            this.bInitializeAndConnect.TabIndex = 26;
            this.bInitializeAndConnect.Text = " Initialize and connect";
            this.bInitializeAndConnect.UseVisualStyleBackColor = true;
            this.bInitializeAndConnect.Click += new System.EventHandler(this.bInitializeAndConnect_Click);
            // 
            // lbSensorState
            // 
            this.lbSensorState.BackColor = System.Drawing.SystemColors.Control;
            this.lbSensorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSensorState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSensorState.ForeColor = System.Drawing.Color.Red;
            this.lbSensorState.Location = new System.Drawing.Point(94, 41);
            this.lbSensorState.Name = "lbSensorState";
            this.lbSensorState.Size = new System.Drawing.Size(94, 20);
            this.lbSensorState.TabIndex = 25;
            this.lbSensorState.Text = "Not connected";
            this.lbSensorState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSDKState
            // 
            this.lbSDKState.BackColor = System.Drawing.SystemColors.Control;
            this.lbSDKState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSDKState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSDKState.ForeColor = System.Drawing.Color.Red;
            this.lbSDKState.Location = new System.Drawing.Point(94, 15);
            this.lbSDKState.Name = "lbSDKState";
            this.lbSDKState.Size = new System.Drawing.Size(94, 20);
            this.lbSDKState.TabIndex = 24;
            this.lbSDKState.Text = " Not runing";
            this.lbSDKState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bRunSDK
            // 
            this.bRunSDK.Location = new System.Drawing.Point(194, 15);
            this.bRunSDK.Name = "bRunSDK";
            this.bRunSDK.Size = new System.Drawing.Size(125, 21);
            this.bRunSDK.TabIndex = 7;
            this.bRunSDK.Text = "Run Kai SDK service";
            this.bRunSDK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRunSDK.UseVisualStyleBackColor = true;
            this.bRunSDK.Click += new System.EventHandler(this.bRunSDK_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kai sensor state";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kai SDK state";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Silver;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(593, 20);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "MyKai - Gesture Control Module";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDesktopMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 712);
            this.ControlBox = false;
            this.Controls.Add(this.pnTitleBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDesktopMode";
            this.Text = "Desktop mode manager";
            this.Load += new System.EventHandler(this.FrmDesktopMode_Load);
            this.pnTitleBar.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            this.gbUserGestures.ResumeLayout(false);
            this.pnBottoom.ResumeLayout(false);
            this.pnBottoom.PerformLayout();
            this.tcDetails.ResumeLayout(false);
            this.tpLogging.ResumeLayout(false);
            this.tpDrawTest.ResumeLayout(false);
            this.gbTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitleBar;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnBottoom;
        private System.Windows.Forms.Label lbDetailLevelDescription;
        private System.Windows.Forms.Button bShowLessMore;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TabControl tcDetails;
        private System.Windows.Forms.TabPage tpLogging;
        private Forms.KaiMessageLogUserControlLocal ucKaiLoggingDesktopForm;
        private System.Windows.Forms.TabPage tpDrawTest;
        private System.Windows.Forms.Panel pnDrawGestureTmp;
        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnDistanceTop;
        private System.Windows.Forms.Button bRunSDK;
        private System.Windows.Forms.Label lbSDKState;
        private System.Windows.Forms.Label lbSensorState;
        private System.Windows.Forms.Button bInitializeAndConnect;
        private System.Windows.Forms.Button bStartGestureCapture;
        private System.Windows.Forms.TextBox tbSegmenterState;
        private System.Windows.Forms.Label lbSegmenterState;
        private System.Windows.Forms.GroupBox gbUserGestures;
        private System.Windows.Forms.FlowLayoutPanel flpGestures;
        private System.Windows.Forms.Panel pnDistanceBottom;
    }
}