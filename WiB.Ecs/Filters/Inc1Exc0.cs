using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WiB.Ecs.Filters
{
    public readonly struct Inc1Exc0
    {
        private readonly IStorage _storageInc0;
     
        public Inc1Exc0([NotNull]IStorage storageInc0)
        {
            ArgumentNullException.ThrowIfNull(storageInc0, nameof(storageInc0));
            
            _storageInc0 = storageInc0;
        }

        public EnumeratorInc1Exc0 GetEnumerator()
        {
            return new EnumeratorInc1Exc0(_storageInc0.GetTable());
        }
    }
    
    public struct EnumeratorInc1Exc0
    {
        private readonly Table _storageInc0;
        private int _index;

        internal EnumeratorInc1Exc0(Table storageInc0)
        {
            _storageInc0 = storageInc0;
            _index = -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            return ++_index < _storageInc0.GetSize();
        }

        public int Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _storageInc0.GetEntity(_index);
        }
    }
}