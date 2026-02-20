using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKai.GUI
{
    public interface IKaiStatusViewingControl
    {
        void UpdateKaiSDKStatusControls();
        void UpdateKaiSensorStatusControls();
    }
}
