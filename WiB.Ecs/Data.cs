using System;

namespace WiB.Ecs
{
    internal struct Data<T> where T : unmanaged
    {
        private T[] _array;
        private int _size;

        public Data(int capacity)
        {
            _array = null!;
            _size = 0;
            Array.Resize(ref _array, capacity);
        }

        public int GetSize()
        {
            return _size;
        }

        public void SetSize(int size)
        {
            _size = size;
        }

        public ref T this[int index] => ref _array[index];

        public void Resize(int capacity)
        {
            Array.Resize(ref _array, capacity);
        }
    }
}