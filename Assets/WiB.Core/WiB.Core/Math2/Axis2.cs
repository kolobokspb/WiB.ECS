using WiB.Math2;

namespace WiB.Math2
{
    public enum Axis2
    {
        X = 0,
        Y = 1,
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Axis2 ToAxis(Orientation2 orientation)
        {
            return orientation.Rotation switch
            {
                Rotation2.Angle0 => Axis2.X,
                Rotation2.Angle90 => Axis2.Y,
                Rotation2.Angle180 => Axis2.X,
                _ => Axis2.Y
            };
        }

        public static Axis2 ToAxis(Axis2 axis, Orientation2 orientation)
        {
            if (axis == Axis2.X)
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => Axis2.X,
                    Rotation2.Angle90 => Axis2.Y,
                    Rotation2.Angle180 => Axis2.X,
                    _ => Axis2.Y
                };
            }
            else
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => Axis2.Y,
                    Rotation2.Angle90 => Axis2.X,
                    Rotation2.Angle180 => Axis2.Y,
                    _ => Axis2.X
                };
            }
        }
    }
}