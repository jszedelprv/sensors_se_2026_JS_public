
namespace MyKai.Gesture
{
    public interface IGesture2DIsStableChecker
    {
        void MeasureStability(float pX, float pY);
        bool IsCursorStableRough();
        bool IsCursorStableFine();
    }
}
