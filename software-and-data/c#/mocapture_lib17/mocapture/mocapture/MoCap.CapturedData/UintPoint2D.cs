
namespace MoCap.CapturedData
{
    public class UintPoint2D : PointND<uint>
    {
        public UintPoint2D() : base(2)
        {
            Coordinates = new uint[2];
        }

        public uint X
        {
            get => Coordinates[0];
            set => Coordinates[0] = value;  
        }

        public uint Y
        {
            get => Coordinates[1];
            set => Coordinates[1] = value;
        }
    }
}
