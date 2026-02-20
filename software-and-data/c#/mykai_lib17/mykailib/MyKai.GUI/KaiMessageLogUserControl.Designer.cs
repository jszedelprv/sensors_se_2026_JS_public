namespace MyKai.GUI
{
    public partial class KaiMessageLogUserControl
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
            this.pnMessagesTop = new System.Windows.Forms.Panel();
            this.gbMessageParams = new System.Windows.Forms.GroupBox();
            this.cbIncludeCounter = new System.Windows.Forms.CheckBox();
            this.bSaveMemo = new System.Windows.Forms.Button();
            this.cbShowMessages = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.rbLoggedMessages = new System.Windows.Forms.RichTextBox();
            this.tmConnectionTimeout = new System.Windows.Forms.Timer(this.components);
            this.pnMessagesTop.SuspendLayout();
            this.gbMessageParams.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMessagesTop
            // 
            this.pnMessagesTop.Controls.Add(this.gbMessageParams);
            this.pnMessagesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMessagesTop.Location = new System.Drawing.Point(0, 0);
            this.pnMessagesTop.Name = "pnMessagesTop";
            this.pnMessagesTop.Size = new System.Drawing.Size(1178, 76);
            this.pnMessagesTop.TabIndex = 5;
            // 
            // gbMessageParams
            // 
            this.gbMessageParams.Controls.Add(this.cbIncludeCounter);
            this.gbMessageParams.Controls.Add(this.bSaveMemo);
            this.gbMessageParams.Controls.Add(this.cbShowMessages);
            this.gbMessageParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbMessageParams.Location = new System.Drawing.Point(0, 0);
            this.gbMessageParams.Name = "gbMessageParams";
            this.gbMessageParams.Size = new System.Drawing.Size(449, 76);
            this.gbMessageParams.TabIndex = 0;
            this.gbMessageParams.TabStop = false;
            this.gbMessageParams.Text = "Message options";
            // 
            // cbIncludeCounter
            // 
            this.cbIncludeCounter.AutoSize = true;
            this.cbIncludeCounter.Location = new System.Drawing.Point(10, 49);
            this.cbIncludeCounter.Name = "cbIncludeCounter";
            this.cbIncludeCounter.Size = new System.Drawing.Size(145, 17);
            this.cbIncludeCounter.TabIndex = 2;
            this.cbIncludeCounter.Text = "Include message counter";
            this.cbIncludeCounter.UseVisualStyleBackColor = true;
            // 
            // bSaveMemo
            // 
            this.bSaveMemo.Location = new System.Drawing.Point(335, 47);
            this.bSaveMemo.Name = "bSaveMemo";
            this.bSaveMemo.Size = new System.Drawing.Size(106, 22);
            this.bSaveMemo.TabIndex = 1;
            this.bSaveMemo.Text = "Save messages ...";
            this.bSaveMemo.UseVisualStyleBackColor = true;
            this.bSaveMemo.Click += new System.EventHandler(this.bSaveMemo_Click);
            // 
            // cbShowMessages
            // 
            this.cbShowMessages.AutoSize = true;
            this.cbShowMessages.Checked = true;
            this.cbShowMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowMessages.Location = new System.Drawing.Point(10, 25);
            this.cbShowMessages.Name = "cbShowMessages";
            this.cbShowMessages.Size = new System.Drawing.Size(162, 17);
            this.cbShowMessages.TabIndex = 0;
            this.cbShowMessages.Text = "Capture and show messages";
            this.cbShowMessages.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 4);
            this.panel1.TabIndex = 6;
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.rbLoggedMessages);
            this.gbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResults.Location = new System.Drawing.Point(0, 80);
            this.gbResults.Name = "gbResults";
            this.gbResults.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.gbResults.Size = new System.Drawing.Size(1178, 559);
            this.gbResults.TabIndex = 7;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Events/messages";
            // 
            // rbLoggedMessages
            // 
            this.rbLoggedMessages.BackColor = System.Drawing.Color.Black;
            this.rbLoggedMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbLoggedMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbLoggedMessages.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbLoggedMessages.ForeColor = System.Drawing.Color.Lime;
            this.rbLoggedMessages.Location = new System.Drawing.Point(8, 19);
            this.rbLoggedMessages.Name = "rbLoggedMessages";
            this.rbLoggedMessages.Size = new System.Drawing.Size(1162, 532);
            this.rbLoggedMessages.TabIndex = 2;
            this.rbLoggedMessages.Text = "";
            // 
            // tmConnectionTimeout
            // 
            this.tmConnectionTimeout.Interval = 500;
            this.tmConnectionTimeout.Tick += new System.EventHandler(this.tmConnectionTimeout_Tick);
            // 
            // KaiMessageLogUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnMessagesTop);
            this.Name = "KaiMessageLogUserControl";
            this.Size = new System.Drawing.Size(1178, 639);
            this.pnMessagesTop.ResumeLayout(false);
            this.gbMessageParams.ResumeLayout(false);
            this.gbMessageParams.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMessagesTop;
        private System.Windows.Forms.GroupBox gbMessageParams;
        private System.Windows.Forms.CheckBox cbIncludeCounter;
        private System.Windows.Forms.Button bSaveMemo;
        private System.Windows.Forms.CheckBox cbShowMessages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.RichTextBox rbLoggedMessages;
        private System.Windows.Forms.Timer tmConnectionTimeout;
    }
}
