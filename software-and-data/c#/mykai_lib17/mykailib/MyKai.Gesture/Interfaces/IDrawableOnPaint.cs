using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.Gesture
{
    public interface IDrawableOnPaint
    {
        void DrawOnTargetControlPaint(object sender, System.Windows.Forms.PaintEventArgs e);
    }
}
