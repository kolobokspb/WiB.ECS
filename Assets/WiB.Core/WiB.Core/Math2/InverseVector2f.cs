namespace WiB.Math2
{
    public readonly struct InverseVector2F
    {
        public readonly float X;
        public readonly float Y;
        public static InverseVector2F Zero => new InverseVector2F(0.0f, 0.0f);

        public InverseVector2F(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
    }
}