using System;
using System.Windows.Forms;
using System.Linq;
using kaibasic;
using System.ComponentModel;

namespace MyKai.Communicator
{
    // Implements communication interface of DefKaiManager
    internal class FormKaiCommunicator : KaiCommunicatorBase
    {
        private Form targetForm;
        private IKaiCommunicable targetCommunicableControl;

        public FormKaiCommunicator(){}

        // Interface's methods atr called from other thread, thus the use of
        // Form.Invoke method is required

        // Constructor
        public FormKaiCommunicator(Form pFormToCommunicate)
        {
            targetForm = pFormToCommunicate;
            targetCommunicableControl = (IKaiCommunicable)pFormToCommunicate;
            
            KaiMessageDelegate = targetCommunicableControl.GetKaiMessagetDelegate();
            KaiSpecialActionDelegate = targetCommunicableControl.GetKaiSpecialActionDelegate();
        }



        // Interface method implementations
        override public void InformKaiEventRaised()
        {
            // Lock form and invoke the method stored in AddMessageDelegate
            lock (targetForm)
            {
                Type formToCommunicateType = targetForm.GetType();
                try
                {
                    bool formexists = targetCommunicableControl.CheckIfFormExists();
                    string[] args = new string[] { };

                    if (formexists && targetForm.InvokeRequired)
                        targetForm.Invoke(KaiMessageDelegate, args);
                }
                catch (Exception)
                {
                    return;
                } // Ignore ivoking messages after form is colosed
            }
        }

        public override void InformSpecialActionNeeded()
        {
            // Lock form and invoke the method stored in AddMessageDelegate
            lock (targetForm)
            {
                try
                {
                    bool formexists = targetCommunicableControl.CheckIfFormExists();
                    string[] args = new string[] { };

                    if (formexists && targetForm.InvokeRequired)
                        targetForm.Invoke(KaiSpecialActionDelegate, args);
                    else
                        KaiSpecialActionDelegate();
                }
                catch (Exception)
                {
                    return;
                } // Ignore ivoking messages after form is colosed
            }
        }
    }
}
