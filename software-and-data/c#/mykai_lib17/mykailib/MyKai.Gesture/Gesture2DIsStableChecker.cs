using System;

namespace MyKai.Gesture
{
    public class Gesture2DIsStableChecker : IGesture2DIsStableChecker
    {
        const float roughStabilityThreshold = 0.01f;
        const float fineStabilityThreshold = 0.0025f;


        readonly (float x, float y)[] coordinates = { (0,0), (0,0) };
        int coordinatesCounter = 0;

        bool canDecide = false;

        public void MeasureStability(float pX, float pY)
        {
            AddNewCoordinates(pX, pY);
            IncrementCounter();
        }

        void AddNewCoordinates(float pX, float pY)
        {
            coordinates[0] = coordinates[1];

            coordinates[1].x = pX;
            coordinates[1].y = pY;
        }

        void IncrementCounter()
        {
            if (coordinatesCounter < 1)
                coordinatesCounter++;
            
            canDecide = coordinatesCounter == 1;
        }

        public bool IsCursorStableRough()
        {
            if (canDecide)
                return Math.Abs(coordinates[0].x - coordinates[1].x) < roughStabilityThreshold && 
                       Math.Abs(coordinates[0].y - coordinates[1].y) < roughStabilityThreshold;
            else
                return false;
        }

        public bool IsCursorStableFine()
        {
            if (canDecide)
                return Math.Abs(coordinates[0].x - coordinates[1].x) < fineStabilityThreshold &&
                       Math.Abs(coordinates[0].y - coordinates[1].y) < fineStabilityThreshold;
            else
                return false;
        }
    }
}
