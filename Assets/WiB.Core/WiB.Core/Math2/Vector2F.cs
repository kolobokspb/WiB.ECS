using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public readonly struct Vector2F : IEquatable<Vector2F>
    {
        public readonly float X;
        public readonly float Y;

        public static Vector2F Zero => new Vector2F(0.0f, 0.0f);
        public static Vector2F Left => new Vector2F(-1.0f, 0.0f);
        public static Vector2F Top => new Vector2F(0.0f, 1.0f);
        public static Vector2F Right => new Vector2F(1.0f, 0.0f);
        public static Vector2F Bottom => new Vector2F(0.0f, -1.0f);

        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2F operator +(Vector2F vectorL, Vector2F vectorR)
        {
            return new Vector2F(vectorL.X + vectorR.X, vectorL.Y + vectorR.Y);
        }

        public static Vector2F operator -(Vector2F vectorL, Vector2F vectorR)
        {
            return new Vector2F(vectorL.X - vectorR.X, vectorL.Y - vectorR.Y);
        }

        public static Vector2F operator *(Vector2F vector, float value)
        {
            return new Vector2F(vector.X * value, vector.Y * value);
        }

        public static Vector2F operator *(float value, Vector2F vector)
        {
            return new Vector2F(vector.X * value, vector.Y * value);
        }

        public static Vector2F operator /(Vector2F vector, float value)
        {
            return new Vector2F(vector.X / value, vector.Y / value);
        }

        public static Vector2F operator -(Vector2F vector)
        {
            return new Vector2F(-vector.X, -vector.Y);
        }

        public override string ToString()
        {
            return "X: " + Conversion.ToString(X) + " Y: " + Conversion.ToString(Y);
        }

        public static bool operator ==(Vector2F vectorL, Vector2F vectorR)
        {
            if (!Math.CompareFloat(vectorL.X, vectorR.X))
                return false;

            if (!Math.CompareFloat(vectorL.Y, vectorR.Y))
                return false;

            return true;
        }

        public static bool operator !=(Vector2F vectorL, Vector2F vectorR)
        {
            return !(vectorL == vectorR);
        }

        public bool Equals(Vector2F other)
        {
            return this == other;
        }

        public override bool Equals(object other)
        {
            if (other is not Vector2F vector2F)
                return false;

            return this == vector2F;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        private const float Error = Math.FloatError * Math.FloatError * 2.0f;

        public bool IsZero()
        {
            return X * X + Y * Y < Error;
        }

        public static Vector2F Normalize(Vector2F vector)
        {
            var length = vector.Length;
            return length < Math.FloatError ? Zero : new Vector2F(vector.X / length, vector.Y / length);
        }

        public float Length => Math.Sqrt(X * X + Y * Y);

        public static Vector2F Rotate(Vector2F vector, float angle)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            var x = vector.X * cos - vector.Y * sin;
            var y = vector.X * sin + vector.Y * cos;

            return new Vector2F(x, y);
        }

        public InverseVector2F Inverse()
        {
            return new InverseVector2F(-X, -Y);
        }

        public static float Dot(Vector2F vector1, Vector2F vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }

        public static float Cross(Vector2F vector1, Vector2F vector2)
        {
            return vector1.X * vector2.Y - vector1.Y * vector2.X;
        }

        public static Vector2F Reflect(Vector2F direction, Vector2F normal)
        {
            return direction - 2.0f * Dot(direction, normal) * normal;
        }

        public static Vector2F Project(Vector2F vector, Vector2F normal)
        {
            var sqrMag = Dot(normal, normal);

            if (sqrMag < float.Epsilon)
                return Zero;

            var dot = Dot(vector, normal);

            return new Vector2F(normal.X * dot / sqrMag,
                normal.Y * dot / sqrMag);
        }

        public static Vector2F Confine(Vector2F point, Bounds2F bounds)
        {
            if (point.X < bounds.MinX && point.Y < bounds.MinY)
                return new Vector2F(bounds.MinX, bounds.MinY);
            if (point.X < bounds.MinX && point.Y > bounds.MaxY)
                return new Vector2F(bounds.MinX, bounds.MaxY);
            if (point.X > bounds.MaxX && point.Y > bounds.MaxY)
                return new Vector2F(bounds.MaxX, bounds.MaxY);
            if (point.X > bounds.MaxX && point.Y < bounds.MinY)
                return new Vector2F(bounds.MaxX, bounds.MinY);

            if (point.X < bounds.MinX)
                return new Vector2F(bounds.MinX, point.Y);
            if (point.Y > bounds.MaxY)
                return new Vector2F(point.X, bounds.MaxY);
            if (point.X > bounds.MaxX)
                return new Vector2F(bounds.MaxX, point.Y);
            if (point.Y < bounds.MinY)
                return new Vector2F(point.X, bounds.MinY);

            return point;
        }

        public static float Distance(Vector2F vector1, Vector2F vector2)
        {
            var dx = vector1.X - vector2.X;
            var dy = vector1.Y - vector2.Y;

            var ls = dx * dx + dy * dy;

            return Math.Sqrt(ls);
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Vector2F ToVector2F(Var vector)
        {
            if (vector.VariantType == VariantType.List)
                return new Vector2F(vector[0], vector[1]);

            throw new ArgumentException($"Impossible conversion from: {vector.VariantType} to: {nameof(Vector2F)}.");
        }

        public static Var ToVar(Vector2F vector)
        {
            return Var.GetList(vector.X, vector.Y);
        }

        /*
        public static Vector2f InverseTransformPoint(Vector2f vector, Vector2f position, Orientation2 orientation)
        {
            var t = vector + position;
            return InverseTransformDirection(t, orientation);
        }
        */
        public static Vector2F ToVector2F(Vector2F vector, InverseOrientation2 orientation)
        {
            var result = orientation.Rotation switch
            {
                Rotation2.Angle0 => new Vector2F(+vector.X, +vector.Y),
                Rotation2.Angle90 => new Vector2F(+vector.Y, -vector.X),
                Rotation2.Angle180 => new Vector2F(-vector.X, -vector.Y),
                _ => new Vector2F(-vector.Y, +vector.X)
            };

            return orientation.Flip == Flip2.Yes ? new Vector2F(-result.X, result.Y) : result;
        }

        public static Vector2F ToVector2F(Vector2F vector, Orientation2 orientation)
        {
            if (orientation.Flip == Flip2.No)
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => new Vector2F(+vector.X, +vector.Y),
                    Rotation2.Angle90 => new Vector2F(-vector.Y, +vector.X),
                    Rotation2.Angle180 => new Vector2F(-vector.X, -vector.Y),
                    _ => new Vector2F(+vector.Y, -vector.X)
                };
            }
            else
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => new Vector2F(-vector.X, +vector.Y),
                    Rotation2.Angle90 => new Vector2F(-vector.Y, -vector.X),
                    Rotation2.Angle180 => new Vector2F(vector.X, -vector.Y),
                    _ => new Vector2F(+vector.Y, +vector.X)
                };
            }
        }

        public static Vector2F ToVector2F(float angle, Orientation2 orientation)
        {
            return ToVector2F(Vector2F.Rotate(Vector2F.Right, angle), orientation);
        }

        public static Vector2F ToVector2F(Direction2 direction, Orientation2 orientation)
        {
            return ToVector2F(ToDirection(direction, orientation));
        }

        public static Vector2F ToVector2F(Direction2 direction)
        {
            return direction switch
            {
                Direction2.Right => Vector2F.Right,
                Direction2.Top => Vector2F.Top,
                Direction2.Left => Vector2F.Left,
                _ => Vector2F.Bottom
            };
        }

        public static Vector2F ToVector2F(Vector2F vector, float angle)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            var x = vector.X * cos - vector.Y * sin;
            var y = vector.X * sin + vector.Y * cos;

            return new Vector2F(x, y);
        }

        public static Vector2F ToVector2F(Vector2I vector)
        {
            return new Vector2F(ToFloat(vector.X), ToFloat(vector.Y));
        }
    }
}