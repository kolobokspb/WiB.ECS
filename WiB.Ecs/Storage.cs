using System.Runtime.CompilerServices;

namespace WiB.Ecs
{
    public interface IStorage
    {
        public void DeleteComponent(int entity);

        internal void Reserve(int capacity);

        internal Table GetTable();
    }

    public sealed class Storage<T> : IStorage where T : unmanaged
    {
        private Data<T> _data;
        private Table _table;
        private int _capacity;
        private int _size;

        internal Storage(int capacity)
        {
            _table = new Table(capacity);
            for (var i = 0; i != capacity; i++)
                _table[i] = new Element { Index = i, Entity = i };

            _data = new Data<T>(capacity);
            for (var i = 0; i != capacity; i++)
                _data[i] = default;

            _capacity = capacity;
        }

        void IStorage.Reserve(int capacity)
        {
            var newCapacity = _capacity + capacity;

            _table.Resize(newCapacity);
            for (var i = _capacity; i != newCapacity; i++)
                _table[i] = new Element { Index = i, Entity = i };

            _data.Resize(newCapacity);
            for (var i = _capacity; i != newCapacity; i++)
                _data[i] = default;

            _capacity = newCapacity;
        }

        Table IStorage.GetTable()
        {
            return _table;
        }

        public void SetComponent(int entity, ref T value)
        {
            var dataIndex = _table[entity].Index;

            if (dataIndex < _size)
                _data[dataIndex] = value;
            else
            {
                var newEntity = _table[_size].Entity;

                _table[entity].Index = _size;
                _table[newEntity].Index = dataIndex;

                _table[dataIndex].Entity = newEntity;
                _table[_size].Entity = entity;

                _data[_size] = value;

                ++_size;
                _table.SetSize(_size);
                _data.SetSize(_size);
            }
        }

        public void DeleteComponent(int entity)
        {
            var dataIndex = _table[entity].Index;

            if (dataIndex < _size)
            {
                var lastDataIndex = _size - 1;
                var lastEntity = _table[lastDataIndex].Entity;

                _table[entity].Index = lastDataIndex;
                _table[lastEntity].Index = dataIndex;

                _table[dataIndex].Entity = lastEntity;
                _table[lastDataIndex].Entity = entity;

                _data[dataIndex] = _data[lastDataIndex];
                _data[lastDataIndex] = default;

                --_size;
                _table.SetSize(_size);
                _data.SetSize(_size);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref readonly T GetComponent(int entity)
        {
            return ref _data[_table[entity].Index];
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasComponent(int entity)
        {
            return _table.HasComponent(entity);
        }
    }
}