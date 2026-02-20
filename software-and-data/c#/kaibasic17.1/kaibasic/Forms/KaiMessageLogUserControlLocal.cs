using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyKai.GUI;


namespace kaibasic.Forms
{
    public partial class KaiMessageLogUserControlLocal : KaiMessageLogUserControl // Duplicated to not cause the problem with the designer
                                                                                  // This is a workaround to avoid the issue with the designer not
                                                                                  // generating the control name space qualifiers properly
    {
        public KaiMessageLogUserControlLocal()
        {
            InitializeComponent();
        }

        //public KaiMessageLogUserControl AsBase()
        //{
        //    return this as KaiMessageLogUserControl;
        //}
    }
}
