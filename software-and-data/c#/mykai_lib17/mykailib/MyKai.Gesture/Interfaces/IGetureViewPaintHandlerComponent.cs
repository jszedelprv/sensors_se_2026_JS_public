using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKai.Gesture
{
    public interface IGetureViewPaintHandlerComponent
    {
        void AddPaintEvent(Control pControl);
        void GestureControl_Paint(object sender, PaintEventArgs e);
    }
}
