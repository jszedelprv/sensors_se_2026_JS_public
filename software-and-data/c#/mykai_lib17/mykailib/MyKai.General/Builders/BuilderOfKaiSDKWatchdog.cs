using MyKai.Manager;

namespace MyKai.General
{
    internal class BuilderOfKaiSDKWatchdog : MyKaiBuilderBase<KaiSDKWatchdog>
    {
        public BuilderOfKaiSDKWatchdog() { }

        public BuilderOfKaiSDKWatchdog WithUpdateSDKStatusFunction(UpdateSDKStatusFunctionType pUpdateStatusFunction)
        {
            instance.UpdateSDKStatusFunction = pUpdateStatusFunction;
            return this;
        }
    }
}
