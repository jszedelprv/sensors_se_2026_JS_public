using System.Windows.Forms;

namespace MyKai.Gesture
{
    public interface IGestureViewPanelHostedControl : IKaiGestureViewableControl
    {
        Panel HostingPanel { get; set; }
        bool IsHosted { get; set; }
    }
}