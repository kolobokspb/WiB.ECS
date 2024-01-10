using System;
using System.Diagnostics.CodeAnalysis;

namespace WiB.Variant
{
    internal struct VBinaryUnpacker
    {
        private byte[] _buffer;
        private int _offset;

        public static Var ToVariant([NotNull] byte[] sources, int sourcesOffset)
        {
            ArgumentNullException.ThrowIfNull(sources, nameof(sources));
            
            return new VBinaryUnpacker().UnpackVariant(sources, sourcesOffset);
        }

        private Var UnpackVariant([NotNull] byte[] sources, int sourcesOffset)
        {
            _buffer = sources;
            _offset = sourcesOffset;
            return UnpackVariant();
        }

        private Var UnpackVariant()
        {
            var variantType = (VariantType)Memory.UnpackByte(_buffer, ref _offset);

            switch (variantType)
            {
                case VariantType.Null: return Var.GetNull();
                case VariantType.Bool: return Memory.UnpackBool(_buffer, ref _offset);
                case VariantType.Int32: return Memory.UnpackInt32(_buffer, ref _offset);
                case VariantType.Float: return Memory.UnpackFloat(_buffer, ref _offset);
                case VariantType.String: return Memory.UnpackString(_buffer, ref _offset);
                case VariantType.Bytes: return Memory.UnpackBytes(_buffer, ref _offset);
                case VariantType.List:
                {
                    var count = Memory.UnpackInt32(_buffer, ref _offset);
                    var vList = Var.GetList(count);

                    for (var i = 0; i != count; i++)
                        vList.Add(UnpackVariant());

                    return vList;
                }
                case VariantType.Dictionary:
                {
                    var count = Memory.UnpackInt32(_buffer, ref _offset);

                    var vDictionary = Var.GetDictionary(count);

                    for (var i = 0; i != count; i++)
                    {
                        var key = Memory.UnpackString(_buffer, ref _offset);
                        var value = UnpackVariant();
                        vDictionary.Add(key, value);
                    }

                    return vDictionary;
                }
                case VariantType.Object:
                {
                    var type = Memory.UnpackString(_buffer, ref _offset);
                    var count = Memory.UnpackInt32(_buffer, ref _offset);

                    var vObject = Var.GetObject(type, count);

                    for (var i = 0; i != count; i++)
                    {
                        var key = Memory.UnpackString(_buffer, ref _offset);
                        var value = UnpackVariant();
                        vObject.Add(key, value);
                    }

                    return vObject;
                }
                case VariantType.Type:
                {
                    return (VariantType)Memory.UnpackByte(_buffer, ref _offset);
                }
                default:
                    throw new NotSupportedException(nameof(variantType));
            }
        }
    }
}