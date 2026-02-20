using MyKai.Manager;
using MyKai.Communicator;
using System.Windows.Forms;

namespace MyKai.General
{
   internal class BuilderOfDefKaiManager : MyKaiBuilderBase<DefKaiManager>
    {
        public BuilderOfDefKaiManager WithKaiCommunicator(IKaiCommunicator pCommunicator)
        {
            instance.SetKaiCommunicator(pCommunicator);
            return this;
        }

        public BuilderOfDefKaiManager WithParentControl(ContainerControl pParentControl)
        {
            instance.SetParentControl(pParentControl);
            return this;
        }
    }
}
