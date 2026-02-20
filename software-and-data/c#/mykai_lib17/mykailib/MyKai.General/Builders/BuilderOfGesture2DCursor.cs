
using MyKai.Gesture;
using System.Windows.Forms;

namespace MyKai.General
{
    internal class BuilderOfGesture2DCursor : MyKaiBuilderBase<Gesture2DCursor>
    {
        public BuilderOfGesture2DCursor()
        {
            instance.GestureData = MyKaiFactory.Produce<Gesture2DCursorData>();
            instance.LastData = MyKaiFactory.Produce<Gesture2DCursorData>();
            instance.StateMachine = MyKaiFactory.Produce<Gesture2DCursorStateMachine>();
            instance.IsStableChcecker = MyKaiFactory.Produce<Gesture2DIsStableChecker>();
            instance.LastState = Gesture2DCursorStateMachine.StateType.Undefined;
        }

        public BuilderOfGesture2DCursor WithAngleLimit(float pAngleLimit)
        {
            instance.AngleLimit = pAngleLimit;

            return this;
        }

        public BuilderOfGesture2DCursor WithViewPortSize(int pWidth, int pHeight) 
        {
            instance.SetViewportSize(pWidth, pHeight);

            return this;
        }

        public BuilderOfGesture2DCursor WithKaiControlCommunicator(Control pControl, KaiControlNotifier.OnNotifyFunctionDelegate pFunction)
        {
            instance.StepMadeNotifier = new BuilderOFKaiControlNotifier()
                                            .WithTargetControl(pControl)
                                            .WithTargetFunction(pFunction)
                                            .Build();
            return this;
        }

        public BuilderOfGesture2DCursor WithStateMachineParams(Gesture2DCursorStateMachine.StateParamsStruct pStateMachineParams)
        {
            instance.StateMachine.StateParams = pStateMachineParams;

            return this;
        }
    }
}
