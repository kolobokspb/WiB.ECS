namespace WiB.Math2
{
    public readonly struct InverseOrientation2
    {
        public static InverseOrientation2 Default = new InverseOrientation2(Rotation2.Angle0, Flip2.No);

        public InverseOrientation2(Rotation2 rotation, Flip2 flip)
        {
            Rotation = rotation;
            Flip = flip;
        }

        public readonly Rotation2 Rotation;
        public readonly Flip2 Flip;
    }
}

namespace WiB
{
    public static partial class Conversion
    {
    }
}