using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VFloat : Var
    {
        private readonly float _value;

        internal VFloat(float value) : base(VariantType.Float)
        {
            _value = value;
        }

        public static implicit operator float([NotNull] VFloat value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._value;
        }
    }
}