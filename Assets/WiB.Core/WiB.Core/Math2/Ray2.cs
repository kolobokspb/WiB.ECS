namespace WiB.Math2
{
    public struct Ray2
    {
        public readonly Vector2F Point;
        public readonly Vector2F Direction;

        public Ray2(Vector2F point, Vector2F direction)
        {
            Point = point;
            Direction = direction;
        }    
    }
}