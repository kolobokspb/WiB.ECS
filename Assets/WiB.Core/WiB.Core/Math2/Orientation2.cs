using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    [Serializable]
    public readonly struct Orientation2
    {
#if UNITY_2019_1_OR_NEWER
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        public Rotation2 Rotation;
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        public Flip2 Flip;
#else
        public readonly Rotation2 Rotation;
        public readonly Flip2 Flip;
#endif

        public static Orientation2 Default = new(Rotation2.Angle0, Flip2.No);
        public static Orientation2 Opposite = new(Rotation2.Angle180, Flip2.No);

        public Orientation2(Rotation2 rotation, Flip2 flip)
        {
            Rotation = rotation;
            Flip = flip;
        }

        public Orientation2 Next90()
        {
            return new Orientation2((Rotation2)(((int)Rotation + 1) % 4), Flip);
        }

        public Orientation2 Prev90()
        {
            return new Orientation2((Rotation2)((4 + (int)Rotation - 1) % 4), Flip);
        }

        public InverseOrientation2 Inverse()
        {
            return new InverseOrientation2(Rotation, Flip);
        }

        public static bool operator ==(Orientation2 a, Orientation2 b)
        {
            return a.Rotation == b.Rotation && a.Flip == b.Flip;
        }

        public static bool operator !=(Orientation2 a, Orientation2 b)
        {
            return !(a == b);
        }

        public bool Equals(Orientation2 other)
        {
            return Rotation == other.Rotation && Flip == other.Flip;
        }

        public override bool Equals(object obj)
        {
            return obj is Orientation2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (int)Rotation + (int)Flip * 10;
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Orientation2 ToOrientation2(Var orientation)
        {
            if (orientation.VariantType == VariantType.List)
                return new Orientation2(ToRotation2(orientation[0]), ToFlip2(orientation[1]));

            throw new ArgumentException($"Impossible conversion from: {orientation.VariantType} to: {nameof(Orientation2)}.");
        }

        public static Var ToVar(Orientation2 orientation)
        {
            return Var.GetList(ToVar(orientation.Rotation), ToVar(orientation.Flip));
        }

        public static Orientation2 ToOrientation2(Direction2 direction)
        {
            return direction switch
            {
                Direction2.Right => new Orientation2(Rotation2.Angle0, Flip2.No),
                Direction2.Top => new Orientation2(Rotation2.Angle90, Flip2.No),
                Direction2.Left => new Orientation2(Rotation2.Angle180, Flip2.No),
                _ => new Orientation2(Rotation2.Angle270, Flip2.No)
            };
        }

        public static Orientation2 ToOrientation2(Rotation2 rotation, Flip2 flip)
        {
            return new Orientation2(rotation, flip);
        }
    }
}