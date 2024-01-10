using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace WiB
{
    [Serializable]
    public readonly struct GuidEx : IEquatable<GuidEx>
    {
        public static GuidEx Empty = new();

#if UNITY_2019_1_OR_NEWER
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _03;
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _47;
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _8b;
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _cf;
#else
        private readonly uint _03;
        private readonly uint _47;
        private readonly uint _8b;
        private readonly uint _cf;
#endif
        public GuidEx(ReadOnlySpan<char> sources)
        {
            if (!Conversion.IsGuidEx(sources))
                throw new Exception("Guid must be 32 characters long and only contain a-f, 0-9 character.");

            var byte0 = (Conversion.HexToValue(sources[00]) << 4) | Conversion.HexToValue(sources[01]);
            var byte1 = (Conversion.HexToValue(sources[02]) << 4) | Conversion.HexToValue(sources[03]);
            var byte2 = (Conversion.HexToValue(sources[04]) << 4) | Conversion.HexToValue(sources[05]);
            var byte3 = (Conversion.HexToValue(sources[06]) << 4) | Conversion.HexToValue(sources[07]);
            var byte4 = (Conversion.HexToValue(sources[08]) << 4) | Conversion.HexToValue(sources[09]);
            var byte5 = (Conversion.HexToValue(sources[10]) << 4) | Conversion.HexToValue(sources[11]);
            var byte6 = (Conversion.HexToValue(sources[12]) << 4) | Conversion.HexToValue(sources[13]);
            var byte7 = (Conversion.HexToValue(sources[14]) << 4) | Conversion.HexToValue(sources[15]);
            var byte8 = (Conversion.HexToValue(sources[16]) << 4) | Conversion.HexToValue(sources[17]);
            var byte9 = (Conversion.HexToValue(sources[18]) << 4) | Conversion.HexToValue(sources[19]);
            var byteA = (Conversion.HexToValue(sources[20]) << 4) | Conversion.HexToValue(sources[21]);
            var byteB = (Conversion.HexToValue(sources[22]) << 4) | Conversion.HexToValue(sources[23]);
            var byteC = (Conversion.HexToValue(sources[24]) << 4) | Conversion.HexToValue(sources[25]);
            var byteD = (Conversion.HexToValue(sources[26]) << 4) | Conversion.HexToValue(sources[27]);
            var byteE = (Conversion.HexToValue(sources[28]) << 4) | Conversion.HexToValue(sources[29]);
            var byteF = (Conversion.HexToValue(sources[30]) << 4) | Conversion.HexToValue(sources[31]);

            _03 = (byte0 << 24) | (byte1 << 16) | (byte2 << 8) | (byte3 << 0);
            _47 = (byte4 << 24) | (byte5 << 16) | (byte6 << 8) | (byte7 << 0);
            _8b = (byte8 << 24) | (byte9 << 16) | (byteA << 8) | (byteB << 0);
            _cf = (byteC << 24) | (byteD << 16) | (byteE << 8) | (byteF << 0);
        }

        public static bool operator ==(GuidEx l, GuidEx r)
        {
            if (l._03 != r._03)
                return false;
            if (l._47 != r._47)
                return false;
            if (l._8b != r._8b)
                return false;
            if (l._cf != r._cf)
                return false;

            return true;
        }

        public static bool operator !=(GuidEx l, GuidEx r)
        {
            return !(l == r);
        }

        public bool Equals(GuidEx other)
        {
            return this == other;
        }

        public override string ToString()
        {
            Span<char> buffer = stackalloc char[32];

            buffer[00] = Conversion.ValueToHex(((_03 >> 24) & 0xff) >> 4);
            buffer[01] = Conversion.ValueToHex(((_03 >> 24) & 0xff) & 0x0f);
            buffer[02] = Conversion.ValueToHex(((_03 >> 16) & 0xff) >> 4);
            buffer[03] = Conversion.ValueToHex(((_03 >> 16) & 0xff) & 0x0f);
            buffer[04] = Conversion.ValueToHex(((_03 >> 08) & 0xff) >> 4);
            buffer[05] = Conversion.ValueToHex(((_03 >> 08) & 0xff) & 0x0f);
            buffer[06] = Conversion.ValueToHex(((_03 >> 00) & 0xff) >> 4);
            buffer[07] = Conversion.ValueToHex(((_03 >> 00) & 0xff) & 0x0f);

            buffer[08] = Conversion.ValueToHex(((_47 >> 24) & 0xff) >> 4);
            buffer[09] = Conversion.ValueToHex(((_47 >> 24) & 0xff) & 0x0f);
            buffer[10] = Conversion.ValueToHex(((_47 >> 16) & 0xff) >> 4);
            buffer[11] = Conversion.ValueToHex(((_47 >> 16) & 0xff) & 0x0f);
            buffer[12] = Conversion.ValueToHex(((_47 >> 08) & 0xff) >> 4);
            buffer[13] = Conversion.ValueToHex(((_47 >> 08) & 0xff) & 0x0f);
            buffer[14] = Conversion.ValueToHex(((_47 >> 00) & 0xff) >> 4);
            buffer[15] = Conversion.ValueToHex(((_47 >> 00) & 0xff) & 0x0f);

            buffer[16] = Conversion.ValueToHex(((_8b >> 24) & 0xff) >> 4);
            buffer[17] = Conversion.ValueToHex(((_8b >> 24) & 0xff) & 0x0f);
            buffer[18] = Conversion.ValueToHex(((_8b >> 16) & 0xff) >> 4);
            buffer[19] = Conversion.ValueToHex(((_8b >> 16) & 0xff) & 0x0f);
            buffer[20] = Conversion.ValueToHex(((_8b >> 08) & 0xff) >> 4);
            buffer[21] = Conversion.ValueToHex(((_8b >> 08) & 0xff) & 0x0f);
            buffer[22] = Conversion.ValueToHex(((_8b >> 00) & 0xff) >> 4);
            buffer[23] = Conversion.ValueToHex(((_8b >> 00) & 0xff) & 0x0f);

            buffer[24] = Conversion.ValueToHex(((_cf >> 24) & 0xff) >> 4);
            buffer[25] = Conversion.ValueToHex(((_cf >> 24) & 0xff) & 0x0f);
            buffer[26] = Conversion.ValueToHex(((_cf >> 16) & 0xff) >> 4);
            buffer[27] = Conversion.ValueToHex(((_cf >> 16) & 0xff) & 0x0f);
            buffer[28] = Conversion.ValueToHex(((_cf >> 08) & 0xff) >> 4);
            buffer[29] = Conversion.ValueToHex(((_cf >> 08) & 0xff) & 0x0f);
            buffer[30] = Conversion.ValueToHex(((_cf >> 00) & 0xff) >> 4);
            buffer[31] = Conversion.ValueToHex(((_cf >> 00) & 0xff) & 0x0f);

            return new string(buffer);
        }

        public override int GetHashCode()
        {
            return _03.GetHashCode() + _47.GetHashCode() + _8b.GetHashCode() + _cf.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is not GuidEx guidEx)
                return false;

            return this == guidEx;
        }

        public static GuidEx NewGuid()
        {
            return Conversion.ToGuidEx(Guid.NewGuid());
        }
    }

    public static partial class Conversion
    {
        public static Guid ToGuid(GuidEx guidEx)
        {
            Span<byte> buffer = stackalloc byte[Memory.SizeOf<GuidEx>()];
            Memory.Packing(buffer, guidEx);
            return new Guid(buffer);
        }

        public static GuidEx ToGuidEx(Guid guid)
        {
            return new GuidEx(guid.ToString("N"));
        }

        public static string ToString(Guid guid)
        {
            return ToGuidEx(guid).ToString();
        }

        /*
        // ReSharper disable once MemberCanBePrivate.Global
        public static byte[] ToByteArray(GuidEx guidEx)
        {
            return guidEx.ToByteArray();
        }
        */
        /*
        public static GuidEx ToGuidEx(Variant.Var root)
        {
            return new GuidEx((byte[])root);
        }
        */
        /*
        public static Variant.Var ToVar(GuidEx guidEx)
        {
            return ToByteArray(guidEx);
        }
        */

        public static bool IsGuidEx(ReadOnlySpan<char> sources)
        {
            if (sources.Length != 32)
                return false;

            for (var i = 0; i != sources.Length; i++)
            {
                var ch = sources[i];
                if (!(ch is >= '0' and <= '9') && !(ch is >= 'a' and <= 'f'))
                    return false;
            }

            return true;
        }

        private static readonly char[] _valueToHex =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'
        };

        internal static char ValueToHex(uint value)
        {
            return _valueToHex[value];
        }

        private static readonly uint[] _hexToValue =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue,
            uint.MaxValue, uint.MaxValue, 10, 11, 12, 13, 14, 15, uint.MaxValue, uint.MaxValue, uint.MaxValue,
            uint.MaxValue, uint.MaxValue, uint.MaxValue,
            uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue,
            uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue,
            uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, 10, 11, 12, 13,
            14, 15
        };

        internal static uint HexToValue(char value)
        {
            return _hexToValue[value - '0'];
        }

        public static GuidEx ToMd5(ReadOnlySpan<char> sources)
        {
            return ToMd5(MemoryMarshal.Cast<char, byte>(sources));
        }

        public static GuidEx ToMd5(ReadOnlySpan<byte> source)
        {
            Span<byte> destination = stackalloc byte[Memory.SizeOf<GuidEx>()];
            MD5.HashData(source, destination);
            Memory.Unpacking(destination, out GuidEx guid);
            return guid;
        }
    }
}