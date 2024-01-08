using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace WiB
{
    public static partial class Memory
    {
        public static bool Memcmp(byte[] value1, byte[] value2)
        {
            if (value1 == null && value2 == null)
                return true;
            if (value1 == null || value2 == null)
                return false;
            if (value1.Length != value2.Length)
                return false;

            for (var i = 0; i != value1.Length; ++i)
                if (value1[i] != value2[i])
                    return false;

            return true;
        }

        public static bool Memcmp(byte[] value1, int offsetValue1, byte[] value2, int offsetValue2, int size)
        {
            if (value1 == null && value2 == null)
                return true;

            if (value1 == null || value2 == null)
                return false;

            for (var i = 0; i != size; ++i)
                if (value1[i + offsetValue1] != value2[i + offsetValue2])
                    return false;

            return true;
        }

        public static bool Memcmp(byte[] value1, ref int offsetValue1, byte[] value2, ref int offsetValue2, int size)
        {
            if (value1 == null && value2 == null)
                return true;

            if (value1 == null || value2 == null)
                return false;

            for (var i = 0; i != size; ++i)
                if (value1[i + offsetValue1] != value2[i + offsetValue2])
                    return false;

            offsetValue1 += size;
            offsetValue2 += size;
            return true;
        }

        public static bool Memcmp(bool[] bufferDec, int offsetDst, bool[] bufferScr, int offsetSrc, int count)
        {
            if (bufferDec == null && bufferScr == null)
                return true;

            if (bufferDec == null || bufferScr == null)
                return false;

            for (var i = 0; i != count; ++i)
                if (bufferDec[i + offsetDst] != bufferScr[i + offsetSrc])
                    return false;

            return true;
        }

        public static int Memcpy(Array bufferDst, int offsetDst, Array bufferScr, int offsetSrc, int size)
        {
            Array.Copy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            //Buffer.BlockCopy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            return size;
        }

        public static void Memcpy(Array bufferDst, ref int offsetDst, Array bufferScr, int offsetSrc, int size)
        {
            Array.Copy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            //Buffer.BlockCopy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            offsetDst += size;
        }

        public static void Memcpy(Array bufferDst, int offsetDst, Array bufferScr, ref int offsetSrc, int size)
        {
            Buffer.BlockCopy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            offsetSrc += size;
        }

        public static void Memcpy(Array bufferDst, ref int offsetDst, Array bufferScr, ref int offsetSrc, int size)
        {
            Buffer.BlockCopy(bufferScr, offsetSrc, bufferDst, offsetDst, size);
            offsetDst += size;
            offsetSrc += size;
        }

        public static void Clear(byte[] bufferDst)
        {
            for (var i = 0; i != bufferDst.Length; ++i)
                bufferDst[i] = 0;
        }

        public static int Packing<T>(Span<byte> buffer, T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[0]) = value;
            return Unsafe.SizeOf<T>();
        }

        /*
        public static void Packing<T>(Span<byte> buffer, T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[0]) = value;
        }
        */
        public static void Packing<T>(byte[] buffer, int offset, T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[offset]) = value;
        }

        public static void Packing<T>(byte[] buffer, int offset, ref T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[offset]) = value;
        }

        /*
        public static void Packing<T>(byte[] buffer, ref int offset, T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[offset]) = value;
            offset += Unsafe.SizeOf<T>();
        }
        */


        public static void Packing<T>(byte[] buffer, ref int offset, ref T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref buffer[offset]) = value;
            offset += Unsafe.SizeOf<T>();
        }

        /*
        public static ref T Unpacking<T>(ReadOnlySpan<byte> sources) where T : unmanaged
        {
            return ref Unsafe.As<byte, T>(ref sources.Data());
        }
        */

        public static Span<TTo> ToSpan<TFrom, TTo>(ref TFrom value)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            return new Span<TTo>(ref Unsafe.As<TFrom, TTo>(ref value));
        }

        /*
        public static ReadOnlySpan<TTo> ToReadonlySpan<TFrom, TTo>(ref TFrom value)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            return new ReadOnlySpan<TTo>(ref Unsafe.As<TFrom, TTo>(ref value));
        }

        public static ReadOnlyMemory<TTo> ToReadonlyMemory<TFrom, TTo>(ref TFrom value)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            return new ReadOnlyMemory<TTo>(ref Unsafe.As<TFrom, TTo>(ref value));
        }
        */

        public static int Unpacking<T>(ReadOnlySpan<byte> source, out T value) where T : unmanaged
        {
            value = Unsafe.As<byte, T>(ref MemoryMarshal.GetReference(source));
            return Unsafe.SizeOf<T>();
            //value = MemoryMarshal.AsRef<T>(source);
            //value = MemoryMarshal.Read<T>(source);

            /*
            var reference = sources.GetPinnableReference();
            value = Unsafe.Read<T>(reference);
            value = Unsafe.As<byte, T>(ref reference);

            //


            value =  Unsafe.As<byte, T>(ref MemoryMarshal.GetReference(source));*/
        }

        public static int Packing<T>(Span<byte> destination, ref T value) where T : unmanaged
        {
            Unsafe.As<byte, T>(ref MemoryMarshal.GetReference(destination)) = value;
            return Unsafe.SizeOf<T>();

            //MemoryMarshal.AsRef<T>(destination) = value;
            //MemoryMarshal.Write(destination, ref value);
            //return Unsafe.SizeOf<T>();
            //return ref Unsafe.As<TSources, TDestination>(ref sources);  
            /*
            var reference = sources.GetPinnableReference();
            value = Unsafe.Read<T>(reference);
            value = Unsafe.As<byte, T>(ref reference);

            //value = Unsafe.AsRef<T>(ref reference);
            */
        }


        /*
        public static ref T Unpacking<T>(byte[] buffer, int offset) where T : unmanaged
        {
            return ref Unsafe.As<byte, T>(ref buffer[offset]);
        }

        public static ref T Unpack<T>(byte[] buffer, ref int offset) where T : unmanaged
        {
            var o = offset;
            offset += Unsafe.SizeOf<T>();
            return ref Unsafe.As<byte, T>(ref buffer[o]);
        }
        */

        //public static
        public static void PackByte(byte[] destination, ref int destinationOffset, byte value)
        {
            destination[destinationOffset] = value;
            destinationOffset += sizeof(byte);
        }

        public static void PackBool(byte[] destination, ref int destinationOffset, bool value)
        {
            destination[destinationOffset] = Conversion.ToByte(value);
            destinationOffset += sizeof(byte);
        }

        public static void PackInt32(byte[] destination, ref int destinationOffset, int value)
        {
            uint num;
            for (num = (uint)value; num > (uint)sbyte.MaxValue; num >>= 7)
                destination[destinationOffset++] = (byte)(num | 4294967168U);

            destination[destinationOffset++] = (byte)num;

            /*
            Unsafe.As<byte, int>(ref destination[destinationOffset]) = value;
            destinationOffset += sizeof(int);
            */
        }

        public static void PackFloat(byte[] destination, ref int destinationOffset, float value)
        {
            Unsafe.As<byte, float>(ref destination[destinationOffset]) = value;
            destinationOffset += sizeof(float);
        }

        public static void PackString(byte[] destination, ref int destinationOffset, string sources)
        {
            var span = MemoryMarshal.Cast<char, byte>(sources.AsSpan());

            var simple = true;
            for(var i = 1; i < span.Length; i += 2)
                if (span[i] != 0)
                {
                    simple = false;
                    break;
                }

            var length = simple ? sources.Length : span.Length;
            PackInt32(destination, ref destinationOffset, length);
            
            PackBool(destination, ref destinationOffset, simple);
            
            if(!simple)
                span.CopyTo(destination.AsSpan(destinationOffset));
            else
                for(var i = 0; i < span.Length; i += 2)
                    PackByte(destination, ref destinationOffset, span[i]);
        }

        public static void PackBytes(byte[] destination, ref int destinationOffset, byte[] sources)
        {
            var length = sources.Length * sizeof(byte);

            PackInt32(destination, ref destinationOffset, length);

            var span = sources.AsSpan();
            span.CopyTo(destination.AsSpan(destinationOffset));

            destinationOffset += length;
        }


        public static byte UnpackByte(byte[] sources, ref int sourcesOffset)
        {
            var value = sources[sourcesOffset];
            sourcesOffset += sizeof(byte);
            return value;
        }

        public static bool UnpackBool(byte[] sources, ref int sourcesOffset)
        {
            var value = Conversion.ToBool(sources[sourcesOffset]);
            sourcesOffset += sizeof(byte);
            return value;
        }
        
        public static int GetSizeBool(bool value)
        {
            return sizeof(byte);
        }
        public static int GetSizeInt32(int value)
        {
            var bytes = 1;
            for (var num = (uint)value; num > (uint)sbyte.MaxValue; num >>= 7)
                bytes++;
            return bytes;        
        }
        public static int GetSizeFloat(float value)
        {
            return sizeof(float);
        }
        public static int GetSizeString([NotNull] string value)
        {
            var span = MemoryMarshal.Cast<char, byte>(value.AsSpan());

            var simple = true;
            for(var i = 1; i < span.Length; i += 2)
                if (span[i] != 0)
                {
                    simple = false;
                    break;
                }

            var length = simple ? value.Length : span.Length;
            
            return GetSizeInt32(length) + GetSizeBool(simple) + length;
        }

        public static int GetSizeBytes([NotNull] byte[] value)
        {
            return GetSizeInt32(value.Length) + value.Length * sizeof(byte);
        }
        
        public static int UnpackInt32(byte[] sources, int sourcesOffset)
        {
            return Unsafe.As<byte, int>(ref sources[sourcesOffset]);
        }

        public static int UnpackInt32(byte[] sources, ref int sourcesOffset)
        {
            uint num1 = 0;
            for (var index = 0; index < 28; index += 7)
            {
                var num2 = sources[sourcesOffset++];
                num1 |= (uint)((num2 & sbyte.MaxValue) << index);
                if (num2 <= 127)
                    return (int)num1;
            }

            var num3 = sources[sourcesOffset++];
            //if (num3 > (byte) 15)
            //    throw new FormatException(SR.Format_Bad7BitInt);
            return (int)(num1 | (uint)num3 << 28);


            /*
            var value = Unsafe.As<byte, int>(ref sources[sourcesOffset]);
            sourcesOffset += sizeof(int);
            return value;
            */
        }

        public static uint UnpackUInt32(byte[] sources, ref int sourcesOffset)
        {
            var value = Unsafe.As<byte, uint>(ref sources[sourcesOffset]);
            sourcesOffset += sizeof(uint);
            return value;
        }

        public static float UnpackFloat(byte[] sources, ref int sourcesOffset)
        {
            var value = Unsafe.As<byte, float>(ref sources[sourcesOffset]);
            sourcesOffset += sizeof(float);
            return value;
        }

        public static string UnpackString(byte[] sources, ref int sourcesOffset)
        {
            var length = UnpackInt32(sources, ref sourcesOffset);
            var simple = UnpackBool(sources, ref sourcesOffset);

            var span = simple
                ? length <= 512 ? stackalloc byte[length * 2] : new byte[length * 2]
                : sources.AsSpan(sourcesOffset, length);
            
            if(simple) 
                for (var i = 0; i < span.Length; i += 2) 
                    span[i] = UnpackByte(sources, ref sourcesOffset);
            else
                sourcesOffset += length;

            return new string(MemoryMarshal.Cast<byte, char>(span));
        }

        public static byte[] UnpackBytes(byte[] sources, ref int sourcesOffset)
        {
            var length = UnpackInt32(sources, ref sourcesOffset);

            var result = sources.AsSpan(sourcesOffset, length).ToArray();

            sourcesOffset += length;

            return result;
        }


        public static int SizeOf<T>()
        {
            return Unsafe.SizeOf<T>();
        }

        public static ref TDestination Packing<TDestination, TSources>(ref TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return ref Unsafe.As<TSources, TDestination>(ref sources);
        }

        public static TDestination Packing<TDestination, TSources>(TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return Unsafe.As<TSources, TDestination>(ref sources);
        }

        public static ref TDestination Unpacking<TSources, TDestination>(ref TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return ref Unsafe.As<TSources, TDestination>(ref sources);
        }

        public static TDestination Unpacking<TSources, TDestination>(TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return Unsafe.As<TSources, TDestination>(ref sources);
        }

        public static TDestination As<TSources, TDestination>(TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return Unsafe.As<TSources, TDestination>(ref sources);
        }

        public static TDestination As<TSources, TDestination>(ref TSources sources)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            return Unsafe.As<TSources, TDestination>(ref sources);
        }
        /*
        public static void Unpacking<TSources, TDestination>(ref TSources sources, out TDestination destination)
            where TDestination : unmanaged
            where TSources : unmanaged
        {
            destination = Unsafe.As<TSources, TDestination>(ref sources);
        }
        */
    }
}