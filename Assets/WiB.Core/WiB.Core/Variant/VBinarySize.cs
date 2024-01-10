using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    internal struct VBinarySize
    {
        private static int GetSizeList([NotNull] VList value)
        {
            var size = Memory.GetSizeInt32(value.Count);

            foreach (var i in value)
                size += GetSizeVariant(i);

            return size;
        }

        private static int GetSizeDictionary([NotNull] VDictionary value)
        {
            var size = Memory.GetSizeInt32(value.Count);

            foreach (var i in value)
            {
                size += Memory.GetSizeString(i.Key);
                size += GetSizeVariant(i.Value);
            }

            return size;
        }
        
        private static int GetSizeObject([NotNull] VObject value)
        {
            return Memory.GetSizeString(value) + GetSizeDictionary(value);
        }
        
        private static int GetSizeVariantType(VariantType value)
        {
            return sizeof(byte);
        }
        
        private static int GetSizeVariant([NotNull] Var variant)
        {
            return sizeof(byte) + variant.VariantType switch
            {
                VariantType.Null => 0,
                VariantType.Bool => Memory.GetSizeBool(variant),
                VariantType.Int32 => Memory.GetSizeInt32(variant),
                VariantType.Float => Memory.GetSizeFloat(variant),
                VariantType.String => Memory.GetSizeString(variant),
                VariantType.Bytes => Memory.GetSizeBytes(variant),
                VariantType.List => GetSizeList((VList)variant),
                VariantType.Dictionary => GetSizeDictionary((VDictionary)variant),
                VariantType.Object => GetSizeObject((VObject)variant),
                VariantType.Type => GetSizeVariantType(variant),
                _ => throw new NotSupportedException(nameof(variant.VariantType))
            };
        }

        public static int GetSize([NotNull] Var variant)
        {
            ArgumentNullException.ThrowIfNull(variant, nameof(variant));

            return GetSizeVariant(variant);
        }
    }
}