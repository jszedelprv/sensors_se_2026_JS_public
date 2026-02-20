using System.Windows.Forms;

namespace MyKai.General
{
    public class BuilderOFKaiControlNotifier : MyKaiBuilderBase<KaiControlNotifier>
    {
        public override bool IsInstanceBuildComplette()
        {
            if (instance.TargetControl != null && instance.TrargetFunction != null)
                return base.IsInstanceBuildComplette();
            else
                return false;
        }

        public BuilderOFKaiControlNotifier WithTargetControl(Control pControl)
        {
            instance.TargetControl = pControl;
            return this;
        }

        public BuilderOFKaiControlNotifier WithTargetFunction(KaiControlNotifier.OnNotifyFunctionDelegate pFunction)
        {
            instance.TrargetFunction = pFunction;
            return this;
        }
    }
}
