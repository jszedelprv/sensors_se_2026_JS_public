namespace MyKai.Gesture
{
    partial class FrmBitmapTestViewer
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
            this.pnBitmap = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnBitmap
            // 
            this.pnBitmap.BackColor = System.Drawing.Color.White;
            this.pnBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBitmap.Location = new System.Drawing.Point(0, 0);
            this.pnBitmap.Name = "pnBitmap";
            this.pnBitmap.Size = new System.Drawing.Size(800, 450);
            this.pnBitmap.TabIndex = 0;
            this.pnBitmap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBitmap_Paint);
            // 
            // FrmBitmapTestViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnBitmap);
            this.Name = "FrmBitmapTestViewer";
            this.Text = "Bitmap test viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBitmap;
    }
}