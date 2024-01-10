using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public readonly struct Bounds2I
    {
        public readonly int MinX;
        public readonly int MaxX;
        public readonly int MinY;
        public readonly int MaxY;

        public Bounds2I(int minX, int minY, int maxX, int maxY)
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


        public bool Contains(Vector2I point)
        {
            if (point.X < MinX)
                return false;
            if (point.X >= MaxX)
                return false;

            if (point.Y < MinY)
                return false;
            if (point.Y >= MaxY)
                return false;

            return true;
        }

        public int Width => MaxX - MinX;
        public int Height => MaxY - MinY;

        public override string ToString()
        {
            return "MinX: " + MinX + " MinY: " + MinY + " MaxX: " + MaxX + " MaxY: " + MaxY;
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Bounds2I ToBounds2F(Vector2F position, Bounds2F bounds)
        {
            return new Bounds2I
            (
                minX: ToInt32(Math.Floor(position.X + bounds.MinX)),
                minY: ToInt32(Math.Floor(position.Y + bounds.MinY)),
                maxX: ToInt32(Math.Ceiling(position.X + bounds.MaxX)),
                maxY: ToInt32(Math.Ceiling(position.Y + bounds.MaxY))
            );
        }

        public static Bounds2I ToBounds2I(Var bounds)
        {
            if (bounds.VariantType == VariantType.List)
                return new Bounds2I(bounds[0], bounds[1], bounds[2], bounds[3]);
            
            throw new ArgumentException($"Impossible conversion from: {bounds.VariantType} to: {nameof(Bounds2I)}.");
        }

        public static Var ToVar(Bounds2I bounds)
        {
            return Var.GetList(bounds.MinX, bounds.MinY, bounds.MaxX, bounds.MaxY);
        }

        public static Bounds2I ToBounds2I(Bounds2F bounds)
        {
            return new Bounds2I
            (
                minX: ToInt32(Math.Floor(bounds.MinX)),
                minY: ToInt32(Math.Floor(bounds.MinY)),
                maxX: ToInt32(Math.Ceiling(bounds.MaxX)),
                maxY: ToInt32(Math.Ceiling(bounds.MaxY))
            );
        }

        public static Bounds2I ToBounds2I(Bounds2I bounds, int distance)
        {
            return new Bounds2I(bounds.MinX - distance, bounds.MinY - distance, bounds.MaxX + distance,
                bounds.MaxY + distance);
        }
    }
}