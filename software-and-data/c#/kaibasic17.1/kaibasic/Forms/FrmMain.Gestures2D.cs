using System;
using System.Drawing;
using System.Windows.Forms;

using MoCap.Gesture;

using MyKai.Data;
using MyKai.Data.Entities;
using MyKai.General;
using MyKai.Gesture;
using MyKai.Properties;
using MyKai.SimpleProfiler;
using OpenTK.Graphics.ES20;

namespace kaibasic
{
    public partial class FrmMainGesture2D : UserControl
    {
        FrmMain mainForm;

        public void SetMainForm(FrmMain pMainForm)
        {
            mainForm = pMainForm;
        }

        private bool ShouldUpdatePatametersControls = true;

        public FrmMainGesture2D()
        {
            InitializeComponent();
        }

        public void ReceiveOnStateChanged(object[] pArgs) // Invoked by KaiControllComunicator
        {
            if (pArgs != null && pArgs.Length == 1)
            {
                tbSegmenterState.Text = pArgs[0].ToString();
            }

            if (mainForm.KaiFacade.Get.GestureCursorState == Gesture2DCursorStateMachine.StateType.JustEndedDrawing)
            {
                PerformAddImageActions();
            }
        }

        public void UpdateCaptureParametersControls()
        {
            ShouldUpdatePatametersControls = false; //Stete variable used to prevent the event handler from being invoked when the value is set programatically

            nudMaxStabilizingCounterValue.Value = MyKaiSettings.Default.kaiG2DStateMachineMaxStabilizingCounterValue;

            WinFormsDrawingParameters drawingParams = (WinFormsDrawingParameters)mainForm.KaiFacade.Get.CursorDrawingParameters;

            rbEraseAndDrawOnCapture.Checked = drawingParams.DrawingMode == DrawingModeType.EraseAndDrawOnCapture;
            rbDrawOnTargetControlPaint.Checked = drawingParams.DrawingMode == DrawingModeType.DrawOnTargetControlPaint;

            nudRedrawMargin.Value = drawingParams.RedrawMargin;
            nudStandardCursorSize.Value = drawingParams.StdCursorSize;
            nudCrossmarkSize.Value = drawingParams.CrossmarkSize;
            nudMaxStabilizingMarkRadius.Value = drawingParams.MaxStabilizingMarkRadius;
            nudMinStabilizingMarkRadius.Value = drawingParams.MinStabilizingMarkRadius;
            nudStabilizingCrossmarkSizeInterval.Value = drawingParams.StabilizingCursorRedrawInterval;

            cbApplyLoPasFilterOnEnding.Checked = drawingParams.ApplyLowPassFilterOnEnding;
            nudNumberOfPoints_Filtering.Value = drawingParams.NumberOfPoints_Filtering;
            tbLowPassFilterFactor.Text = MyKaiSettings.Default.kaiGestureLowPassFilterFactor.ToString("F2");

            ShouldUpdatePatametersControls = true;
        }

        public void UpdateCaptureParameters()
        {
            var stateParams = mainForm.KaiFacade.Get.GestureCursorStateMachineParams;
            stateParams.MaxStabilizingCounterValue = (int)nudMaxStabilizingCounterValue.Value;
            mainForm.KaiFacade.Get.GestureCursorStateMachineParams = stateParams;

            WinFormsDrawingParameters drawingParams = mainForm.KaiFacade.Get.CursorDrawingParameters;

            drawingParams.DrawingMode = rbEraseAndDrawOnCapture.Checked ?
                DrawingModeType.EraseAndDrawOnCapture :
                DrawingModeType.DrawOnTargetControlPaint;

            drawingParams.RedrawMargin = (int)nudRedrawMargin.Value;
            drawingParams.StdCursorSize = (int)nudStandardCursorSize.Value;
            drawingParams.CrossmarkSize = (int)nudCrossmarkSize.Value;
            drawingParams.MaxStabilizingMarkRadius = (int)nudMaxStabilizingMarkRadius.Value;
            drawingParams.MinStabilizingMarkRadius = (int)nudMinStabilizingMarkRadius.Value;
            drawingParams.StabilizingCursorRedrawInterval = (int)nudStabilizingCrossmarkSizeInterval.Value;

            drawingParams.ApplyLowPassFilterOnEnding = cbApplyLoPasFilterOnEnding.Checked;
            drawingParams.NumberOfPoints_Filtering = (int)nudNumberOfPoints_Filtering.Value;
            
            try
            {
                MyKaiSettings.Default.kaiGestureLowPassFilterFactor = float.Parse(tbLowPassFilterFactor.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(this, "Invalid format for Low Pass Filter Factor. Please enter a valid number.", 
                                      "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainForm.KaiFacade.Get.CursorDrawingParameters = drawingParams;
        }

        void UpdateViewDrawMode()
        {
            WinFormsDrawingParameters drawingParams = mainForm.KaiFacade.Get.CursorDrawingParameters;

            drawingParams.DrawingMode = rbEraseAndDrawOnCapture.Checked ? DrawingModeType.EraseAndDrawOnCapture :
                                        DrawingModeType.DrawOnTargetControlPaint;

            mainForm.KaiFacade.Get.CursorDrawingParameters = drawingParams;
        }

        public bool IsGesture2DCapturingOn
        {
            get => cbCapture2DGestures.Checked;
        }

        public Panel GetHostingPanel()
        {
            return pnGestureDraw;
        }

        private void PerformAddImageActions()
        {
            if (cbRecordImages.Checked)
            {
                StopGestureCapture();

                AddNewGestureImage();
                
                mainForm.KaiFacade.Action.ClearGestureBitmaps();
                
                StartGestureCapture();
            }
        }

        private void StartGestureCapture()
        {
            Graphics gr = null;

            cbCapture2DGestures.Checked = true;

            if (!mainForm.IsDesktopModeIsOn)
                gr = ((Control)mainForm.KaiFacade.Get.GestureViewControl).CreateGraphics();
            else
                gr = mainForm.DesktopGestureViewForm.CreateGraphics();

            gr.Clear(Color.White);

            mainForm.UpdateKaiStatusControls();
        }

        private void StopGestureCapture()
        {
            cbCapture2DGestures.Checked = false;
            mainForm.UpdateKaiStatusControls();
        }

        private void StartInstantProfiling()
        {
            MyKaiSimpleProfiler.InstantProfiler.Reset();
            MyKaiSimpleProfiler.InstantProfiler.ClearMeasurementTextList();
        }

        private void StopInstantProfiling()
        {
            MyKaiSimpleProfiler.InstantProfiler.SaveMeasurementTextListToFile(MyKaiSettings.Default.kaiSimpleProfilerFilePath);
        }

        public void AddProfilingResult(string pMeasurementText)
        {
            rbtProfilingResult.AppendText(pMeasurementText + Environment.NewLine);
            rbtProfilingResult.SelectionStart = rbtProfilingResult.Text.Length;
            rbtProfilingResult.ScrollToCaret();
            rbtProfilingResult.Refresh();
        }

        int GetImageNumber() => int.Parse(tbImageCounter.Text);

        void IncreaseImageNumber()
        {
            int imageNumber = int.Parse(tbImageCounter.Text);
            imageNumber++;
            tbImageCounter.Text = imageNumber.ToString();
        }

        string BuildNewGestureImageFileName(int pImageNumber)
        {
            string imagePrefix = tbIndividualsLabel.Text + "_" + tbPatternClassLabel.Text;
            object[] filenameData = { imagePrefix, pImageNumber };

            return new MyKaiPrefixNumberFileNameMaker().MakeFileName(filenameData);
        }

        private void AddNewGestureImage()
        {
            string filename = BuildNewGestureImageFileName(GetImageNumber());
            IncreaseImageNumber();

            const string extention = ".jpg"; // TO DO - make the extention an image object parameter 

            GestureImageEntity imageEntity = (GestureImageEntity)KaiDataWorkspace.Find.EntityByName("CapturedGestureImages");
            string samplesDirectory = imageEntity.SamplesRelativePath();

            GestureImage newGestureImage = new BuilderOfGestureImage().WithName(filename + extention)
                                                                      .WithFullName(imageEntity.RelativePath() + "\\" + filename + extention)
                                                                      .WithSamplesDirectoryName(samplesDirectory)
                                                                      .WithTrailImageClone(mainForm.KaiFacade.Get.TrailBitmap)
                                                                      .WithBezierImageClone(mainForm.KaiFacade.Get.BezierBitmap)
                                                                      .WithGesturePoints(mainForm.KaiFacade.Get.Gesture2DCapture.Gesture)
                                                                      .Build();

            imageEntity.Objects.Items.Add(newGestureImage);
            imageEntity.ManagedControls.ReloadListItems();
        }

        private void LoadImagesOfSelectedClassAndIndividual()
        {
            if (this.DesignMode)
                return;

            ClearCapturedGestureControl();

            UpdateCapturedGesturesList();

            UpdateImageCounter();
        }

        private void UpdateCapturedGesturesList()
        {
            lbCapturedGestures.Items.Clear();

            IKaiDataEntity capturedImages = KaiDataWorkspace.Find.EntityByName("CapturedGestureImages");

            KaiDataFilterBase patternPrefixFilter = new BuilderOfSubstringFilter().WithName("NamePrefixFilter")
                                                                                  .WithRequiredValue(tbPatternClassLabel.Text)
                                                                                  .WithSubstringParameters((5, 4))
                                                                                  .Build();

            KaiDataFilterBase individualPrefixFilter = new BuilderOfSubstringFilter().WithName("NamePrefixFilter")
                                                                                     .WithRequiredValue(tbIndividualsLabel.Text)
                                                                                     .WithSubstringParameters((0, 4))
                                                                                     .Build();
            capturedImages.Filters.Items.Clear();
            capturedImages.Filters.Items.Add(patternPrefixFilter);
            capturedImages.Filters.Items.Add(individualPrefixFilter);

            capturedImages.LoadInstances();
        }

        private void UpdateImageCounter()
        {
            KaiDataObjectCollection collection = KaiDataWorkspace.Find.ObjectsByEntityName("CapturedGestureImages");
            tbImageCounter.Text = (collection.Items.Count + 1).ToString();
        }

        private void ClearCapturedGestureControl()
        {
            Graphics gr = ((Control)mainForm.KaiFacade.Get.GestureViewControl).CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();
        }

        private void UpdateGestureDrawMode()
        {
            if (rbPointBasedDrawingMode.Checked)
            {
                // GroupBoxes enable/disable
                gbPointsDrawingModes.Enabled = true;
                gbBitmapDrawingModes.Enabled = false;

                MyKaiGestureDrawingParams.ResetPanelDrawingTypes();

                if (cbDrawGesture.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.GestureTrail);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.GestureTrail);

                if (cbDrawBeziers.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.Bezier);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.Bezier);

                if (cbDrawGesturePoints.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.Points);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.Points);

                if (cbDrawBoundingRectangle.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.BoundingRectangle);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.BoundingRectangle);
            }

            if (rbBitmapBasedDrawingMode.Checked)
            {
                // GroupBoxes enable/disable
                gbBitmapDrawingModes.Enabled = true;
                gbPointsDrawingModes.Enabled = false;

                if (rbDrawTrailBitmap.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.TrailBitmap);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.TrailBitmap);

                if (rbDrawBezierBitmap.Checked)
                    MyKaiGestureDrawingParams.EnablePanelDrawingType(MyKaiGestureDrawingType.BezierBitmap);
                else
                    MyKaiGestureDrawingParams.DisablePanelDrawingType(MyKaiGestureDrawingType.BezierBitmap);
            }
        }

        private void DrawGestureRepresentationOnControl()
        {
            KaiDataObjectCollection collection = KaiDataWorkspace.Find.ObjectsByEntityName("CapturedGestureImages");
            collection.SelectObjectByName(lbCapturedGestures.SelectedItem.ToString());

            GestureImage gestureImage = (GestureImage)collection.SelectedObject;

            Graphics graphics = mainForm.KaiFacade.Get.GestureViewControl.CreateControlGraphics();

            UintGesture2D uintGesture2D = gestureImage.ToUintGesture2D();

            mainForm.KaiFacade.Action.RedrawGestureRepresentationOnGraphics(graphics, uintGesture2D);
        }

        private void DrawGestureBitmapsOnControl()
        {
            KaiDataObjectCollection collection = KaiDataWorkspace.Find.ObjectsByEntityName("CapturedGestureImages");
            collection.SelectObjectByName(lbCapturedGestures.SelectedItem.ToString());

            GestureImage gestureImage = (GestureImage)collection.SelectedObject;

            Graphics graphics = mainForm.KaiFacade.Get.GestureViewControl.CreateControlGraphics();

            mainForm.KaiFacade.Action.RedrawGestureBitmapsOnGraphics(graphics, gestureImage);
        }

        private void SaveCapturedImages()
        {
            GestureImageEntity imageEntity = (GestureImageEntity)KaiDataWorkspace.Find.EntityByName("CapturedGestureImages");
            imageEntity.OverwriteOnSave = cbOverwriteExistingImages.Checked;
            imageEntity.SaveInstances();
        }

        private void SwitchToOwnPattern()
        {
            cmbGesturePattern.Text = "";
            cmbGesturePattern.Enabled = false;
            pbGesturePattern.Visible = false;
            lbDrawnOwnGesture.Visible = true;
            cmbOwnGesture.Enabled = true;
            cmbOwnGesture.SelectedIndex = 0;
            cmbGesturePattern.SelectedIndex = -1;
        }

        private void SwitchToPatternLibrary()
        {
            cmbGesturePattern.Enabled = true;
            pbGesturePattern.Visible = true;
            lbDrawnOwnGesture.Visible = false;
            cmbOwnGesture.Enabled = false;
            cmbOwnGesture.SelectedIndex = -1;
            cmbGesturePattern.SelectedIndex = 0;
        }

        private void bStartPYRGestureCapture_Click(object sender, EventArgs e)
        {
            mainForm.ConfigureForPYRGestureCapture();

            StartGestureCapture();
        }

        private void cbPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGesturePattern.SelectedIndex == -1)
            {
                pbGesturePattern.Image = null;
                return;
            }

            KaiDataObjectCollection collection = KaiDataWorkspace.Find.ObjectsByEntityName("GesturePatterns");
            collection.SelectObjectByName(cmbGesturePattern.Text);

            GesturePattern gesturePattern = (GesturePattern)collection.SelectedObject;

            tbPatternClassLabel.Text = gesturePattern.ImageClassLabel;
            pbGesturePattern.Image = gesturePattern.GestureImage;

            LoadImagesOfSelectedClassAndIndividual();
        }

        private void cbDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            KaiDataObjectCollection instances = KaiDataWorkspace.Find.ObjectsByEntityName("ImageDatasets");
            instances.SelectObjectByName(cmbImageDataset.Text);

            KaiDataWorkspace.Find.EntityByName("ImageDatasets").RefreshDetailEntities();
        }

        private void cbIndividual_SelectedIndexChanged(object sender, EventArgs e)
        {
            KaiDataObjectCollection instances = KaiDataWorkspace.Find.ObjectsByEntityName("Individuals");
            instances.SelectObjectByName(cmbIndividual.Text);

            Individual individual = (Individual)instances.SelectedObject;
            tbIndividualsLabel.Text = individual.IndividualSID;

            LoadImagesOfSelectedClassAndIndividual();
        }

        private void bResetCounter_Click(object sender, EventArgs e)
        {
            tbImageCounter.Text = "1";
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveCapturedImages();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartGestureCapture();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGestureCapture();
        }

        private void lbCapturedGestures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( rbPointBasedDrawingMode.Checked)
                DrawGestureRepresentationOnControl();

            if (rbBitmapBasedDrawingMode.Checked)
                DrawGestureBitmapsOnControl();
        }

        // This event is used for ALL tuning controls in the tuning tab
        private void TuningControls_ValueOrTextChanged(object sender, EventArgs e)
        {
            if (ShouldUpdatePatametersControls) // State variable used to prevent the event handler from being invoked when the value is set programatically
                UpdateCaptureParameters();
        }

        private void FrmMainGesture2D_Load(object sender, EventArgs e)
        {
            LoadImagesOfSelectedClassAndIndividual();
        }

        private void bDeleteSelected_Click(object sender, EventArgs e)
        {
            KaiDataEntityBase capturedImageEntity = (KaiDataEntityBase)KaiDataWorkspace.Find.EntityByName("CapturedGestureImages");

            KaiDataObjectBase selectedImage = capturedImageEntity.Objects.SelectedObject;

            KaiDataObjectCollection imagesToDel = new KaiDataObjectCollection(capturedImageEntity); //Only one image will be added to this list here
            imagesToDel.Items.Add(selectedImage);

            capturedImageEntity.DeleteInstances(imagesToDel);

            capturedImageEntity.ManagedControls.ReloadListItems();

            tbImageCounter.Text = (capturedImageEntity.Objects.Items.Count+1).ToString();
        }

        private void rbEraseAndDrawOnCapture_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewDrawMode();
        }

        private void bSwitchToDesktopMode_Click(object sender, EventArgs e)
        {
            mainForm.SwitchDesktopCaptureModeOn();
        }

        private void cbDrawGesture_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureRepresentationOnControl();   
        }

        private void cbDrawBeziers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureRepresentationOnControl();
        }

        private void cbDrawBoundingRectangle_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureRepresentationOnControl();
        }

        private void cbDrawGesturePoints_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureRepresentationOnControl();
        }

        private void rbPointBasedDrawingMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode(); 
            DrawGestureRepresentationOnControl();
        }

        private void rbBitmapBasedDrawingMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureBitmapsOnControl();
        }        
        
        private void rbDrawTrailBitmap_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureBitmapsOnControl();
        }        
        
        private void rbDrawBezierBitmap_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGestureDrawMode();
            DrawGestureBitmapsOnControl();
        }

        private void cbOwnGesture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnGesture.Checked)
            {
                SwitchToOwnPattern();
            }
            else
            {
                SwitchToPatternLibrary();
                UpdateCapturedGesturesList();
            }
        }

        private void cmbOwnGesture_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPatternClassLabel.Text = cmbOwnGesture.Text;
            LoadImagesOfSelectedClassAndIndividual();
        }

        private void cbApplyLoPasFilterOnEnding_CheckedChanged(object sender, EventArgs e)
        {
            nudNumberOfPoints_Filtering.Enabled = cbApplyLoPasFilterOnEnding.Checked;
            lbNumberOfPoints_filtering.Enabled = cbApplyLoPasFilterOnEnding.Checked;
            tbLowPassFilterFactor.Enabled = cbApplyLoPasFilterOnEnding.Checked;
            lbLowPassFilterFactor.Enabled = cbApplyLoPasFilterOnEnding.Checked;
        }

        private void tscCopyToClipboard_Click(object sender, EventArgs e)
        {
            CopyGestureDrawPanelToClipboard();
            MessageBox.Show("Gesture copied to clipboard.", "Copy to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       private void CopyGestureDrawPanelToClipboard()
        {
            if (pnGestureDraw.Width <= 0 || pnGestureDraw.Height <= 0)
                return;

            // Create a bitmap of the main form's client area
            var form = mainForm as Form;
            if (form == null)
                return;

            Rectangle bounds = form.ClientRectangle;
            using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height))
            {
                
                form.DrawToBitmap(bmp, bounds);
                Clipboard.SetImage(bmp);
            }
        }

        private void bStartInstantProfiling_Click(object sender, EventArgs e)
        {
            StartInstantProfiling();
        }

        private void bStopInstantProfiling_Click(object sender, EventArgs e)
        {
            StopInstantProfiling();
        }
    }
}
