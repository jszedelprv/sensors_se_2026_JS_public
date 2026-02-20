
using System;


namespace MyKai.Gesture
{
    internal class Gesture2DCursor : Gesture2DCursorBase
    {
        public override void SetPosition(float pXNormalized, float pYNormalized)
        {
            GestureData.Position.SetData(pXNormalized, pYNormalized);

            CalculateDataFromPosition();
        }

        public override void SetPositionInPixels(int pXInPixels, int pYInPixels)
        {
            GestureData.PositionInPixels.SetData(pXInPixels, pYInPixels, GestureData.Viewport);   
            
            CalculateDataFromPosInPixels();
        }

        public override void SetPositionUsingAngularData(float pXAngle, float pYAngle)
        {
            GestureData.Angles.SetData(pXAngle, pYAngle, AngleLimit);

            CalculateDataFromAngles();
        }

        public override (uint X, uint Y) GetPositionInPixels() => ((uint)GestureData.PositionInPixels.XPix, (uint)GestureData.PositionInPixels.YPix);

        public override void SetViewportSize(int pWidthInPixels, int pHeightInPixels)
        {
            GestureData.Viewport.SetData(pWidthInPixels, pHeightInPixels);

            CalculateDataAfterViewPortChanged();
        }

        public override void PerformGestureFrameAction()
        {
            Gesture2DCursorStateMachine.StateVariables stateVars = new Gesture2DCursorStateMachine.StateVariables();

            MeasureCursorStability(ref stateVars);

            StateMachine.PerformAction(stateVars);

            //InformTargetControlOfStateChanged();
        }

        private void MeasureCursorStability(ref Gesture2DCursorStateMachine.StateVariables pStateVars)
        {
            IsStableChcecker.MeasureStability(GestureData.Position.X, GestureData.Position.Y);
            pStateVars.IsStable = IsStableChcecker.IsCursorStableRough();
            pStateVars.IsCaptureOn = true;
        }

        private void CalculateDataFromPosition()
        {
            int xPix, yPix;
            float xAngle, yAngle;

            xPix = (int)((float)GestureData.PositionInPixels.XPix / GestureData.Viewport.Width);
            yPix = (int)((float)GestureData.PositionInPixels.YPix / GestureData.Viewport.Height);
            GestureData.PositionInPixels.SetData(xPix, yPix, GestureData.Viewport);

            xAngle = (float)Math.Atan(2 * GestureData.Position.X - 1.0f);
            yAngle = (float)Math.Atan(2 * GestureData.Position.Y - 1.0f);
            GestureData.Angles.SetData(xAngle, yAngle, AngleLimit);
        }

        private void CalculateDataFromPosInPixels()
        {
            float xPos, yPos, xAngle, yAngle;

            xPos = (float)GestureData.PositionInPixels.XPix / GestureData.Viewport.Width;
            yPos = (float)GestureData.PositionInPixels.YPix / GestureData.Viewport.Height;
            GestureData.Position.SetData(xPos, yPos);

            xAngle = (float)Math.Atan(2*GestureData.Position.X - 1.0f);
            yAngle = (float)Math.Atan(2*GestureData.Position.Y - 1.0f);
            GestureData.Angles.SetData(xAngle, yAngle, AngleLimit);
        }

        private void CalculateDataFromAngles()
        {
            float xPos, yPos;
            int xPix, yPix;

            xPos = 0.5f*(float)Math.Tan(GestureData.Angles.XAngle) + 0.5f;
            yPos = 0.5f*(float)Math.Tan(GestureData.Angles.YAngle) + 0.5f;
            GestureData.Position.SetData(xPos, yPos);

            xPix = (int)(GestureData.Position.X * GestureData.Viewport.Width);
            yPix = (int)(GestureData.Position.Y * GestureData.Viewport.Height);
            GestureData.PositionInPixels.SetData(xPix, yPix, GestureData.Viewport);
        }

        private void CalculateDataAfterViewPortChanged()
        {
            float xPos, yPos;

            xPos = (float)GestureData.PositionInPixels.XPix / GestureData.Viewport.Width;
            yPos = (float)GestureData.PositionInPixels.YPix / GestureData.Viewport.Height;
            GestureData.Position.SetData(xPos, yPos);
        }
    }
}
