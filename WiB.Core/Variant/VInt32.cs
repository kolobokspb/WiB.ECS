using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VInt32 : Var
    {
        private readonly int _value;

        internal VInt32(int value) : base(VariantType.Int32)
        {
            _value = value;
        }

        public static implicit operator int([NotNull] VInt32 value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._value;
        }
    }
}