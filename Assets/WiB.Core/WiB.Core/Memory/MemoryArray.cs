using System;

namespace WiB
{
    public static partial class Memory
    {
        public static int GetSizeOfPackedArray(byte[] array)
        {
            return sizeof(int) + array.Length;
        }

        public static int GetSizePackingMemoryPacking(MemoryStorage value)
        {
            return sizeof(int) + value.Size;
        }

        public static void Packing(byte[] buffer, int offsetBuffer, byte[] array, int offsetArray, int size)
        {
            PackInt32(buffer, ref offsetBuffer, size);
            Memcpy(buffer, offsetBuffer, array, offsetArray, size);
        }

        public static void Packing(byte[] buffer, ref int offsetBuffer, byte[] array, int offsetArray, int size)
        {
            PackInt32(buffer, ref offsetBuffer, size);
            Memcpy(buffer, offsetBuffer, array, offsetArray, size);
            offsetBuffer += size;
        }

        public static void Packing(byte[] buffer, ref int offsetBuffer, byte[] array, ref int offsetArray, int size)
        {
            PackInt32(buffer, ref offsetBuffer, size);
            Memcpy(buffer, offsetBuffer, array, offsetArray, size);
            offsetBuffer += size;
            offsetArray += size;
        }

        public static byte[] UnpackingArray(byte[] buffer, ref int offsetBuffer)
        {
            var size = UnpackInt32(buffer, ref offsetBuffer);
            if (size == 0)
                return Array.Empty<byte>();

            var array = new byte[size];
            Memcpy(array, 0, buffer, ref offsetBuffer, size);
            return array;
        }

        public static bool[] UnpackingBoolArray(byte[] data)
        {
            var offset = 0;
            var baseLen = UnpackInt32(data, ref offset);

            var bytesLen = baseLen / 8;

            if (baseLen % 8 != 0)
                bytesLen++;

            var result = new bool[baseLen];

            for (var i = 0; i != bytesLen; i++)
            {
                var value = UnpackByte(data, ref offset);

                for (var j = 0; j != 8; j++)
                {
                    var index = i * 8 + j;

                    if (index == baseLen)
                        break;

                    result[index] = Conversion.ToBool((value >> j) & 1);
                }
            }

            return result;
        }

        public static byte[] Packing(bool[] data)
        {
            var baseLen = data.Length;

            var bytesLen = baseLen / 8;

            if (baseLen % 8 != 0)
                bytesLen++;

            var result = new byte[bytesLen + sizeof(int)];
            var offset = 0;
            PackInt32(result, ref offset, baseLen);

            for (var i = 0; i != bytesLen; i++)
            {
                var value = 0;
                for (var j = 0; j != 8; j++)
                {
                    var index = i * 8 + j;

                    if (index == baseLen)
                        break;

                    if (data[index])
                        value += 1 << j;
                }

                PackInt32(result, ref offset, (byte)value);
            }

            return result;
        }
    }
}