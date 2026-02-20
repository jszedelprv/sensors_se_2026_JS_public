using System;
using System.Drawing;
using System.Collections.Generic;

namespace MyKai.Gesture
{
    internal class Gesture2DCursorViewWF : Gesture2DCursorViewBaseWF, IDrawableOnPaint
    {
        delegate void DrawOrClearActionDelegate();

        readonly Dictionary<Gesture2DCursorStateMachine.StateType,
                (DrawOrClearActionDelegate DrawAction, DrawOrClearActionDelegate ClearAction)> DrawAndClearActions =
                 new Dictionary<Gesture2DCursorStateMachine.StateType, (DrawOrClearActionDelegate, DrawOrClearActionDelegate)>();

        private Gesture2DDrawer gestureDrawer = new Gesture2DDrawer();  

        public Gesture2DCursorViewWF()
        {
            InitDrawAndClearActions();
        }

        void UpdateLocalCursorPositionAndShift()
        {
            curPos.x = ViewedCursor.GestureData.PositionInPixels.XPix;
            curPos.y = ViewedCursor.GestureData.PositionInPixels.YPix;

            curPos.lastX = ViewedCursor.LastData.PositionInPixels.XPix;
            curPos.lastY = ViewedCursor.LastData.PositionInPixels.YPix;

            curPos.shift = cursorDrawingParams.StdCursorSize / 2;
        }

        public override void InitView(WinFormsDrawingParameters pViewParameters)
        {
            if (pViewParameters.TargetControl == null)
                throw new ArgumentException($"{GetType().Name} : Target control is null (InitView)");

            if (pViewParameters.TargetControlGraphics == null)
                throw new ArgumentException($"{GetType().Name} : Target control graphics is null (InitView)");

            cursorDrawingParams = pViewParameters;

            //GestureCaptureGet.TrailBitmap?.Dispose();
            //GestureCaptureGet.BezierBitmap?.Dispose();
            
            //GestureCaptureGet.TrailBitmap = new Bitmap(ViewedCursor.GestureData.Viewport.Width, ViewedCursor.GestureData.Viewport.Height);
            //GestureCaptureGet.BezierBitmap = new Bitmap(ViewedCursor.GestureData.Viewport.Width, ViewedCursor.GestureData.Viewport.Height);

            //Graphics graphics;
            
            //graphics = Graphics.FromImage(GestureCaptureGet.TrailBitmap);
            //graphics.Clear(GestureStyles.ClearColors.Bitmap);
            //graphics.Dispose();

            //graphics = Graphics.FromImage(GestureCaptureGet.BezierBitmap);
            //graphics.Clear(GestureStyles.ClearColors.Bitmap);
            //graphics.Dispose();
        }

        void InitDrawAndClearActions()
        {
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.Unstable, (DrawActionUnstable, ClearActionUnstable));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.Stabilizing, (DrawActionStabilizing, ClearActionStabilizing));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.JustStabilized, (DrawActionJustStabilized, NullAction));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.Stable, (DrawActionStable, ClearActionStable));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.Drawing, (DrawActionDrawing, NullAction));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.TryingToEndDraw, (DrawActionTryingToEndDraw, NullAction));
            DrawAndClearActions.Add(Gesture2DCursorStateMachine.StateType.JustEndedDrawing, (DrawActionJustEndedDrawing, NullAction));
        }

        void PerformDrawActions()
        {
            foreach (var item in DrawAndClearActions)
                if (item.Key == ViewedCursor.StateMachine.State)
                    item.Value.DrawAction();
        }

        void PerformClearActions()
        {
            foreach (var item in DrawAndClearActions)
                if (item.Key == ViewedCursor.StateMachine.State || item.Key == ViewedCursor.LastState)
                    item.Value.ClearAction();
        }

        void CheckDependencies()
        {
            if (this.cursorDrawingParams.TargetControl == null || cursorDrawingParams.TargetControlGraphics == null || ViewedCursor == null) // Ensure that dependencies are set
                throw new ArgumentNullException($"One or more dependencies of {this.GetType().Name} are not set.");
        }

        public override void DrawCurrentCursor()
        {
            CheckDependencies();
            UpdateLocalCursorPositionAndShift();
            PerformDrawActions();
        }

        public override void ClearPreviousCursor()
        {
            CheckDependencies();
            UpdateLocalCursorPositionAndShift();
            PerformClearActions();
        }

        public void DrawOnTargetControlPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics rememberedTargetControlGraphics = cursorDrawingParams.TargetControlGraphics; // Temporarily store the target control graphics
            cursorDrawingParams.TargetControlGraphics = e.Graphics;

            CheckDependencies();
            UpdateLocalCursorPositionAndShift();
            PerformDrawActions();

            cursorDrawingParams.TargetControlGraphics = rememberedTargetControlGraphics; // Restore the original target control graphics
        }

        // General actions
        private void NullAction() { }

        private void DefaultClearAction()
        {
            cursorDrawingParams.TargetControlGraphics.Clear(Color.White);
        }

        // Unstable state 
        private void DrawActionUnstable()
        {
            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_unstable_32, curPos.x - curPos.shift, curPos.y - curPos.shift);
        }

        private void ClearActionUnstable()
        {
            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_empty_32, curPos.lastX - curPos.shift, curPos.lastY - curPos.shift);
        }

        // Stabilizing state
        private void DrawActionStabilizing()
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.Width = 1;

            int radius = cursorDrawingParams.MaxStabilizingMarkRadius - ViewedCursor.StateMachine.InternalVariables.StabilizingFrameCounter;
            radius = radius < cursorDrawingParams.StdCursorSize ? cursorDrawingParams.StdCursorSize : radius;

            if (radius >= cursorDrawingParams.MinStabilizingMarkRadius)
                cursorDrawingParams.TargetControlGraphics.DrawRectangle(pen, curPos.x - radius / 2, curPos.y - radius / 2, radius, radius);

            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_unstable_32, curPos.x - curPos.shift, curPos.y - curPos.shift);
        }

        private void ClearActionStabilizing()
        {
            Pen pen = new Pen(Color.White);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.Width = 1;

            int radius = cursorDrawingParams.MaxStabilizingMarkRadius - ViewedCursor.StateMachine.InternalVariables.StabilizingFrameCounter;

            if (radius >= cursorDrawingParams.MinStabilizingMarkRadius)
                cursorDrawingParams.TargetControlGraphics.DrawRectangle(pen, curPos.x - radius / 2, curPos.y - radius / 2, radius, radius);

            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_empty_32, curPos.lastX - curPos.shift, curPos.lastY - curPos.shift);
        }

        // JustStabilized state
        private void DrawActionJustStabilized()
        {
            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_stable_32, curPos.lastX - curPos.shift, curPos.lastY - curPos.shift);
            PlaySound(@".\Sounds\stable.wav");
        }

        // Stable state
        private void DrawActionStable()
        {
            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_stable_32, curPos.x - curPos.shift, curPos.y - curPos.shift);
        }

        private void ClearActionStable()
        {
            cursorDrawingParams.TargetControlGraphics.DrawImage(Properties.MyKaiResources.cursor_empty_32, curPos.lastX - curPos.shift, curPos.lastY - curPos.shift);
        }

        // Drawing state
        private void DrawActionDrawing()
        {
            RedrawGestureOnControl();
        }

        // TryingToEndDraw state
        private void DrawActionTryingToEndDraw()
        {
            RedrawGestureOnControl();
        }

        // JustEndedDrawing state
        private void DrawActionJustEndedDrawing()
        {
            PlaySound(@".\Sounds\end_draw.wav");
        
            cursorDrawingParams.TargetControlGraphics.Clear(Color.Green);
            localGesture2DCopy.ClearFrames();
        }

         // Helper functions
        private void PlaySound(string pSoundFile)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(pSoundFile);
            player.Play();
        }

        private void RedrawGestureOnControl()
        {
            Graphics graphics = cursorDrawingParams.TargetControlGraphics;

            gestureDrawer.DrawGestureTrailOnGraphics(graphics, localGesture2DCopy);

            //graphics.Dispose();
        }
    }
}