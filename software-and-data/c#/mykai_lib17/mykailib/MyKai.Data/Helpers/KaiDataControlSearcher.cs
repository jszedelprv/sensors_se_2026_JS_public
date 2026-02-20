using System;
using System.Windows.Forms;

namespace MyKai.Data
{
    public abstract class ControlFinderTaskBase
    {
        protected Control ParentControl;
        public ControlFinderTaskBase(Control pParentControl)
        {
            ParentControl = pParentControl;
        }
    }

    public class KaiDataControlSearcher
    {

        public FindControlTask FindControl;
        public KaiDataControlSearcher (Control pParentControl)
        {
            FindControl = new FindControlTask(pParentControl);
        }

        public class FindControlTask : ControlFinderTaskBase
        {
            public FindControlTask(Control pParentControl) : base(pParentControl) { }
            
            public Control ByName(string pControlName)
            {
                try
                {
                    return ParentControl.Controls.Find(pControlName, true)[0]; // Assuming there's only one control matching the pControlName parameter
                }
                catch (IndexOutOfRangeException e)
                {
                    MessageBox.Show(GetType().Name + " : Control [" + pControlName + "] not found. System will exit.");
                    Environment.Exit(e.HResult);
                    return null;
                }
            }
        }
    }
}
