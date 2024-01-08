using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public enum Rotation2
    {
        Angle0 = 0,
        Angle90 = 1,
        Angle180 = 2,
        Angle270 = 3,
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Rotation2 ToRotation2(Var rotation)
        {
            if (rotation.VariantType == VariantType.Int32)
                return ToRotation2((int)rotation);

            throw new ArgumentException($"Impossible conversion from: {rotation.VariantType} to: {nameof(Rotation2)}.");
        }

        public static Var ToVar(Rotation2 rotation)
        {
            return ToInt32(rotation);
        }
        
        public static Rotation2 ToRotation2(ReadOnlySpan<char> source)
        {
            if (!IsRotation2(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }
        
        public static bool IsRotation2(ReadOnlySpan<char> source, out Rotation2 destination)
        {
            return Enum.TryParse(source, out destination);
        }
        
        public static float ToAngle(Rotation2 rotation)
        {
            return rotation switch
            {
                Rotation2.Angle0 => 0.0f,
                Rotation2.Angle90 => Math.Pi / 2.0f,
                Rotation2.Angle180 => Math.Pi,
                Rotation2.Angle270 => Math.Pi * 3.0f / 2.0f,
                _ => throw new ArgumentOutOfRangeException(nameof(rotation), ToString(rotation))
            };
        }

        public static string ToString(Rotation2 rotation)
        {
            return rotation.ToString();
        }

        public static int ToInt32(Rotation2 rotation)
        {
            return (int)rotation;
        }

        public static Rotation2 ToRotation2(int rotation)
        {
            return (Rotation2)rotation;
        }
    }
}