using System;
using WiB.Variant;


namespace WiB.Variant
{
    public enum VariantType
    {
        Null,
        Bool,
        Int32,
        Float,
        String,
        Bytes,
        List,
        Dictionary,
        Object,
        Type
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static VariantType ToVariantType(ReadOnlySpan<char> source)
        {
            if (!IsVariantType(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static bool IsVariantType(ReadOnlySpan<char> source, out VariantType destination)
        {
            return Enum.TryParse(source, out destination);
        }

        public static string ToString(VariantType source)
        {
            return source.ToString();
        }
    }
}