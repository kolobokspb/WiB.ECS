using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    internal struct VBinaryPacker
    {
        private byte[] _buffer;
        private int _offset;

        public static void ToBytes([NotNull] byte[] destination, int destinationOffset, [NotNull] Var sources)
        {
            ArgumentNullException.ThrowIfNull(destination, nameof(destination));
            ArgumentNullException.ThrowIfNull(sources, nameof(sources));

            new VBinaryPacker().PackVariant(destination, destinationOffset, sources);
        }

        private void PackVariant([NotNull] byte[] destination, int destinationOffset, Var sources)
        {
            _buffer = destination;
            _offset = destinationOffset;
            PackVariant(sources);
        }

        private void PackVariant([NotNull] Var variant)
        {
            Memory.PackByte(_buffer, ref _offset, (byte)variant.VariantType);

            switch (variant.VariantType)
            {
                case VariantType.Null: break;
                case VariantType.Bool:
                    Memory.PackBool(_buffer, ref _offset, variant);
                    break;
                case VariantType.Int32:
                    Memory.PackInt32(_buffer, ref _offset, variant);
                    break;
                case VariantType.Float:
                    Memory.PackFloat(_buffer, ref _offset, variant);
                    break;
                case VariantType.String:
                    Memory.PackString(_buffer, ref _offset, variant);
                    break;
                case VariantType.Bytes:
                    Memory.PackBytes(_buffer, ref _offset, variant);
                    break;
                case VariantType.List:
                {
                    var list = (VList)variant;

                    Memory.PackInt32(_buffer, ref _offset, list.Count);

                    foreach (var i in list)
                        PackVariant(i);
                }
                    break;
                case VariantType.Dictionary:
                {
                    var dictionary = (VDictionary)variant;

                    Memory.PackInt32(_buffer, ref _offset, dictionary.Count);

                    foreach (var i in dictionary)
                    {
                        Memory.PackString(_buffer, ref _offset, i.Key);
                        PackVariant(i.Value);
                    }
                }
                    break;
                case VariantType.Object:
                {
                    Memory.PackString(_buffer, ref _offset, (VObject)variant);
                    goto case VariantType.Dictionary;
                }
                case VariantType.Type:
                {
                    Memory.PackByte(_buffer, ref _offset, (byte)(VariantType)variant);
                }
                    break;
                default:
                    throw new NotSupportedException(nameof(variant.VariantType));
            }
        }
    }
}