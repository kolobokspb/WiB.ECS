using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    public sealed class VBytes : Var
    {
        private readonly byte[] _bytes;

        internal VBytes([NotNull] byte[] bytes) : base(VariantType.Bytes)
        {
            ArgumentNullException.ThrowIfNull(bytes, nameof(bytes));

            _bytes = bytes;
        }

        public static implicit operator byte[]([NotNull] VBytes value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            return value._bytes;
        }
    }
}