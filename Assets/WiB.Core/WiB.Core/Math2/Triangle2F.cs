namespace WiB.Math2
{
    readonly struct Triangle2F
    {
        public readonly Vector2F A;
        public readonly Vector2F B;
        public readonly Vector2F C;

        public Triangle2F(Vector2F a, Vector2F b, Vector2F c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static bool PointInTriangle(Triangle2F tr, Vector2F p)
        {
            var aX = tr.A.X;
            var aY = tr.A.Y;

            var bX = tr.B.X;
            var bY = tr.B.Y;

            var cX = tr.C.X;
            var cY = tr.C.Y;

            var area = 0.5f * (-bY * cX + aY * (-bX + cX) + aX * (bY - cY) + bX * cY);
            var s = 1 / (2 * area) * (aY * cX - aX * cY + (cY - aY) * p.X + (aX - cX) * p.Y);
            var t = 1 / (2 * area) * (aX * bY - aY * bX + (aY - bY) * p.X + (bX - aX) * p.Y);
            return s >= 0 && t >= 0 && s + t <= 1;
        }
    }
}