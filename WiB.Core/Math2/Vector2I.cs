using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public readonly struct Vector2I : IEquatable<Vector2I>
    {
        public readonly int X;
        public readonly int Y;

        public static Vector2I Zero => new Vector2I(0, 0);
        public static Vector2I Left => new Vector2I(-1, 0);
        public static Vector2I Top => new Vector2I(0, 1);
        public static Vector2I Right => new Vector2I(1, 0);
        public static Vector2I Bottom => new Vector2I(0, -1);

        public static Vector2I One => new Vector2I(1, 1);

        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }

        public static Vector2I operator +(Vector2I l, Vector2I r)
        {
            return new Vector2I(l.X + r.X, l.Y + r.Y);
        }

        public static Vector2I operator -(Vector2I l, Vector2I r)
        {
            return new Vector2I(l.X - r.X, l.Y - r.Y);
        }

        public static Vector2I operator *(Vector2I l, int r)
        {
            return new Vector2I(l.X * r, l.Y * r);
        }

        public static Vector2I operator *(int l, Vector2I r)
        {
            return new Vector2I(r.X * l, r.Y * l);
        }

        public static Vector2I operator *(Vector2I l, float r)
        {
            return new Vector2I(Conversion.ToInt32(l.X * r), Conversion.ToInt32(l.Y * r));
        }

        public static Vector2I operator *(float l, Vector2I r)
        {
            return new Vector2I(Conversion.ToInt32(r.X * l), Conversion.ToInt32(r.Y * l));
        }

        public static Vector2I operator /(Vector2I l, int r)
        {
            return new Vector2I(l.X / r, l.Y / r);
        }

        public static bool operator ==(Vector2I l, Vector2I r)
        {
            if (l.X != r.X)
                return false;

            if (l.Y != r.Y)
                return false;

            return true;
        }

        public static bool operator !=(Vector2I l, Vector2I r)
        {
            return !(l == r);
        }

        public override bool Equals(object other)
        {
            if (other is not Vector2I vector2I)
                return false;

            return this == vector2I;
        }

        public bool Equals(Vector2I other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() << 2);
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Vector2I ToVector2I(Vector2F vector)
        {
            return new Vector2I(ToInt32(vector.X), ToInt32(vector.Y));
        }

        public static Vector2I ToVector2I(Var vector)
        {
            if (vector.VariantType == VariantType.List)
                return new Vector2I(vector[0], vector[1]);

            throw new ArgumentException($"Impossible conversion from: {vector.VariantType} to: {nameof(Vector2I)}.");
        }

        public static Var ToVar(Vector2I vector)
        {
            return Var.GetList(vector.X, vector.Y);
        }

        public static Vector2I ToVector2I(Vector2I vector, Orientation2 orientation)
        {
            if (orientation.Flip == Flip2.No)
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => new Vector2I(+vector.X, +vector.Y),
                    Rotation2.Angle90 => new Vector2I(-vector.Y, +vector.X),
                    Rotation2.Angle180 => new Vector2I(-vector.X, -vector.Y),
                    _ => new Vector2I(+vector.Y, -vector.X)
                };
            }
            else
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => new Vector2I(-vector.X, +vector.Y),
                    Rotation2.Angle90 => new Vector2I(-vector.Y, -vector.X),
                    Rotation2.Angle180 => new Vector2I(vector.X, -vector.Y),
                    _ => new Vector2I(+vector.Y, +vector.X)
                };
            }
        }

        public static Vector2I ToVector2I(Direction2 direction)
        {
            return direction switch
            {
                Direction2.Right => Vector2I.Right,
                Direction2.Top => Vector2I.Top,
                Direction2.Left => Vector2I.Left,
                _ => Vector2I.Bottom
            };
        }
    }
}