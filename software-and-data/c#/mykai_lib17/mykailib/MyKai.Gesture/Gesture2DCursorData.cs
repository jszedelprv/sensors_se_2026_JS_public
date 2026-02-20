using System;

namespace MyKai.Gesture
{
    public class Gesture2DCursorData
    {
        PositionData position;
        public PositionData Position { get => position; }
       
        PositionInPixelsData positionInPixels;
        public PositionInPixelsData PositionInPixels { get => positionInPixels; }
        
        //public Bitmap CapturedGestureBitmap { get; set; }

        ViewportDataContainer viewport;

        public ViewportDataContainer Viewport { get => viewport; }

        AngularData angles;
        public AngularData Angles { get => angles; }

        public (float xAngle, float yAngle) GetAngles()
        {
            return (angles.XAngle, angles.YAngle);
        }

        public Gesture2DCursorData()
        {
            position = new PositionData();
            positionInPixels = new PositionInPixelsData();
            viewport = new ViewportDataContainer();
            angles = new AngularData();
        }

        public void CopyDataTo(ref Gesture2DCursorData pTarget)
        {
            pTarget.positionInPixels.XPix = this.positionInPixels.XPix;
            pTarget.positionInPixels.YPix = this.positionInPixels.YPix;
            pTarget.position.X = this.position.X;
            pTarget.position.Y = this.position.Y;           
            pTarget.viewport.Width = this.viewport.Width;
            pTarget.viewport.Height = this.viewport.Height;
            pTarget.angles.XAngle = this.angles.XAngle;
            pTarget.angles.YAngle = this.angles.YAngle;
        }

        public class PositionData : ILimited
        {
            float xPosition = 0, yPosition = 0; // Position coordinates range from 0.0f to 1.0f.
                                                // For the top-left corner of the viewport both, xPosition and yPosition are equal to 0.0f.                                    
            public float X { get => xPosition; set { xPosition = value; } }
            public float Y { get => yPosition; set { yPosition = value; } }

            public void SetData(float pXPosition, float pYPosition)
            {
                xPosition = pXPosition;
                yPosition = pYPosition;

                CheckRange();
            }

            protected override bool IsCorrect() => xPosition >= 0.0f && yPosition >= 0.0f && xPosition <= 1.0f && yPosition <= 1.0f;

            protected override Exception GetInvalidRangeException() => new InvalidGestureCursorPosition(this);

            public class InvalidGestureCursorPosition : ILimitedRangeException<PositionData>
            {
                public InvalidGestureCursorPosition(PositionData pPosition) : base(pPosition) { }

                public override string Message => $"The gesture cursor normalized position is invalid (xPosition = {limitedValues.xPosition}, " +
                    $"yPosition = {limitedValues.yPosition}).";
            }
        }

        public class PositionInPixelsData : ILimited
        {
            int xPositionInPixels, yPositionInPixels; // At the top-left corner of the viewport, both xPosition and yPosition are equal to 0.              
            
            ViewportDataContainer viewport;
            
            public int XPix { get => xPositionInPixels; set { xPositionInPixels = value; } }
            public int YPix { get => yPositionInPixels; set { yPositionInPixels = value; } }

            public void SetData(int pXPositionInPixels, int pYPositionInPixels, in ViewportDataContainer pViewport)
            {
                xPositionInPixels = pXPositionInPixels;
                yPositionInPixels = pYPositionInPixels;
                viewport = pViewport;

                CheckRange();
            }

            protected override bool IsCorrect() => xPositionInPixels >= 0 && yPositionInPixels >= 0 && xPositionInPixels <= viewport.Width && yPositionInPixels <= viewport.Height;

            protected override Exception GetInvalidRangeException() => new InvalidGestureCursorPositionInPixels(this);

            public class InvalidGestureCursorPositionInPixels : ILimitedRangeException<PositionInPixelsData>
            {
                public InvalidGestureCursorPositionInPixels(PositionInPixelsData pPosition) : base(pPosition) { }

                public override string Message => $"The gesture cursor position in pixels is invalid " +
                    $"(xPosition = {limitedValues.xPositionInPixels}, yPosition = {limitedValues.yPositionInPixels}).";
            }
        }

        public class ViewportDataContainer : ILimited
        {
            int width = 1, height = 1; // The size of the viewport is specified in pixels. It should be greater than 0.
            public int Width { get => width; set { width = value; } }
            public int Height { get => height; set { height = value; } }

            public void SetData(int pWidth, int pHeight)
            {
                width = pWidth;
                height = pHeight;

                CheckRange();
            }

            protected override bool IsCorrect() => width >= 1 && height >= 0;

            protected override Exception GetInvalidRangeException() => new InvalidGestureCursorViewportSize(this);

            public class InvalidGestureCursorViewportSize : ILimitedRangeException<ViewportDataContainer>
            {
                public InvalidGestureCursorViewportSize(ViewportDataContainer pViewport) : base(pViewport) { }

                public override string Message => $"The gesture cursor viewport size is invalid " +
                    $"(viewportWidth = {limitedValues.width}, viewportHeight = {limitedValues.height}).";
            }
        }

        public class AngularData : ILimited
        {
            protected float maxAngle;

            float xAngle = 0, yAngle = 0;                    // Angles reflected by the cursor specified in radians of range <-PI;PI>.
                                                             // Some implementation may restrict this range, depending on the way that angles 
                                                             // are interpreted by the implementation.     
            public float XAngle { get => xAngle; set { xAngle = value;  } }
            public float YAngle { get => yAngle; set { yAngle = value; } }

            protected override bool IsCorrect()
                => xAngle >= -maxAngle && yAngle >= -maxAngle && xAngle <= maxAngle && yAngle <= maxAngle;

            public void SetData(float pXAngle, float pYAngle, float pMaxAngle)
            {
                maxAngle = pMaxAngle;

                xAngle = pXAngle;
                yAngle = pYAngle;

                CheckRange();
            }

            protected override Exception GetInvalidRangeException() => new InvalidGestureCursorAngle(this, maxAngle);

            public class InvalidGestureCursorAngle : ILimitedRangeException<AngularData>
            {
                readonly float maxAngle;

                public InvalidGestureCursorAngle(AngularData angularData, float pMaxAngle) : base(angularData) 
                {
                    maxAngle = pMaxAngle; 
                }

                public override string Message => $"The gesture cursor angular data is invalid (xAxisAngle = {limitedValues.xAngle}, " +
                    $"yAxisAngle = {limitedValues.yAngle}, maxAngle = {maxAngle}).";
            }
        }
    }
}
