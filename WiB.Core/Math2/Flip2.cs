using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public enum Flip2
    {
        No = 0,
        Yes = 1
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Flip2 ToFlip2(ReadOnlySpan<char> source)
        {
            if (!IsFlip2(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }
        
        public static bool IsFlip2(ReadOnlySpan<char> source, out Flip2 destination)
        {
            return Enum.TryParse(source, out destination);
        }

        public static Flip2 ToFlip2(Direction2 direction)
        {
            return direction == Direction2.Left ? Flip2.Yes : Flip2.No;
        }

        public static float ToFloat(Flip2 flip)
        {
            return flip == Flip2.Yes ? -1.0f : 1.0f;
        }

        public static Flip2 ToFlip2(Var root)
        {
            if (root.VariantType == VariantType.Int32)
                return ToFlip2((int)root);

            throw new ArgumentException($"Impossible conversion from: {root.VariantType} to: {nameof(Flip2)}.");
        }

        public static Var ToVar(Flip2 flip)
        {
            return (int)flip;
        }
        
        public static Flip2 ToFlip2(int flip)
        {
            return (Flip2)flip;
        }
    }
}