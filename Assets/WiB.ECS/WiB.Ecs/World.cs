using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Ecs
{
    public sealed class World
    {
        private const int Capacity = 1024;

        private readonly List<ISystem> _systems = new();
        private readonly Dictionary<Type, IStorage> _storages = new();

        private int _reserveEntities;
        private readonly Queue<int> _freeEntities = new();

        public World(int capacity = Capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(capacity, nameof (capacity));
            
            Reserve(capacity);
        }

        private void Reserve(int capacity)
        {
            for (var i = _reserveEntities; i != _reserveEntities + capacity; i++)
                _freeEntities.Enqueue(i);
            _reserveEntities += capacity;

            foreach (var storages in _storages.Values)
                storages.Reserve(capacity);
        }

        public void Start()
        {
            foreach (var system in _systems)
                system.Start(this);
        }

        public int CreateEntity()
        {
            if (_freeEntities.Count == 0)
                Reserve(_reserveEntities);

            var entity = _freeEntities.Dequeue();
            return entity;
        }

        public void DestroyEntity(int entity)
        {
            foreach (var pool in _storages.Values)
                pool.DeleteComponent(entity);
            _freeEntities.Enqueue(entity);
        }

        public Storage<T> BindComponent<T>() where T : unmanaged
        {
            if (_storages.ContainsKey(typeof(T)))
                throw new Exception($"Type: {nameof(T)} already exist.");

            var pool = new Storage<T>(_reserveEntities);
            _storages[typeof(T)] = pool;
            return pool;
        }

        public void AddSystem([NotNull] ISystem system)
        {
            ArgumentNullException.ThrowIfNull(system, nameof(system));
            
            if(_systems.Contains(system))
                throw new Exception($"System: {system.GetType().Name} already exist.");
            
            _systems.Add(system);
        }

        public void RemoveSystem([NotNull] ISystem system)
        {
            ArgumentNullException.ThrowIfNull(system, nameof(system));
            
            _systems.Remove(system);
        }

        public void Update()
        {
            foreach (var system in _systems)
                system.Update();
        }

        public Storage<T> GetStorage<T>() where T : unmanaged
        {
            if (!_storages.TryGetValue(typeof(T), out var storage))
                throw new Exception($"Storage with type: {nameof(T)} is not found.");

            return (Storage<T>)storage;
        }
    }
}