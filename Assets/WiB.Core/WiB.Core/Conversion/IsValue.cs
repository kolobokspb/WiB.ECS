using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WiB
{
    public static partial class Conversion
    {
        public static bool IsMacAddress(ReadOnlySpan<char> source)
        {
            //0a:1b:3c:4d:5e:6f
            //0a-1b-3c-4d-5e-6f
            //0a1b.3c4d.5e6f
            return Regex.IsMatch(source,
                "^([0-9a-fA-F]{2}(-|:)){5}([0-9a-fA-F]{2})$|([0-9a-fA-F]{4}.){2}([0-9a-fA-F]{4})$");
        }

        public static bool IsIpAddress(ReadOnlySpan<char> source)
        {
            //000.000.000.000
            //192.168.0.1
            return Regex.IsMatch(source, "^([0-9]{1,3}\\.){3}([0-9]{1,3})$");
        }


        /*
        public static bool IsInt8(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return sbyte.TryParse(value, out _);

            value = value.Substring(2);
            return byte.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsInt16(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return short.TryParse(value, out _);

            value = value.Substring(2);
            return ushort.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsInt(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return int.TryParse(value, out _);

            value = value.Substring(2);
            return uint.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsInt64(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return long.TryParse(value, out _);

            value = value.Substring(2);
            return ulong.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsUInt8(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return byte.TryParse(value, out _);

            value = value.Substring(2);
            return byte.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsUInt16(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return ushort.TryParse(value, out _);

            value = value.Substring(2);
            return ushort.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsUInt32(ReadOnlySpan<char> sources)
        {
            // strip the leading 0x
            return !sources.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? uint.TryParse(sources, out _)
                : uint.TryParse(sources[2..], NumberStyles.HexNumber, null, out _);
        }

        public static bool IsUInt64(ReadOnlySpan<char> source)
        {
            // strip the leading 0x
            if (!value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                return ulong.TryParse(value, out _);

            value = value.Substring(2);
            return ulong.TryParse(value, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsDouble(ReadOnlySpan<char> source)
        {
            var decimalSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            value = value.Replace(".", decimalSep);
            value = value.Replace(",", decimalSep);

            return double.TryParse(value, out _);
        }

        public static bool IsFloat(ReadOnlySpan<char> source)
        {
            var decimalSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            value = value.Replace(".", decimalSep);
            value = value.Replace(",", decimalSep);

            return float.TryParse(value, out _);
        }

        public static bool IsDecimal(ReadOnlySpan<char> source)
        {
            var decimalSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            value = value.Replace(".", decimalSep);
            value = value.Replace(",", decimalSep);

            return decimal.TryParse(value, out _);
        }

        public static bool IsString(string value)
        {
            return true;
        }

        public static bool IsBool(string value)
        {
            if (value == "0" || value == "1")
                return true;

            return bool.TryParse(value, out _);
        }
        */

        public static bool IsByteArray(ReadOnlySpan<char> source)
        {
            var length = source.Length;
            
            if (length % 2 != 0)
                return false;

            for (var i = 0; i != length; i++)
                if (!IsHexNumericSymbol(source[i]))
                    return false;

            return true;
        }
    }
}