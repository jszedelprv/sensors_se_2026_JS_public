using System;
using System.Reflection;
using System.Windows.Forms;

using Kai.Module;

using MyKai.Data;
using MyKai.Facade;
using MyKai.General;
using MyKai.Gesture;
using MyKai.GUI;

using ShapeVisualizer;


namespace kaibasic
{
    partial class FrmMain
    {
        class Initializer
        {
            FrmMain mainForm;

            public Initializer ( FrmMain pParent )
            {
                mainForm = pParent;
            }

            public void PerformInitActions()
            {
                mainForm.InitializeComponent();
                
                SetUsersControlsMainForm();

                MakeTitle();
                MakeKaiVisualizer();
                MakeKaiFacade();

                mainForm.ucGestures2D.UpdateCaptureParametersControls();

                ReadAndMakeResourceStrings();

                InitializeData();

                InitializeControls();
            }

            private void MakeKaiFacade()
            {
                GestureCursorParams cursorParams = new GestureCursorParams()
                {
                    OwnerControl = mainForm,
                    OnStateChanged = mainForm.ucGestures2D.ReceiveOnStateChanged, // this schould be implemented in main form

                    ViewPortSize = (mainForm.ucGestures2D.GetHostingPanel().Width, mainForm.ucGestures2D.GetHostingPanel().Height)
                };

                mainForm.KaiFacade = new BuilderOfMyKaiFacade().WithNewSubobjects()
                                                               .WithNewInitializer()
                                                               .WithOwnerControl(mainForm)
                                                               .WithGestureViewHostingPanel(mainForm.ucGestures2D.GetHostingPanel())
                                                               .WithGestureCursorParams(cursorParams)
                                                               .WithNewGestureViewPanelHostedControl()
                                                               .WithOtherInitialActions()
                                                               .WithEventDecimationRates((int)mainForm.nudReduceQEvNumber.Value, (int)mainForm.nudReducePYREvNumber.Value)
                                                               .WithEventLogger(((IKaiLoggingAwareClass)mainForm).KaiEventLogger)
                                                               .WithKaiMassageLogUserControl(((IKaiLoggingAwareClass)mainForm).KaiMessageLogUserControl)
                                                               .WithNewKaiSDKWatchdog(mainForm.UpdateKaiStatusControls)
                                                               .Build();  
            } 

            private void MakeTitle()
            {
                Assembly thisAssem = typeof(FrmMain).Assembly;
                AssemblyName thisAssemName = thisAssem.GetName();
                Version ver = thisAssemName.Version;

                mainForm.Text += " " + ver.Major + "." + ver.Minor + "." + ver.Build; // + " " + Properties.Resources.parKaiSDKVersion;
            }

            private void MakeKaiVisualizer()
            {
                MyKaiClassRegistry.AddClass<GLControlShapeVisualizer>();

                mainForm.visualizer = new BuilderOfGLControlShapeVisualizer()
                                    .WithVisualizerGLControl(mainForm.glcVisualize)
                                    .BuildAndInitialize();
            }

            private void SetUsersControlsMainForm()
            {
                mainForm.ucRawData.SetMainForm(mainForm);
                mainForm.ucGestures2D.SetMainForm(mainForm);
            }

            private void InitializeControls()
            {
                mainForm.clbCapabilities.SetItemCheckState(0, CheckState.Checked); // Select first item
                mainForm.currentCapabilities = KaiCapabilities.GestureData;  // Set current capabilities in FrmMain  
            }

            private void ReadAndMakeResourceStrings()
            {
                mainForm.messagePYRStart = Properties.Resources.messagePYRStart;
                mainForm.messageTraceOptionsConfigured = Properties.Resources.messageTraceOptionsConfigured;
                mainForm.messageKaiSDKNotRunning = Properties.Resources.messageKaiSDKNotRunning;
            }

            private void InitializeData()
            {
                KaiDataWorkspace.Init();

                KaiDataControlSearcher controlSearcher = new KaiDataControlSearcher(mainForm.ucGestures2D);
                IKaiDataEntity e;

                // Initial actions for the ImageDatasets entity
                e = KaiDataWorkspace.Find.EntityByName("ImageDatasets");
                e.ManagedControls.Items.Add(controlSearcher.FindControl.ByName("cmbImageDataset"));
                e.LoadInstances();

                // Initial actions for the GesturePatterns entity
                e = KaiDataWorkspace.Find.EntityByName("GesturePatterns");
                e.ManagedControls.Items.Add(controlSearcher.FindControl.ByName("cmbGesturePattern"));
                e.LoadInstances();

                // Initial actions for the GesturePatterns entity
                e = KaiDataWorkspace.Find.EntityByName("Individuals");
                e.ManagedControls.Items.Add(controlSearcher.FindControl.ByName("cmbIndividual"));
                e.LoadInstances();

                // Initial actions for the "CapturedGestureImages" entity
                e = KaiDataWorkspace.Find.EntityByName("CapturedGestureImages");
                e.ManagedControls.Items.Add(controlSearcher.FindControl.ByName("lbCapturedGestures"));
            }
        }
    }
}
