using System.Collections.Generic;

namespace WiB.Math2
{
    class RayCast2
    {
        private const int Left = 0x1;
        private const int Top = 0x2;
        private const int Right = 0x4;
        private const int Bottom = 0x8;

        private static int Code(Vector2F point, Bounds2F bounds)
        {
            var res = 0;

            if (bounds.MinX - point.X > Math.FloatError)
                res |= Left;
            else if (point.X - bounds.MaxX > Math.FloatError)
                res |= Right;

            if (bounds.MinY - point.Y > Math.FloatError)
                res |= Top;
            else if (point.Y - bounds.MaxY > Math.FloatError)
                res |= Bottom;

            return res;
        }

        public static bool RayCast(Bounds2F bounds, Vector2F begin, Vector2F end, out Vector2F point,
            out Vector2F normal)
        {
            normal = Vector2F.Zero;
            point = begin;
            var out1 = Code(point, bounds);
            if (out1 == 0) //dot inside
                return false;
            var out2 = Code(end, bounds);
            while ((out1 = Code(point, bounds)) != 0)
            {
                if ((out1 & out2) != 0)
                    return false;
                if ((out1 & (Left | Right)) != 0)
                {
                    var x = bounds.MinX;
                    if ((out1 & Right) != 0)
                    {
                        normal = Vector2F.Right;
                        x += bounds.MaxX - bounds.MinX;
                    }
                    else
                        normal = Vector2F.Left;

                    point = new Vector2F(x, point.Y + (x - point.X) * (end.Y - point.Y) / (end.X - point.X));
                }
                else
                {
                    var y = bounds.MinY;
                    if ((out1 & Bottom) != 0)
                    {
                        normal = Vector2F.Top;
                        y += bounds.MaxY - bounds.MinY;
                    }
                    else
                        normal = Vector2F.Bottom;

                    point = new Vector2F(point.X + (y - point.Y) * (end.X - point.X) / (end.Y - point.Y), y);
                }
            }

            return true;
        }

        public static void RayCast(Vector2F begin, Vector2F end, List<Vector2I> list)
        {
            var absX = Math.Abs(end.X - begin.X);
            var absY = Math.Abs(end.Y - begin.Y);

            var floorBeginX = Math.Floor(begin.X);
            var floorBeginY = Math.Floor(begin.Y);
            var floorEndX = Math.Floor(end.X);
            var floorEndY = Math.Floor(end.Y);

            var beginX = Conversion.ToInt32(floorBeginX);
            var beginY = Conversion.ToInt32(floorBeginY);
            var endX = Conversion.ToInt32(floorEndX);
            var endY = Conversion.ToInt32(floorEndY);

            var x = beginX;
            var y = beginY;

            var n = 1;
            int stepX, stepY;

            float error;

            if (Math.CompareFloatToZero(absX))
            {
                stepX = 0;
                error = Math.FloatPositiveInfinity;
            }
            else if (end.X > begin.X)
            {
                stepX = 1;
                n += endX - beginX;
                error = (floorBeginX + 1.0f - begin.X) * absY;
            }
            else
            {
                stepX = -1;
                n += beginX - endX;
                error = (begin.X - floorBeginX) * absY;
            }

            if (Math.CompareFloatToZero(absY))
            {
                stepY = 0;
                error -= Math.FloatPositiveInfinity;
            }
            else if (end.Y > begin.Y)
            {
                stepY = 1;
                n += endY - beginY;
                error -= (floorBeginY + 1.0f - begin.Y) * absX;
            }
            else
            {
                stepY = -1;
                n += beginY - endY;
                error -= (begin.Y - floorBeginY) * absX;
            }

            for (; n > 0; --n)
            {
                list.Add(new Vector2I(x, y));

                if (error > 0)
                {
                    y += stepY;
                    error -= absX;
                }
                else
                {
                    x += stepX;
                    error += absY;
                }
            }
        }
    }
}