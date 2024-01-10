using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VList : Var, IList<Var>
    {
        private readonly List<Var> _list;

        internal VList() : base(VariantType.List)
        {
            _list = new List<Var>();
        }

        internal VList(int capacity) : base(VariantType.List)
        {
            _list = new List<Var>(capacity);
        }

        public List<Var>.Enumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator<Var> IEnumerable<Var>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }

        public void Add(Var item)
        {
            item ??= GetNull();
            ((ICollection<Var>)_list).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Var>)_list).Clear();
        }

        public bool Contains(Var item)
        {
            item ??= GetNull();
            return ((ICollection<Var>)_list).Contains(item);
        }

        public void CopyTo(Var[] array, int arrayIndex)
        {
            ((ICollection)_list).CopyTo(array, arrayIndex);
        }

        public bool Remove(Var item)
        {
            return ((ICollection<Var>)_list).Remove(item);
        }

        public int Count => _list.Count;

        bool ICollection<Var>.IsReadOnly => false;

        public int IndexOf(Var item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Var item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
    }
}