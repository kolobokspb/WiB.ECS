using System;

namespace WiB.Ecs
{
    internal struct Element
    {
        public int Index;
        public int Entity;
    }

    internal struct Table
    {
        private Element[] _array;
        private int _size;

        public Table(int capacity)
        {
            _array = null!;
            _size = 0;
            Resize(capacity);
        }

        public readonly int GetSize()
        {
            return _size;
        }

        public void SetSize(int size)
        {
            _size = size;
        }

        public readonly bool HasComponent(int entity)
        {
            return _array[entity].Index < _size;
        }

        public readonly int GetEntity(int index)
        {
            return _array[index].Entity;
        }

        public ref Element this[int index] => ref _array[index];

        public void Resize(int capacity)
        {
            Array.Resize(ref _array, capacity);
        }

        internal static void Sort(ref Table left, ref Table right)
        {
            if (left.GetSize() < right.GetSize())
                return;
            (left, right) = (right, left);
        }
    }
}