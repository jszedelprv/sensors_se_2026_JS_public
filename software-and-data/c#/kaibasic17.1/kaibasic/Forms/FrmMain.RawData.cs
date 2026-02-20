using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace kaibasic
{
    public partial class FrmMainRawData : UserControl
    {
        FrmMain mainForm;
        int messageCount;
        DateTime lastCountTime = DateTime.MinValue;
        TimeSpan timeSinceLastCount;

        public FrmMainRawData()
        {
            InitializeComponent();
            ResetCounter();
        }
        
        public void SetMainForm(FrmMain pParent)
        {
            mainForm = pParent;
        }

        public bool IsRawDataCapturingOn
        {
            get => cbShowData.Checked;
        }

        public void AddDataRow(object [] pDataItems, string pEventPrefix)
        {
            int currentDacimationFactor = mainForm.GetPYRDecimationFactor();
            messageCount++;
            tbCounterValue.Text = messageCount.ToString();
            float messagesPerSecond;

            if (cbIncludeCounter.Checked)
                rbResult.Text += messageCount.ToString() + tbSeparator.Text;

            // fast workaround to include time info (manuscript - time visualization purpose)
            if (cbIncludeMessageTime.Checked)
            {
                messagesPerSecond = CountMessagesPerSecond();
                rbResult.Text += //DateTime.Now.ToString("HH:mm:ss.fff") + tbSeparator.Text + 
                                 //lastCountTime.ToString("HH:mm:ss.fff") + tbSeparator.Text + 
                                 currentDacimationFactor.ToString() + tbSeparator.Text +
                                 timeSinceLastCount.ToString("hh\\:mm\\:ss\\.fff") + tbSeparator.Text; // +
                                 //messagesPerSecond.ToString("F2") + tbSeparator.Text;
            }

            //fast workaround to increase decimation factor every 20 messages (manuscript - time visualization purpose)
            if (messageCount % 20 == 0)
                if (currentDacimationFactor == 0)
                    mainForm.SetPYRDecimationControls(2);
                else if (currentDacimationFactor >= 2)
                    mainForm.SetPYRDecimationControls(currentDacimationFactor + 2);

            if (cbIncludeType.Checked)
                rbResult.Text += pEventPrefix + tbSeparator.Text;

            //foreach (object o in pDataItems)
            //    rbResult.Text += o.ToString() + tbSeparator.Text;

            rbResult.Text += Environment.NewLine;

            rbResult.SelectionStart = rbResult.Text.Length;
            rbResult.ScrollToCaret();
            rbResult.Refresh();
        }

        private float CountMessagesPerSecond()
        {
            float messagesPerSecond;

            if (lastCountTime == DateTime.MinValue)
            {
                lastCountTime = DateTime.Now;
                return 0.0f;
            }

            timeSinceLastCount = (DateTime.Now - lastCountTime);
            messagesPerSecond = messageCount / (float)(DateTime.Now - lastCountTime).TotalSeconds;
            lastCountTime = DateTime.Now;
            
            return messagesPerSecond;
        }

        private void ResetCounter()
        {
            messageCount = 0;
            lastCountTime = DateTime.MinValue;
        }

        private void bResetCounter_Click(object sender, EventArgs e)
        {
            messageCount = 0;
            tbCounterValue.Text = messageCount.ToString();
        }

        private void bClearData_Click(object sender, EventArgs e)
        {
            rbResult.Clear();
        }

        private void bSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            Stream stream;

            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            sfd.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Save raw event data";


            if (sfd.ShowDialog(this) == DialogResult.OK && sfd.FileName != "")
            {
                stream = sfd.OpenFile();
                rbResult.SaveFile(stream, RichTextBoxStreamType.PlainText);
                stream.Close();
            }
        }

        public void ConfigureForPYRGestureCapture()
        {
            cbShowData.Checked = false;
        }

        private void rbResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
