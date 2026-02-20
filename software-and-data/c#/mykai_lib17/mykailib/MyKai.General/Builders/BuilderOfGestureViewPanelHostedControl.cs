using System.Windows.Forms;
using MyKai.Gesture;

namespace MyKai.General
{
    public class BuilderOfGestureViewPanelHostedControl : MyKaiBuilderBase<GestureViewPanelHostedControl> // TODO: correct the error - this is in fact the builder of GestureViewPanelHostedControl not the general GestureViewControl
    {
        public BuilderOfGestureViewPanelHostedControl WithHostingPanel(Panel pHostingPanel)
        {
            instance.HostingPanel = pHostingPanel;
            return this;
        }
    }
}
