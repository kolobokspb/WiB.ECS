namespace WiB.Math2
{
    public readonly struct Segment2F
    {
        public readonly Vector2F Point1;
        public readonly Vector2F Point2;

        public Segment2F(Vector2F point1, Vector2F point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public static bool Intersect(Segment2F a, Segment2F b)
        {
            var a1X = a.Point1.X;
            var a1Y = a.Point1.Y;

            var a2X = a.Point2.X;
            var a2Y = a.Point2.Y;

            var b1X = b.Point1.X;
            var b1Y = b.Point1.Y;

            var b2X = b.Point2.X;
            var b2Y = b.Point2.Y;

            var denominator = (a2X - a1X) * (b2Y - b1Y) - (a2Y - a1Y) * (b2X - b1X);

            if (Math.CompareFloat(denominator, 0.0f))
                return false;

            var numerator1 = (a1Y - b1Y) * (b2X - b1X) - (a1X - b1X) * (b2Y - b1Y);
            var numerator2 = (a1Y - b1Y) * (a2X - a1X) - (a1X - b1X) * (a2Y - a1Y);

            if (Math.CompareFloat(numerator1, 0.0f) || Math.CompareFloat(numerator2, 0.0f))
                return false;

            var r = numerator1 / denominator;
            var s = numerator2 / denominator;

            return r > 0 && r < 1 && s > 0 && s < 1;
        }
    }
}