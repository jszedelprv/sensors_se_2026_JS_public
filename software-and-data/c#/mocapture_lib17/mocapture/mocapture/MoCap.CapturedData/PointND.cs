using System;

namespace MoCap.CapturedData
{
    public class PointND<T>
    {
        public T[] Coordinates { get; set; }

        private readonly uint dimension;

        public uint Dimension
        {
            get { return dimension; }
        }

        public PointND(uint pDimension)
        {
            dimension = pDimension;
            if (dimension == 0)
                throw new ArgumentException("Dimension must be greater than zero.", nameof(pDimension));

            for (int i = 0; i < dimension; i++)
                Coordinates = new T[dimension]; 
        }

        public T this[int index]
        {
            get => Coordinates[index];
            set => Coordinates[index] = value;
        }


        public double DistanceTo(PointND<T> pOtherPoint)
        {
            if (pOtherPoint == null)
                throw new ArgumentNullException(nameof(pOtherPoint));

            if (pOtherPoint.Dimension != this.Dimension)
                throw new ArgumentException("Points must have the same dimension.", nameof(pOtherPoint));
            
            double sum = 0;
            for (int i = 0; i < Dimension; i++)
            {
                double diff = ToDouble(this[i]) - ToDouble(pOtherPoint[i]);
                sum += diff * diff;
            }

            return Math.Sqrt(sum);
        }

        private static double ToDouble(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return Convert.ToDouble(value);
        }
    }
}
