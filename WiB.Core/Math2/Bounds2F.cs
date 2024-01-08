using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public readonly struct Bounds2F
    {
        public readonly float MinX;
        public readonly float MaxX;
        public readonly float MinY;
        public readonly float MaxY;

        public Bounds2F(float minX, float minY, float maxX, float maxY)
        {
#if UNITY_EDITOR
            if (maxX < minX)
                throw new ArgumentException($"MaxX: {maxX} < MinX: {minX}");
#endif
            MinX = minX;
            MaxX = maxX;

#if UNITY_EDITOR
            if (maxX < minX)
                throw new ArgumentException($"MaxY: {maxY} < MinY: {minY}");
#endif
            MinY = minY;
            MaxY = maxY;
        }

        public static Bounds2F One => new Bounds2F(-0.5f, -0.5f, +0.5f, +0.5f);

        public float Width => MaxX - MinX;
        public float Height => MaxY - MinY;

        public float WidthHalf => Width * 0.5f;
        public float HeightHalf => Height * 0.5f;

        public float CenterX => WidthHalf + MinX;
        public float CenterY => HeightHalf + MinY;

        public Vector2F Center => new Vector2F(CenterX, CenterY);

        public Vector2F Size => new Vector2F(Width, Height);

        public Vector2F HalfSize => new Vector2F(WidthHalf, HeightHalf);

        public static bool Intersects(Bounds2F l, Bounds2F r, float floatError = Math.FloatError)
        {
            return l.MinX + floatError <= r.MaxX &&
                   l.MaxX >= r.MinX + floatError &&
                   l.MinY + floatError <= r.MaxY &&
                   l.MaxY >= r.MinY + floatError;
        }

        public static bool Intersects(Bounds2F bounds, Vector2F point)
        {
            if (point.X < bounds.MinX)
                return false;
            if (point.X > bounds.MaxX)
                return false;
            if (point.Y < bounds.MinY)
                return false;
            if (point.Y > bounds.MaxY)
                return false;

            return true;
        }

        public override string ToString()
        {
            return "MinX: " + MinX + " MinY: " + MinY + " MaxX: " + MaxX + " MaxY: " + MaxY;
        }

        public float IntersectionLengthSign(Bounds2F bounds, Direction2 direction)
        {
            return direction switch
            {
                Direction2.Left => Math.IntersectionLengthSign(bounds.MinX, bounds.MaxX, MinX, MaxX),
                Direction2.Top => Math.IntersectionLengthSign(bounds.MinY, bounds.MaxY, MinY, MaxY),
                Direction2.Right => Math.IntersectionLengthSign(bounds.MinX, bounds.MaxX, MinX, MaxX),
                _ => Math.IntersectionLengthSign(bounds.MinY, bounds.MaxY, MinY, MaxY)
            };
        }

        public float IntersectionLength(Bounds2F bounds, Direction2 direction)
        {
            return direction switch
            {
                Direction2.Left => Math.IntersectionLength(bounds.MinX, bounds.MaxX, MinX, MaxX),
                Direction2.Top => Math.IntersectionLength(bounds.MinY, bounds.MaxY, MinY, MaxY),
                Direction2.Right => Math.IntersectionLength(bounds.MinX, bounds.MaxX, MinX, MaxX),
                _ => Math.IntersectionLength(bounds.MinY, bounds.MaxY, MinY, MaxY)
            };
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Bounds2F ToBounds2F(float minX, float minY, float maxX, float maxY)
        {
            return new Bounds2F(minX, minY, maxX, maxY);
        }

        public static Bounds2F ToBounds2F(Var bounds)
        {
            if (bounds.VariantType == VariantType.List)
                return new Bounds2F(bounds[0], bounds[1], bounds[2], bounds[3]);
            
            throw new ArgumentException($"Impossible conversion from: {bounds.VariantType} to: {nameof(Bounds2F)}.");
        }

        public static Var ToVar(Bounds2F bounds)
        {
            return Var.GetList(bounds.MinX, bounds.MinY, bounds.MaxX, bounds.MaxY);
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, InverseOrientation2 orientation)
        {
            return ToBounds2F(bounds, InverseVector2F.Zero, orientation);
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, InverseVector2F position, InverseOrientation2 orientation)
        {
            var minX = bounds.MinX + position.X;
            var minY = bounds.MinY + position.Y;
            var maxX = bounds.MaxX + position.X;
            var maxY = bounds.MaxY + position.Y;

            if (orientation.Flip == Flip2.No)
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => ToBounds2F(+minX, +minY, +maxX, +maxY),
                    Rotation2.Angle90 => ToBounds2F(+minY, -maxX, +maxY, -minX),
                    Rotation2.Angle180 => ToBounds2F(-maxX, -maxY, -minX, -minY),
                    _ => ToBounds2F(-maxY, +minX, -minY, +maxX)
                };
            }
            else
            {
                return orientation.Rotation switch
                {
                    Rotation2.Angle0 => ToBounds2F(-maxX, +minY, -minX, +maxY),
                    Rotation2.Angle90 => ToBounds2F(-maxY, -maxX, -minY, -minX),
                    Rotation2.Angle180 => ToBounds2F(+minX, -maxY, +maxX, -minY),
                    _ => ToBounds2F(+minY, +minX, +maxY, +maxX)
                };
            }
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, Vector2F position, Orientation2 orientation)
        {
            var minX = bounds.MinX;
            var minY = bounds.MinY;
            var maxX = bounds.MaxX;
            var maxY = bounds.MaxY;

            if (orientation.Flip == Flip2.Yes)
            {
                minX = -bounds.MaxX;
                maxX = -bounds.MinX;
            }

            return orientation.Rotation switch
            {
                Rotation2.Angle0 => ToBounds2F(+minX + position.X, +minY + position.Y, +maxX + position.X,
                    +maxY + position.Y),
                Rotation2.Angle90 => ToBounds2F(-maxY + position.X, +minX + position.Y, -minY + position.X,
                    +maxX + position.Y),
                Rotation2.Angle180 => ToBounds2F(-maxX + position.X, -maxY + position.Y, -minX + position.X,
                    -minY + position.Y),
                _ => ToBounds2F(+minY + position.X, -maxX + position.Y, +maxY + position.X, -minX + position.Y)
            };
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, Orientation2 orientation)
        {
            return ToBounds2F(bounds, Vector2F.Zero, orientation);
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, Vector2F position)
        {
            return ToBounds2F(bounds, position, Orientation2.Default);
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, Direction2 direction, float distance)
        {
            return direction switch
            {
                Direction2.Left => new Bounds2F(bounds.MinX - distance, bounds.MinY, bounds.MinX, bounds.MaxY),
                Direction2.Top => new Bounds2F(bounds.MinX, bounds.MaxY, bounds.MaxX, bounds.MaxY + distance),
                Direction2.Right => new Bounds2F(bounds.MaxX, bounds.MinY, bounds.MaxX + distance, bounds.MaxY),
                _ => new Bounds2F(bounds.MinX, bounds.MinY - distance, bounds.MaxX, bounds.MinY)
            };
        }

        public static Bounds2F ToBounds2F(Bounds2F bounds, float distance)
        {
            return new Bounds2F(bounds.MinX - distance, bounds.MinY - distance, bounds.MaxX + distance,
                bounds.MaxY + distance);
        }


        /*
        public static Bounds2f ToBounds2f(Bounds2f bounds, float angle)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            var x1 = bounds.MinX * cos + bounds.MinY * sin;
            var x2 = bounds.MinX * cos + bounds.MaxY * sin;
            var x3 = bounds.MaxX * cos + bounds.MaxY * sin;
            var x4 = bounds.MaxX * cos + bounds.MinY * sin;

            var y1 = bounds.MinY * cos - bounds.MinX * sin;
            var y2 = bounds.MinY * cos - bounds.MaxX * sin;
            var y3 = bounds.MaxY * cos - bounds.MaxX * sin;
            var y4 = bounds.MaxY * cos - bounds.MinX * sin;

            var minX = x1;

            if (x2 < minX)
                minX = x2;
            if (x3 < minX)
                minX = x3;
            if (x4 < minX)
                minX = x4;

            var minY = y1;

            if (y2 < minY)
                minY = y2;
            if (y3 < minY)
                minY = y3;
            if (y4 < minY)
                minY = y4;

            var maxX = x1;

            if (x2 > maxX)
                maxX = x2;
            if (x3 > maxX)
                maxX = x3;
            if (x4 > maxX)
                maxX = x4;

            var maxY = y1;

            if (y2 > maxY)
                maxY = y2;
            if (y3 > maxY)
                maxY = y3;
            if (y4 > maxY)
                maxY = y4;

            return new Bounds2f(minX, minY, maxX, maxY);
        }
        */

        public static Bounds2F ToBounds2F(Bounds2F bounds1, Bounds2F bounds2)
        {
            var minX = bounds1.MinX < bounds2.MinX ? bounds1.MinX : bounds2.MinX;
            var minY = bounds1.MinY < bounds2.MinY ? bounds1.MinY : bounds2.MinY;
            var maxX = bounds1.MaxX > bounds2.MaxX ? bounds1.MaxX : bounds2.MaxX;
            var maxY = bounds1.MaxY > bounds2.MaxY ? bounds1.MaxY : bounds2.MaxY;

            return new Bounds2F(minX, minY, maxX, maxY);
        }

        public static Bounds2F ToBounds2F(Vector2F center, Vector2F size)
        {
            return new Bounds2F(center.X - size.X * 0.5f, center.Y - size.Y * 0.5f, center.X + size.X * 0.5f,
                center.Y + size.Y * 0.5f);
        }

        public static Bounds2F ToBounds2F(Vector2F size)
        {
            return new Bounds2F(-size.X * 0.5f, -size.Y * 0.5f, size.X * 0.5f, size.Y * 0.5f);
        }
    }
}