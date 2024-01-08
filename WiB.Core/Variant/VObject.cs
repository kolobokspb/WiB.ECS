using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VObject : VDictionary
    {
        private readonly string _type;

        internal VObject([NotNull] string type) : base(VariantType.Object)
        {
            ArgumentNullException.ThrowIfNull(type, nameof(type));

            _type = type;
        }

        internal VObject([NotNull] string type, int capacity) : base(VariantType.Object, capacity)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(type, nameof(type));

            _type = type;
        }

        public static implicit operator string([NotNull] VObject value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._type;
        }
    }
}