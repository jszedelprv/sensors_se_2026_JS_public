using System.Windows.Forms;
using MyKai.Manager;
using MyKai.Gesture;

using System;
using MyKai.GUI;
using MyKai.General;

// To improve hermetization od the MyKai library, standard MyKai builder methods are not used here.
// Instead of using the standard MyKaiBuilderBase<T>, a separate independant builder is created.
// Standard builders are located in the MyKai.General namespace (MyKai.General.Builders folder).

namespace MyKai.Facade
{
    public class BuilderOfMyKaiFacade
    {
        MyKaiFacade instance;

        public BuilderOfMyKaiFacade()
        {
            instance = new MyKaiFacade();
        }

        bool IsInstanceBuildComplette()
        {
            bool result = true;

            result &= instance.Get != null;
            result &= instance.Set != null;
            result &= instance.ComponentHolder != null;
            result &= instance.ComponentHolder.ownerControl != null;
            result &= instance.ComponentInitializer != null;
            result &= instance.ComponentHolder.gestureViewControl != null;
            result &= instance.ComponentHolder.gestureCursorParams != null;
            result &= instance.ComponentHolder.gesture2DCapture != null;
            result &= !(instance.ComponentHolder.gesture2DCapture.Query.IsViewCursorNull());

            if (instance.ComponentHolder.gestureViewControl is GestureViewPanelHostedControl)
                result &= instance.ComponentHolder.gestureViewHostingPanel != null; 
                // If the gesture view control is a panel hosted control, the hosting panel must be set.

            result &= instance.ComponentHolder.kaiEventLogger != null;
            result &= instance.ComponentHolder.kaiMessageLogUserControl != null;
            result &= instance.ComponentHolder.kaiSDKWatchdog != null; 

            return result;
        }

        public MyKaiFacade Build()
        {
            try
            {
                if (IsInstanceBuildComplette())
                    return instance;
                else
                    throw new NullReferenceException($"{this.GetType().Name}.Build(): Can't build the instance. Not all required members/dependencies are set for class: MyKaiFacade");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return instance;
            }
        }

        public BuilderOfMyKaiFacade WithNewSubobjects()
        {
            instance.Get = new MyKaiFacade.GetSubclass(instance);
            instance.Set = new MyKaiFacade.SetSubclass(instance);
            instance.Action = new MyKaiFacade.ActionSubclass(instance);
            instance.Query = new MyKaiFacade.QuerySubclass(instance);
            instance.ComponentHolder = new FacadeComponentHolder();
            
            return this;
        }

        public BuilderOfMyKaiFacade WithNewInitializer()
        {
            instance.ComponentInitializer = new FacadeComponentInitializer(instance);
            
            return this;
        }

        public BuilderOfMyKaiFacade WithOwnerControl(ContainerControl pOwnerControl)
        {
            instance.ComponentHolder.ownerControl = pOwnerControl;
            
            return this;
        }

        public BuilderOfMyKaiFacade WithGestureViewHostingPanel(Panel pGestureViewHostingPanel)
        {
            instance.ComponentHolder.gestureViewHostingPanel = pGestureViewHostingPanel;
            
            return this;
        }

        public BuilderOfMyKaiFacade WithGestureCursorParams(GestureCursorParams pGestureCursorParams)
        {
            instance.ComponentHolder.gestureCursorParams = pGestureCursorParams;
            
            return this;
        }

        public BuilderOfMyKaiFacade WithNewGestureViewPanelHostedControl()
        {
            instance.ComponentHolder.gestureViewControl = new BuilderOfGestureViewPanelHostedControl()
                    .WithHostingPanel(instance.ComponentHolder.gestureViewHostingPanel)
                    .Build();

            return this;
        }

        public BuilderOfMyKaiFacade WithGestureViewFormOverlay(GestureViewFormOverlay pGestureViewFormOveray)
        {
            instance.ComponentHolder.gestureViewControl = pGestureViewFormOveray;

            return this;
        }


        public BuilderOfMyKaiFacade WithOtherInitialActions()
        {
            instance.ComponentInitializer.PerformInitActions();
            return this;
        }

        public BuilderOfMyKaiFacade WithEventDecimationRates(int pQuaternionDeimatioRate, int pPYRDecimationRate)
        {
            instance.ComponentHolder.kaiManager.SetEventDecimation(KaiEventType.QuaternionEvent, pQuaternionDeimatioRate);
            instance.ComponentHolder.kaiManager.SetEventDecimation(KaiEventType.PYREvent, pPYRDecimationRate);
            return this;
        }

        public BuilderOfMyKaiFacade WithEventLogger(IKaiEventLogger pKaiEventLogger)
        {
            instance.ComponentHolder.kaiEventLogger = pKaiEventLogger;
            return this;
        }

        public BuilderOfMyKaiFacade WithKaiMassageLogUserControl(IKaiMessageLogUserControl pKaiMessageLogUserControl)
        {
            instance.ComponentHolder.kaiMessageLogUserControl = pKaiMessageLogUserControl;
            return this;
        }

        public BuilderOfMyKaiFacade WithNewKaiSDKWatchdog(UpdateSDKStatusFunctionType pUpdateSDKStatusFunction)
        {
            instance.ComponentHolder.kaiSDKWatchdog = new BuilderOfKaiSDKWatchdog()
                                                         .WithUpdateSDKStatusFunction(pUpdateSDKStatusFunction)
                                                         .Build();
            return this;
        }
    }
}
