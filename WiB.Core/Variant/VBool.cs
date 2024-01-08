using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VBool : Var
    {
        private readonly bool _value;

        internal VBool(bool value) : base(VariantType.Bool)
        {
            _value = value;
        }

        public static implicit operator bool([NotNull] VBool value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._value;
        }
    }
}