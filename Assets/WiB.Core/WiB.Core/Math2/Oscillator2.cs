namespace WiB.Math2
{
    public class Oscillator2
    {
        private readonly Vector2F _point1;
        private readonly Vector2F _point2;

        private Vector2F _begin;
        private Vector2F _end;

        public Vector2F Direction { get; private set; }
        private float _length;

        public Oscillator2(Vector2F point1, Vector2F point2)
        {
            _point1 = point1;
            _point2 = point2;

            _begin = point1;
            _end = point2;

            Direction = Vector2F.Normalize(_end - _begin);
            _length = (_end - _begin).Length;
        }

        public void Update(Vector2F position)
        {
            var len = (_begin - position).Length;

            if (!(len >= _length))
                return;

            if ((_point1 - position).Length > (_point2 - position).Length)
            {
                _begin = _point2;
                _end = _point1;
            }
            else
            {
                _begin = _point1;
                _end = _point2;
            }

            Direction = Vector2F.Normalize(_end - _begin);
            _length = (_end - _begin).Length;
        }
    }
}