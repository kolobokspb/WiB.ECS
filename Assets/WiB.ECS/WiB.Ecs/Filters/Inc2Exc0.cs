using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WiB.Ecs.Filters
{
    public readonly struct Inc2Exc0
    {
        private readonly IStorage _storageInc0;
        private readonly IStorage _storageInc1;

        public Inc2Exc0([NotNull] IStorage storageInc0, [NotNull] IStorage storageInc1)
        {
            ArgumentNullException.ThrowIfNull(storageInc0, nameof(storageInc0));
            ArgumentNullException.ThrowIfNull(storageInc1, nameof(storageInc1));

            _storageInc0 = storageInc0;
            _storageInc1 = storageInc1;
        }

        public EnumeratorInc2Exc0 GetEnumerator()
        {
            return new EnumeratorInc2Exc0(_storageInc0.GetTable(), _storageInc1.GetTable());
        }
    }

    public struct EnumeratorInc2Exc0
    {
        private readonly Table _storageInc0;
        private readonly Table _storageInc1;

        private int _index;

        internal EnumeratorInc2Exc0(Table storageInc0, Table storageInc1)
        {
            _index = -1;
            Current = -1;

            _storageInc0 = storageInc0;
            _storageInc1 = storageInc1;

            Table.Sort(ref _storageInc0, ref _storageInc1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            while (++_index < _storageInc0.GetSize())
            {
                Current = _storageInc0.GetEntity(_index);

                if (_storageInc1.HasComponent(Current))
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