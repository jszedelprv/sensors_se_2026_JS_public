using System;
using System.Windows.Forms;
using System.IO;

using MyKai.Manager;
using MyKai.Properties;
using MyKai.General;

namespace MyKai.GUI
{
    public partial class KaiMessageLogUserControl : UserControl, IKaiMessageLogUserControl
    {
        KaiEventLoggerBase kaiEventLogger;

        public IKaiEventLogger KaiEventLogger => kaiEventLogger;

        int connectionWaitCounter;
        int messageCount = 0;

        public KaiMessageLogUserControl()
        {
            InitializeComponent();
            MakeKaiEventLogger();
        }

        // Logging functionality

        private void MakeKaiEventLogger()
        {
            kaiEventLogger = new BuilderOfRichTextBoxEventLoger().WithRichTextBox(rbLoggedMessages).Build();
        }

        #region

        public void AddLogMessage(string pMessage)
        {
            kaiEventLogger.IncludeMessageCounter = cbIncludeCounter.Checked;
            kaiEventLogger.AddMessage(pMessage);
        }

        public void AddInitialLogMessage()
        {
            AddLogMessage(MyKaiStrings.Default.msgConnectionWait + " {          }");
        }

        private void SaveMessages()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            Stream stream;

            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Save messages";


            if (sfd.ShowDialog(this) == DialogResult.OK && sfd.FileName != "")
            {
                stream = sfd.OpenFile();
                rbLoggedMessages.SaveFile(stream, RichTextBoxStreamType.PlainText);
                stream.Close();
            }
        }

        #endregion

        // Show textual progressbar in the message window, supply timeout if not connected for certain time 
        #region

        private void ShowWaitTickMessage()
        {
            int totalLines = rbLoggedMessages.Lines.Length;
            string[] lines = rbLoggedMessages.Lines;

            string progressBarString = MakeProgressBarString();

            lines[totalLines - 2] = " >  " + (cbIncludeCounter.Checked ? "[" + (messageCount).ToString() + "] " : "")
                + MyKaiStrings.Default.msgConnectionWait + progressBarString;

            rbLoggedMessages.Lines = lines;
            rbLoggedMessages.Refresh();
        }

        private string MakeProgressBarString()
        {
            string progressBarString = " {";

            for (int i = 0; i < MyKaiSettings.Default.kaiConnectionTimeoutCounterMax; i++)
                if (i < connectionWaitCounter)
                    progressBarString += "*";
                else
                    progressBarString += " ";

            progressBarString += "}";

            return progressBarString;
        }

        public void ActivateConnectionWait()
        {
            tmConnectionTimeout.Enabled = true;
            connectionWaitCounter = 0;
        }

        public void DeactivateConnectionWait()
        {
            tmConnectionTimeout.Enabled = false;
            connectionWaitCounter = 0;
        }

        #endregion

        // ------------------------------------------------------------------------------
        // Other components
        // ------------------------------------------------------------------------------

        public bool IsLoggingOn
        {
            get
            {
                return cbShowMessages.Checked;
            }

            set
            {
                cbShowMessages.Checked = value;
            }
        }

        // ------------------------------------------------------------------------------
        // User control event handlers
        // ------------------------------------------------------------------------------

        private void bSaveMemo_Click(object sender, EventArgs e)
        {
            SaveMessages();
        }

        private void tmConnectionTimeout_Tick(object sender, EventArgs e)
        {
            bool sensorConnected = KaiSession.Query.IsSensorConnected();

            if (sensorConnected)
            {
                DeactivateConnectionWait();
                AddLogMessage(MyKaiStrings.Default.msgConnectionSuccessful);
            }
            else
            {
                if (connectionWaitCounter >= MyKaiSettings.Default.kaiConnectionTimeoutCounterMax)
                {
                    DeactivateConnectionWait();
                    AddLogMessage(MyKaiStrings.Default.msgKaiNotResponding);
                    MessageBox.Show(this, MyKaiStrings.Default.msgKaiNotResponding, MyKaiStrings.Default.strKaiMessageboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                connectionWaitCounter++;
                ShowWaitTickMessage();
            }
        }
    }
}
