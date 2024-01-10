using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WiB.Ecs.Filters
{
    public readonly struct Inc1Exc1
    {
        private readonly IStorage _storageInc0;
        private readonly IStorage _storageExc0;

        public Inc1Exc1([NotNull] IStorage storageInc0, [NotNull] IStorage storageExc0)
        {
            ArgumentNullException.ThrowIfNull(storageInc0, nameof(storageInc0));
            ArgumentNullException.ThrowIfNull(storageExc0, nameof(storageExc0));

            _storageInc0 = storageInc0;
            _storageExc0 = storageExc0;
        }

        public EnumeratorInc1Exc1 GetEnumerator()
        {
            return new EnumeratorInc1Exc1(_storageInc0.GetTable(), _storageExc0.GetTable());
        }
    }

    public struct EnumeratorInc1Exc1
    {
        private readonly Table _storageInc0;
        private readonly Table _storageExc0;

        private int _index;

        internal EnumeratorInc1Exc1(Table storageInc0, Table storageExc0)
        {
            _index = -1;
            Current = -1;

            _storageInc0 = storageInc0;
            _storageExc0 = storageExc0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++_index < _storageInc0.GetSize())
            {
                Current = _storageInc0.GetEntity(_index);

                if (!_storageExc0.HasComponent(Current))
                    return true;
            }

            return false;
        }

        public int Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            private set;
        }
    }
}