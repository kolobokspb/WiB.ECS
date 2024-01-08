using WiB.Math2;

namespace WiB.Math2
{
    public enum Normal
    {
        Right = 0,
        Top = 1,
        Left = 2,
        Bottom = 3
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        private static readonly Vector2F[] _normals = 
        {
            new(1.0f, 0.0f),
            new(0.0f, 1.0f),
            new(-1.0f, 0.0f),
            new(0.0f, -1.0f)
        };

        public static Vector2F ToVector2F(Normal normal)
        {
            return _normals[(int)normal];
        }
    }
}