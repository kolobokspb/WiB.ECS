using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public class VDictionary : Var, IDictionary<string, Var>
    {
        private readonly Dictionary<string, Var> _dictionary;

        internal VDictionary(VariantType type) : base(type)
        {
            _dictionary = new Dictionary<string, Var>();
        }

        internal VDictionary(VariantType type, int capacity) : base(type)
        {
            _dictionary = new Dictionary<string, Var>(capacity);
        }

        internal VDictionary(int capacity) : this(VariantType.Dictionary, capacity)
        {
        }

        internal VDictionary() : this(VariantType.Dictionary)
        {
        }

        public Dictionary<string, Var>.Enumerator GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, Var>> IEnumerable<KeyValuePair<string, Var>>.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary).GetEnumerator();
        }

        void ICollection<KeyValuePair<string, Var>>.Add(KeyValuePair<string, Var> item)
        {
            ((ICollection<KeyValuePair<string, Var>>)_dictionary).Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        bool ICollection<KeyValuePair<string, Var>>.Contains(KeyValuePair<string, Var> item)
        {
            return ((ICollection<KeyValuePair<string, Var>>)_dictionary).Contains(item);
        }

        void ICollection<KeyValuePair<string, Var>>.CopyTo(KeyValuePair<string, Var>[] array, int arrayIndex)
        {
            ((ICollection)_dictionary).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, Var>>.Remove(KeyValuePair<string, Var> item)
        {
            return ((ICollection<KeyValuePair<string, Var>>)_dictionary).Remove(item);
        }

        public int Count => _dictionary.Count;

        bool ICollection<KeyValuePair<string, Var>>.IsReadOnly => false;

        public void Add(string key, Var value)
        {
            value ??= GetNull();
            _dictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out Var value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<Var> Values => _dictionary.Values;
    }
}