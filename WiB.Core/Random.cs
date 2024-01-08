namespace WiB
{
    public class Random
    {
        private static int _id = 1;

        private readonly System.Random _random = new(++_id);

        public int Next()
        {
            return _random.Next();
        }

        /*
        private static readonly System.Random mRandom = new(0);
        public static int GetRandom()
        {
            return mRandom.Next();
        }
        */
    }
}