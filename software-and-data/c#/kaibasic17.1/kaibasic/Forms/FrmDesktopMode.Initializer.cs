
using MyKai.Facade;
using MyKai.Gesture;
using MyKai.Properties;
using System.Drawing;


using System.Windows.Forms;

namespace kaibasic
{
    public partial class FrmDesktopMode
    {
        private class Initializer
        {
            private FrmDesktopMode mainForm;

            public Initializer(FrmDesktopMode pParent)
            {
                mainForm = pParent;
            }

            public void PerformInitActions()
            {
                mainForm.InitializeComponent();

                MakeGestureCursorOverlayForm();
                MakeKaiFacade();

                AddGesturesToFlowLyoutPanel();
            }

            private void MakeGestureCursorOverlayForm()
            {
                mainForm.DesktopGestureViewForm = new GestureViewFormOverlay { Owner = mainForm };
                mainForm.DesktopGestureViewForm.Show();
            }
                
            private void MakeKaiFacade()
            {
                GestureCursorParams cursorParams = new GestureCursorParams()
                {
                    OwnerControl = mainForm,
                    OnStateChanged = mainForm.ReceiveOnStateChanged, // this schould be implemented in main form
                    ViewPortSize = GetGestureViewFormBounds() // changed to use the actual screen bounds instead of a hosting panel
                };

                int defDecimationFrequency = MyKaiSettings.Default.kaiGesture2DDefaultDecimationFrequency;

                mainForm.KaiFacade = new BuilderOfMyKaiFacade().WithNewSubobjects()
                                                               .WithNewInitializer()
                                                               .WithOwnerControl(mainForm)
                                                               .WithGestureViewHostingPanel(mainForm.pnDrawGestureTmp)
                                                               .WithGestureCursorParams(cursorParams)
                                                               .WithGestureViewFormOverlay(mainForm.DesktopGestureViewForm)
                                                               .WithOtherInitialActions()
                                                               .WithEventDecimationRates(defDecimationFrequency, defDecimationFrequency)
                                                               .WithEventLogger(mainForm.KaiEventLogger)
                                                               .WithKaiMassageLogUserControl(mainForm.KaiMessageLogUserControl)
                                                               .WithNewKaiSDKWatchdog(mainForm.UpdateKaiSDKStatusControls)
                                                               .Build();
            }

            private (int Width, int Height) GetGestureViewFormBounds()
            {
                Rectangle bounds = Screen.PrimaryScreen.Bounds;

                return (bounds.Width, bounds.Height);
            }

            private void AddGesturesToFlowLyoutPanel()
            {
                // For testing purposes, we load user-selected gestures from a predefined path
                // TODO: In the future, this should be replaced with a dynamic way to select user and gestures
                string userSelectedImagesPath = ".\\workspace\\datasets\\sensors-2026-freehand\\user-selected-gestures";
                string selectedUserSID = "szsz";

                string filePath = userSelectedImagesPath + "\\" + selectedUserSID;
                
                mainForm.flpGestures.Controls.Clear();

                var gestureImages = System.IO.Directory.GetFiles(filePath, "*.jpg");
                foreach (var image in gestureImages)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(image),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 50,
                        Height = 50
                    };

                    pictureBox.BorderStyle = BorderStyle.FixedSingle;

                    mainForm.flpGestures.Controls.Add(pictureBox);
                }
            }
        }
    }
}
