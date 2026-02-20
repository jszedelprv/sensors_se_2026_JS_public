using System;
using System.Linq;
using System.Windows.Forms;

namespace MyKai.General
{
    public class KaiControlNotifier
    {
        Control targetControl;
        public Control TargetControl { get => targetControl; set { targetControl = value; } }

        public delegate void OnNotifyFunctionDelegate(object[] pArgs = null);

        OnNotifyFunctionDelegate targetFunction;
        public OnNotifyFunctionDelegate TrargetFunction { get => targetFunction; set { targetFunction = value; } }

        public void SendMessage(object[] pArgs = null)
        {
            //lock (targetControl)
            //{
                try
                {
                    bool controlExists = Application.OpenForms.OfType<Control>().Any();

                    if (controlExists && targetControl.InvokeRequired)
                        targetControl.Invoke(targetFunction, pArgs);
                    else
                        targetFunction(pArgs);
                }
                catch (Exception)
                {
                    return;
            } // Ignore ivoking messages after form is colosed, not a good practice but ok for now
            //}
        }
    }
}
