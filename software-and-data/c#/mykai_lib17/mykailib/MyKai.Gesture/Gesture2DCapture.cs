using MoCap.CapturedData;
using MoCap.Gesture;
using MyKai.Data.Entities;
using MyKai.General;
using MyKai.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyKai.Gesture
{
   internal partial class Gesture2DCapture : IGesture2DCapture
    {
        public UintGesture2D Gesture { get; set; } = new UintGesture2D();
        public Gesture2DBitmaps GestureBitmaps = new Gesture2DBitmaps();

        public Gesture2DCursorBase GestureCursor;
        public Gesture2DCursorViewWF GestureCursorView;

        private Gesture2DDrawer gestureDrawer = new Gesture2DDrawer();
        private Gesture2DCaptureQuery query;
        private Gesture2DCaptureGet get;


        protected bool isGestureCapturingOn = false;

        public IGesture2DCaptureQuery Query { get => query; set { query = (Gesture2DCaptureQuery)value; } }
        public IGesture2DCaptureGet Get { get => get; set { get = (Gesture2DCaptureGet)value; } }

        public void BuildGestureCursor(GestureCursorParams pCursorParams)
        {
            Gesture2DCursorStateMachine.StateParamsStruct stateMachineParams = new Gesture2DCursorStateMachine.StateParamsStruct();
            ReadInitialG2DStateMachine(ref stateMachineParams);

            GestureCursor = new BuilderOfGesture2DCursor()
                            .WithAngleLimit((float)Math.PI / MyKaiSettings.Default.kaiGesture2DAllowedAnglePIDivider)
                            .WithViewPortSize(pCursorParams.ViewPortSize.Width, pCursorParams.ViewPortSize.Height)
                            .WithKaiControlCommunicator(pCursorParams.OwnerControl, pCursorParams.OnStateChanged)
                            .WithStateMachineParams(stateMachineParams)
                            .Build();
        }

        private void ReadInitialG2DStateMachine(ref Gesture2DCursorStateMachine.StateParamsStruct pStateMachineParams)
        {
            pStateMachineParams.MaxStabilizingCounterValue = MyKaiSettings.Default.kaiG2DStateMachineMaxStabilizingCounterValue;
        }

        public void BuildGestureCursorView(Control pControl, Graphics pGraphics)
        {
            WinFormsDrawingParameters wfDrawingParameters = new WinFormsDrawingParameters
            {
                TargetControl = pControl,
                TargetControlGraphics = pGraphics
            };

            ReadDefaultCursorDrawingParameters(ref wfDrawingParameters); // Read default drawing parameters defined in MyKai library settings

            // Building the view
            GestureCursorView = new BuilderOfGesture2DCursorViewWF()
                                    .WithViewedCursor(GestureCursor)
                                    .WithInitView(wfDrawingParameters)
                                    .WithCaptureGet(this.Get)
                                    .WithLocalGesture2DCopy(Gesture)
                                    .Build();
        }

        public void SwitchGestureCapturingOn()
        {
            isGestureCapturingOn = true;
        }

        public void SwitchGestureCapturingOff()
        {
            isGestureCapturingOn = false;
        }

        // Crucial method - it performs one step of gesture capturing procedure
        public void PerformCaptureProcedureStep(float pXAngle, float pYAngle)
        {
            if (GestureCursorView.CursorDrawingParameters.DrawingMode == DrawingModeType.EraseAndDrawOnCapture)
                if (!GestureCursor.StateMachine.IsStateUndefined())
                    GestureCursorView.ClearPreviousCursor();

            GestureCursor.PushData();

            SetAnglesAndCalcCursorCoordinates(pXAngle, pYAngle);

            if (this.Query.IsGestureBeingDrawn())
                AddCapturedPositionToGesture(); // Store the gesture point in the Gesture2D class

            GestureCursor.PerformGestureFrameAction();


            RedrawCurrentCursorOnControl();

            if (GestureCursor.StateMachine.State == Gesture2DCursorStateMachine.StateType.JustEndedDrawing)
            {
                if( GestureCursorView.CursorDrawingParameters.ApplyLowPassFilterOnEnding)
                    ApplyGestureFilters(GestureCursorView.cursorDrawingParams.LowPassFilterFactor,
                                        GestureCursorView.CursorDrawingParameters.NumberOfPoints_Filtering);

                DrawGestureTrailOnBitmap();
                DrawGestureBeziersOnBitmap();
            }
            
            GestureCursor.InformTargetControlOfStateChanged();

            if (GestureCursor.StateMachine.State == Gesture2DCursorStateMachine.StateType.JustEndedDrawing)
                Gesture.ClearFrames();
        }

        public void EnablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
        {
            MyKaiGestureDrawingParams.EnablePanelDrawingType(pDrawingType);
        }

        public void DisablePanelDrawingType(MyKaiGestureDrawingType pDrawingType)
        {
            MyKaiGestureDrawingParams.DisablePanelDrawingType(pDrawingType);
        }

        public void DrawGestureTrailOnBitmap()
        {
            gestureDrawer.DrawGestureTrailOnBitmap(GestureBitmaps.TrailBitmap, Gesture);
        }

        public void DrawGestureBeziersOnBitmap()
        {
            gestureDrawer.DrawGestureBeziersOnBitmap(GestureBitmaps.BezierBitmap, Gesture);
        }

        internal void RedrawGestureRepresentationOnGraphics(Graphics pGraphics, UintGesture2D pGesture)
        {
            Graphics graphics = this.GestureCursorView.CursorDrawingParameters.TargetControlGraphics;

            gestureDrawer.ClearBitmap(graphics);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.GestureTrail))
                gestureDrawer.DrawGestureTrailOnGraphics(graphics, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.Bezier))
                gestureDrawer.DrawGestureBeziersOnGraphics(graphics, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.Points))
                gestureDrawer.DrawGesturePointsOnGraphics(graphics, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.BoundingRectangle))
            gestureDrawer.DrawGestureBoundingRectangleOnGraphics(graphics, pGesture);

            RedrawGestureRepresentationOnBitmapAndCopyToClipboard(pGraphics, pGesture);
        }

        // A temporary workaround method writen to copy the gesture representation to clipboard needed instantly for manuscript screenshots
        internal void RedrawGestureRepresentationOnBitmapAndCopyToClipboard(Graphics pGraphics, UintGesture2D pGesture)
        {
            // Create a bitmap of size of the clip bounds of the provided graphics

            Bitmap bmp = new Bitmap(640, 640);
            Graphics gr = Graphics.FromImage(bmp);

            gestureDrawer.ClearBitmapColor(gr, Color.FromArgb(242,242,242)); // Light gray background to show on white paper

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.GestureTrail))
                gestureDrawer.DrawGestureTrailOnGraphics(gr, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.Bezier))
                gestureDrawer.DrawGestureBeziersOnGraphics(gr, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.Points))
                gestureDrawer.DrawGesturePointsOnGraphics(gr, pGesture);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.BoundingRectangle))
                gestureDrawer.DrawGestureBoundingRectangleOnGraphics(gr, pGesture);
            
            Clipboard.SetImage(bmp);
            
            gr.Dispose();
            bmp.Dispose();
        }

        internal void RedrawGestureBitmapsOnGraphics(Graphics pGraphics, GestureImage pGestureImage)
        {
            Graphics graphics = this.GestureCursorView.CursorDrawingParameters.TargetControlGraphics;

            gestureDrawer.ClearBitmap(graphics);

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.TrailBitmap))
            {               
                Bitmap trailBitmap = new Bitmap(pGestureImage.GestureImage);
                gestureDrawer.DrawBitmapOnGraphics(graphics, trailBitmap);
                
                trailBitmap.Dispose();

                return;
            }

            if (MyKaiGestureDrawingParams.EnabledPanelDrawingTypes.Contains(MyKaiGestureDrawingType.BezierBitmap))
            {
                Bitmap bezierBitmap = new Bitmap(pGestureImage.BezierImage);
                gestureDrawer.DrawBitmapOnGraphics(graphics, bezierBitmap);

                bezierBitmap.Dispose();

                return;
            }
        }

        private void RedrawCurrentCursorOnControl()
        {
            // legacy drawing mode - erase and draw on each capture step - currently used, but left for backward compatibility
            if (GestureCursorView.CursorDrawingParameters.DrawingMode == DrawingModeType.EraseAndDrawOnCapture)
                GestureCursorView.DrawCurrentCursor();

            // new drawing mode - draw on Paint event of the target control
            if (GestureCursorView.CursorDrawingParameters.DrawingMode == DrawingModeType.DrawOnTargetControlPaint)
            {
                GestureCursorView.ShouldDrawOnPaint = true; // State variable used to control drawing on Paint event of the target control;
                                                            // it will be set to true in the Paint event of the target control

                (int X, int Y, int Width, int Height) br = Gesture.GetBoundingRectangleOfSinglePointFrame();
                GestureCursorView.CursorDrawingParameters.TargetControl.Invalidate(new Rectangle(br.X, br.Y, br.Width, br.Height));
            }
        }

        private void ApplyGestureFilters(float pLowPassFilterFactor, int pNumberOfPoints)
        {
            Gesture.ApplyLowPassFilter(pLowPassFilterFactor, pNumberOfPoints);
        }

        private void ReadDefaultCursorDrawingParameters(ref WinFormsDrawingParameters pDrawParams)
        {
            pDrawParams.DrawingMode = (DrawingModeType)MyKaiSettings.Default.kaiWFDrawingDefaultMode;
            pDrawParams.RedrawMargin = MyKaiSettings.Default.kaiWFDrawingRedrawMargin;
            pDrawParams.StdCursorSize = MyKaiSettings.Default.kaiWFDrawingStdCursorSize;
            pDrawParams.CrossmarkSize = MyKaiSettings.Default.kaiWFDrawingCrossmarkSize;
            pDrawParams.MaxStabilizingMarkRadius = MyKaiSettings.Default.kaiWFDrawingMaxStabilizingMarkRadius;
            pDrawParams.MinStabilizingMarkRadius = MyKaiSettings.Default.kaiWFDrawingMinStabilizingMarkRadius;
            pDrawParams.StabilizingCursorRedrawInterval = MyKaiSettings.Default.kaiWFDrawingStabilizingCursorRedrawInterval;
            pDrawParams.ApplyLowPassFilterOnEnding = MyKaiSettings.Default.kaiGestureLowPassFilterApplyOnEnding;
            pDrawParams.NumberOfPoints_Filtering = MyKaiSettings.Default.kaiGestureLowPasFilterNumberOfEndingPoints;
            pDrawParams.LowPassFilterFactor = (float)MyKaiSettings.Default.kaiGestureLowPassFilterFactor;
        }

        private void SetAnglesAndCalcCursorCoordinates(float pXAngle, float pYAngle)
        {
            float limit = GestureCursor.AngleLimit;

            float xAngle = Math.Abs(pXAngle) > limit ? Math.Sign(pXAngle) * limit : pXAngle;
            float yAngle = Math.Abs(pYAngle) > limit ? Math.Sign(pYAngle) * limit : pYAngle;

            // Kai angles are directed towards the screen - must negate 
            xAngle *= -1;
            yAngle *= -1;

            GestureCursor.SetPositionUsingAngularData(xAngle, yAngle);
        }

        private void AddCapturedPositionToGesture()
        {
            (uint x, uint y) newPointCoordinates = GestureCursor.GetPositionInPixels();
            UintPoint2D newPoint = new UintPoint2D()
            {
                X = newPointCoordinates.x,
                Y = newPointCoordinates.y
            };

            UintFrame2D newFrame = new UintFrame2D();

            newFrame.Points.Add(newPoint);

            Gesture.Frames.Add(newFrame);
        }
    }
}
