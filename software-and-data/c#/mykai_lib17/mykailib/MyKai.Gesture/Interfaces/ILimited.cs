using System;

namespace MyKai.Gesture
{
    public abstract class ILimited
    {
        protected abstract bool IsCorrect();
        protected abstract Exception GetInvalidRangeException();
        public void CheckRange()
        {
            if (!IsCorrect())
                throw GetInvalidRangeException();
        }
    }

    public class ILimitedProperty<T> where T : ILimited
    {
        T _value;

        public T Values
        {
            get => _value;
            set
            {
                _value = value;
                _value.CheckRange();
            }
        }
    }

    public abstract class ILimitedRangeException<T> : Exception where T : ILimited
    {
        protected T limitedValues;
        protected ILimitedRangeException(T pLimitedValues)
        {
            limitedValues = pLimitedValues;
        }
    }
}
