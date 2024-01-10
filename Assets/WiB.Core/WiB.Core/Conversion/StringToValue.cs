using System;
using System.Globalization;
using System.Net;

namespace WiB
{
    public static partial class Conversion
    {
        public static bool IsInt8(ReadOnlySpan<char> source, out sbyte destination)
        {
            return sbyte.TryParse(source, out destination);
        }

        public static bool IsInt16(ReadOnlySpan<char> source, out short destination)
        {
            return short.TryParse(source, out destination);
        }

        public static bool IsInt32(ReadOnlySpan<char> source, out int destination)
        {
            return int.TryParse(source, out destination);
        }

        public static bool IsInt64(ReadOnlySpan<char> source, out long destination)
        {
            return long.TryParse(source, out destination);
        }

        public static bool IsUInt8(ReadOnlySpan<char> sources, out byte destination)
        {
            return sources.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? byte.TryParse(sources[2..], NumberStyles.HexNumber, null, out destination)
                : byte.TryParse(sources, out destination);
        }

        public static bool IsUInt16(ReadOnlySpan<char> sources, out ushort destination)
        {
            return sources.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? ushort.TryParse(sources[2..], NumberStyles.HexNumber, null, out destination)
                : ushort.TryParse(sources, out destination);
        }

        public static bool IsUInt32(ReadOnlySpan<char> sources, out uint destination)
        {
            return sources.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? uint.TryParse(sources[2..], NumberStyles.HexNumber, null, out destination)
                : uint.TryParse(sources, out destination);
        }

        public static bool IsUInt64(ReadOnlySpan<char> sources, out ulong destination)
        {
            return sources.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? ulong.TryParse(sources[2..], NumberStyles.HexNumber, null, out destination)
                : ulong.TryParse(sources, out destination);
        }

        public static sbyte ToInt8(ReadOnlySpan<char> source)
        {
            if (!IsInt8(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static short ToInt16(ReadOnlySpan<char> source)
        {
            if (!IsInt16(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static int ToInt32(ReadOnlySpan<char> source)
        {
            if (!IsInt32(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static long ToInt64(ReadOnlySpan<char> source)
        {
            if (!IsInt64(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static byte ToUInt8(ReadOnlySpan<char> source)
        {
            if (!IsUInt8(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static ushort ToUInt16(ReadOnlySpan<char> source)
        {
            if (!IsUInt16(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static uint ToUInt32(ReadOnlySpan<char> source)
        {
            if (!IsUInt32(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static ulong ToUInt64(ReadOnlySpan<char> source)
        {
            if (!IsUInt64(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static bool IsBool(ReadOnlySpan<char> source, out bool destination)
        {
            destination = false;
            
            if (source.Length == 1)
            {
                switch (source[0])
                {
                    case '1':
                        destination = true;
                        return true;
                    case '0':
                        return true;
                    default:
                        return false;
                }
            }

            if (source.Length == 4)
            {
                if (!(source[0] == 'T' || source[0] == 't'))
                    return false;

                if (source[1] != 'r')
                    return false;

                if (source[2] != 'u')
                    return false;

                if (source[3] != 'e')
                    return false;

                destination = true;
                return true;
            }
            
            if (source.Length == 5)
            {
                if (!(source[0] == 'F' && source[0] == 'f'))
                    return false;

                if (source[1] != 'a')
                    return false;

                if (source[2] != 'l')
                    return false;

                if (source[3] != 's')
                    return false;

                if (source[4] != 'e')
                    return false;

                return true;
            }

            return false;
        }
        
        public static bool ToBool(ReadOnlySpan<char> source)
        {
            if (!IsBool(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static bool IsFloat(ReadOnlySpan<char> source, out float destination)
        {
            return float.TryParse(source, NumberStyles.Float, CultureInfo.InvariantCulture, out destination);
        }
        
        public static float ToFloat(ReadOnlySpan<char> source)
        {
            if (!IsFloat(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;    
        }
        
        public static bool IsDouble(ReadOnlySpan<char> source, out double destination)
        {
            return double.TryParse(source, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out destination);
        }
        
        public static double ToDouble(ReadOnlySpan<char> source)
        {
            if (!IsDouble(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;    
        }
        
        public static bool IsDecimal(ReadOnlySpan<char> source, out decimal destination)
        {
            return decimal.TryParse(source, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out destination);
        }
        
        public static decimal ToDecimal(ReadOnlySpan<char> source)
        {
            if (!IsDecimal(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;    
        }
        
        /*
        public static string ToHexString(ReadOnlySpan<char> source)
        {
            return ByteArrayToHexString(ToByteArray(source));
        }

        public static void StringToFile(string path, ReadOnlySpan<char> sources)
        {
            try
            {
                //var x = new FileStream()
                File.WriteAllText(path, sources);
            }
            catch (Exception ex)
            {
                throw new Exception("error writing to file: " + path, ex);
            }
        }
        */
        
        public static bool IsIpAddress(ReadOnlySpan<char> source, out IPAddress destination)
        {
            return IPAddress.TryParse(source, out destination);
        }
        
        public static IPAddress ToIpAddress(ReadOnlySpan<char> source)
        {
            if (!IsIpAddress(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(source)}.");

            return value;
        }

        

        /*
        public static GuidEx ToMd5(byte[] value, ref int offset, int count)
        {
            var uid = ToMd5(value, offset, count);
            offset += count;
            return uid;
        }
        */

        /*
        public static bool IsInt32(ReadOnlySpan<char> sources)
        {
            if (sources.IsEmpty)
                return false;

            var begin = 0;
            var end = sources.Length;

            if (sources[0] is '-' or '+')
            {
                begin++;

                if (sources.Length - begin == 0)
                    return false;
            }

            for (var i = begin; i != end; i++)
                if (!IsNumberSymbol(sources[i]))
                    return false;

            return true;
        }
        */
        
        // ReSharper disable once MemberCanBePrivate.Global
        /*
        public static bool FastCheckFloat(ReadOnlySpan<char> sources)
        {
            if (sources.IsEmpty)
                return false;

            var begin = 0;
            var end = sources.Length;

            var ch = sources[begin];

            if (ch is '-' or '+')
            {
                begin++;

                if (end - begin == 0)
                    return false;
            }

            var point = -1;

            for (var i = begin; i != end; i++)
            {
                ch = sources[i];

                if (ch is >= '0' and <= '9')
                    continue;

                if (ch != '.')
                    return false;

                if (point >= 0)
                    return false;

                point = i;
            }

            if (point == -1)
                return true;
            if (point - begin == 0)
                return false;
            if (end - 1 - point == 0)
                return false;

            return true;
        }
        */
        
        // ReSharper disable once MemberCanBePrivate.Global
        public static bool FastCheckName(ReadOnlySpan<char> sources)
        {
            for (var i = 0; i != sources.Length; i++)
            {
                var symbol = sources[i];
                if (!IsUpperSymbol(symbol) && !IsLowerSymbol(symbol) && symbol != '_')
                    return false;
            }

            return true;
        }

        public static bool AreNumbers(ReadOnlySpan<char> sources)
        {
            for (var i = 0; i != sources.Length; i++)
                if (!IsNumericSymbol(sources[i]))
                    return false;

            return true;
        }

        public static bool IsUpperSymbol(char symbol)
        {
            return symbol is >= 'A' and <= 'Z';
        }

        public static bool IsLowerSymbol(char symbol)
        {
            return symbol is >= 'a' and <= 'z';
        }
        
        public static bool IsNumericSymbol(char symbol)
        {
            return symbol is >= '0' and <= '9';
        }
        
        public static bool IsHexNumericSymbol(char symbol)
        {
            return symbol is >= '0' and <= '9' or >= 'a' and <= 'z' or >= 'A' and <= 'F';
        }

        /*
        public static bool AreLitersAZ(ReadOnlySpan<char> sources)
        {
            for (var i = 0; i != sources.Length; i++)
                if (sources[i] is < '0' or > '9')
                    return false;

            return true;
        }
        */

        public static string NameValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("name cannot be null or empty");

            if (!FastCheckName(name.AsSpan()))
                throw new Exception("invalid name: " + name + ", may contain only a-Z characters");

            return name;
        }

        internal static string NameValidationIgnoringNullOrWhiteSpace(string name)
        {
            if (name == null)
                return null;

            if (string.IsNullOrWhiteSpace(name))
                return null;

            if (!FastCheckName(name.AsSpan()))
                throw new Exception("invalid name: " + name + ", may contain only a-Z characters");

            return name;
        }
    }
}