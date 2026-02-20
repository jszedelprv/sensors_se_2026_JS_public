
namespace kaibasic
{
    partial class FrmMainRawData
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.gbMessageParams = new System.Windows.Forms.GroupBox();
            this.bClearData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.cbIncludeType = new System.Windows.Forms.CheckBox();
            this.tbCounterValue = new System.Windows.Forms.TextBox();
            this.bResetCounter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIncludeCounter = new System.Windows.Forms.CheckBox();
            this.bSaveData = new System.Windows.Forms.Button();
            this.cbShowData = new System.Windows.Forms.CheckBox();
            this.gbRawData = new System.Windows.Forms.GroupBox();
            this.rbResult = new System.Windows.Forms.RichTextBox();
            this.cbIncludeMessageTime = new System.Windows.Forms.CheckBox();
            this.pnTop.SuspendLayout();
            this.gbMessageParams.SuspendLayout();
            this.gbRawData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.gbMessageParams);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(956, 122);
            this.pnTop.TabIndex = 0;
            // 
            // gbMessageParams
            // 
            this.gbMessageParams.Controls.Add(this.cbIncludeMessageTime);
            this.gbMessageParams.Controls.Add(this.bClearData);
            this.gbMessageParams.Controls.Add(this.label1);
            this.gbMessageParams.Controls.Add(this.tbSeparator);
            this.gbMessageParams.Controls.Add(this.cbIncludeType);
            this.gbMessageParams.Controls.Add(this.tbCounterValue);
            this.gbMessageParams.Controls.Add(this.bResetCounter);
            this.gbMessageParams.Controls.Add(this.label2);
            this.gbMessageParams.Controls.Add(this.cbIncludeCounter);
            this.gbMessageParams.Controls.Add(this.bSaveData);
            this.gbMessageParams.Controls.Add(this.cbShowData);
            this.gbMessageParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbMessageParams.Location = new System.Drawing.Point(0, 0);
            this.gbMessageParams.Name = "gbMessageParams";
            this.gbMessageParams.Size = new System.Drawing.Size(495, 122);
            this.gbMessageParams.TabIndex = 1;
            this.gbMessageParams.TabStop = false;
            this.gbMessageParams.Text = "Raw data options";
            // 
            // bClearData
            // 
            this.bClearData.Location = new System.Drawing.Point(284, 93);
            this.bClearData.Name = "bClearData";
            this.bClearData.Size = new System.Drawing.Size(96, 22);
            this.bClearData.TabIndex = 22;
            this.bClearData.Text = "Clear data";
            this.bClearData.UseVisualStyleBackColor = true;
            this.bClearData.Click += new System.EventHandler(this.bClearData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Counter value";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSeparator
            // 
            this.tbSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSeparator.Location = new System.Drawing.Point(284, 47);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(96, 20);
            this.tbSeparator.TabIndex = 20;
            this.tbSeparator.Text = ";";
            // 
            // cbIncludeType
            // 
            this.cbIncludeType.AutoSize = true;
            this.cbIncludeType.Checked = true;
            this.cbIncludeType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeType.Location = new System.Drawing.Point(12, 46);
            this.cbIncludeType.Name = "cbIncludeType";
            this.cbIncludeType.Size = new System.Drawing.Size(134, 17);
            this.cbIncludeType.TabIndex = 19;
            this.cbIncludeType.Text = "Include event indicator";
            this.cbIncludeType.UseVisualStyleBackColor = true;
            // 
            // tbCounterValue
            // 
            this.tbCounterValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCounterValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCounterValue.Location = new System.Drawing.Point(284, 23);
            this.tbCounterValue.Name = "tbCounterValue";
            this.tbCounterValue.ReadOnly = true;
            this.tbCounterValue.Size = new System.Drawing.Size(96, 20);
            this.tbCounterValue.TabIndex = 17;
            this.tbCounterValue.Text = "0";
            // 
            // bResetCounter
            // 
            this.bResetCounter.Location = new System.Drawing.Point(386, 22);
            this.bResetCounter.Name = "bResetCounter";
            this.bResetCounter.Size = new System.Drawing.Size(96, 22);
            this.bResetCounter.TabIndex = 14;
            this.bResetCounter.Text = "Reset counter";
            this.bResetCounter.UseVisualStyleBackColor = true;
            this.bResetCounter.Click += new System.EventHandler(this.bResetCounter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Separator";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIncludeCounter
            // 
            this.cbIncludeCounter.Location = new System.Drawing.Point(12, 69);
            this.cbIncludeCounter.Name = "cbIncludeCounter";
            this.cbIncludeCounter.Size = new System.Drawing.Size(120, 17);
            this.cbIncludeCounter.TabIndex = 2;
            this.cbIncludeCounter.Text = "Include row counter";
            this.cbIncludeCounter.UseVisualStyleBackColor = true;
            // 
            // bSaveData
            // 
            this.bSaveData.Location = new System.Drawing.Point(386, 93);
            this.bSaveData.Name = "bSaveData";
            this.bSaveData.Size = new System.Drawing.Size(96, 22);
            this.bSaveData.TabIndex = 1;
            this.bSaveData.Text = "Save data ...";
            this.bSaveData.UseVisualStyleBackColor = true;
            this.bSaveData.Click += new System.EventHandler(this.bSaveData_Click);
            // 
            // cbShowData
            // 
            this.cbShowData.AutoSize = true;
            this.cbShowData.Checked = true;
            this.cbShowData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowData.Location = new System.Drawing.Point(12, 25);
            this.cbShowData.Name = "cbShowData";
            this.cbShowData.Size = new System.Drawing.Size(156, 17);
            this.cbShowData.TabIndex = 0;
            this.cbShowData.Text = "Capture and show raw data";
            this.cbShowData.UseVisualStyleBackColor = true;
            // 
            // gbRawData
            // 
            this.gbRawData.Controls.Add(this.rbResult);
            this.gbRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRawData.Location = new System.Drawing.Point(0, 122);
            this.gbRawData.Name = "gbRawData";
            this.gbRawData.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.gbRawData.Size = new System.Drawing.Size(956, 486);
            this.gbRawData.TabIndex = 6;
            this.gbRawData.TabStop = false;
            this.gbRawData.Text = "Events\' raw data";
            // 
            // rbResult
            // 
            this.rbResult.BackColor = System.Drawing.Color.LightGray;
            this.rbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbResult.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rbResult.Location = new System.Drawing.Point(8, 19);
            this.rbResult.Name = "rbResult";
            this.rbResult.Size = new System.Drawing.Size(940, 459);
            this.rbResult.TabIndex = 2;
            this.rbResult.Text = "";
            this.rbResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rbResult_KeyPress);
            // 
            // cbIncludeMessageTime
            // 
            this.cbIncludeMessageTime.AutoSize = true;
            this.cbIncludeMessageTime.Location = new System.Drawing.Point(12, 91);
            this.cbIncludeMessageTime.Name = "cbIncludeMessageTime";
            this.cbIncludeMessageTime.Size = new System.Drawing.Size(128, 17);
            this.cbIncludeMessageTime.TabIndex = 7;
            this.cbIncludeMessageTime.Text = "Include message time";
            this.cbIncludeMessageTime.UseVisualStyleBackColor = false;
            // 
            // FrmMainRawData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRawData);
            this.Controls.Add(this.pnTop);
            this.Name = "FrmMainRawData";
            this.Size = new System.Drawing.Size(956, 608);
            this.pnTop.ResumeLayout(false);
            this.gbMessageParams.ResumeLayout(false);
            this.gbMessageParams.PerformLayout();
            this.gbRawData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.GroupBox gbMessageParams;
        private System.Windows.Forms.CheckBox cbIncludeCounter;
        private System.Windows.Forms.Button bSaveData;
        private System.Windows.Forms.CheckBox cbShowData;
        private System.Windows.Forms.GroupBox gbRawData;
        private System.Windows.Forms.RichTextBox rbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bResetCounter;
        private System.Windows.Forms.TextBox tbCounterValue;
        private System.Windows.Forms.CheckBox cbIncludeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.Button bClearData;
        private System.Windows.Forms.CheckBox cbIncludeMessageTime;
    }
}
