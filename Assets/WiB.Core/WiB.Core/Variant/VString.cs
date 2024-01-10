using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VString : Var
    {
        private readonly string _value;

        internal VString([NotNull] string value) : base(VariantType.String)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            _value = value;
        }

        public static implicit operator string([NotNull] VString value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._value;
        }
    }
}