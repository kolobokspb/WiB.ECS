using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VType : Var
    {
        private readonly VariantType _value;

        internal VType(VariantType value) : base(VariantType.Type)
        {
            _value = value;
        }

        public static implicit operator VariantType([NotNull] VType value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._value;
        }
    }
}