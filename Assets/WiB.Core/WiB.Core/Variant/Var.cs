using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WiB.Variant;

namespace WiB.Variant
{
    public abstract class Var
    {
        protected Var(VariantType variantType)
        {
            VariantType = variantType;
        }

        public VariantType VariantType { get; }

        public static VNull GetNull()
        {
            return new VNull();
        }

        public static VBool GetBool(bool value)
        {
            return new VBool(value);
        }

        public static VInt32 GetInt32(int value)
        {
            return new VInt32(value);
        }

        public static implicit operator bool(Var value)
        {
            return (VBool)value;
        }

        public static implicit operator int(Var value)
        {
            return (VInt32)value;
        }

        public static implicit operator float(Var value)
        {
            return (VFloat)value;
        }

        public static implicit operator string(Var value)
        {
            return (VString)value;
        }

        public static implicit operator byte[](Var value)
        {
            return (VBytes)value;
        }
        
        public static implicit operator VariantType(Var value)
        {
            return (VType)value;
        }
        /*
        public static implicit operator List<Var>(Var value)
        {
            return (VList)value;
        }
        public static implicit operator Dictionary<string, Var>(Var value)
        {
            return (VDictionary)value;
        }
        */
        /*
        public static implicit operator Var( value)
        {
            return GetNull();
        }
        */
        public static implicit operator Var(bool value)
        {
            return GetBool(value);
        }

        public static implicit operator Var(int value)
        {
            return GetInt32(value);
        }

        public static implicit operator Var(float value)
        {
            return GetFloat(value);
        }

        public static implicit operator Var(string value)
        {
            return GetString(value);
        }

        public static implicit operator Var(byte[] value)
        {
            return GetBytes(value);
        }
        
        public static implicit operator Var(VariantType value)
        {
            return GetType(value);
        }

        public static VFloat GetFloat(float value)
        {
            return new VFloat(value);
        }

        public static VString GetString(string value)
        {
            return new VString(value);
        }

        public static VString GetString(ReadOnlySpan<char> source)
        {
            return new VString(source.ToString());
        }

        public static VDictionary GetDictionary(int capacity)
        {
            return new VDictionary(capacity);
        }

        public static VDictionary GetDictionary()
        {
            return new VDictionary();
        }
        /*
        public static VList GetList(Var[] data)
        {
            ArgumentNullException.ThrowIfNull(data, nameof(data));

            var list = new VList(data.Length);

            foreach (var d in data)
                list.Add(d);

            return list;
        }
        */
        /*
        public static VList GetList(params Var[] data)
        {
            ArgumentNullException.ThrowIfNull(data, nameof(data));

            var list = new VList(data.Length);

            foreach (var d in data)
                list.Add(d);

            return list;
        }
        */

        public static VList GetList(
            [NotNull] Var value0, 
            [NotNull] Var value1)
        {
            ArgumentNullException.ThrowIfNull(value0, nameof(value0));
            ArgumentNullException.ThrowIfNull(value1, nameof(value1));

            var vList = GetList(2);

            vList.Add(value0);
            vList.Add(value1);

            return vList;
        }

        public static VList GetList(
            [NotNull] Var value0, 
            [NotNull] Var value1, 
            [NotNull] Var value2,
            [NotNull] Var value3)
        {
            ArgumentNullException.ThrowIfNull(value0, nameof(value0));
            ArgumentNullException.ThrowIfNull(value1, nameof(value1));
            ArgumentNullException.ThrowIfNull(value2, nameof(value2));
            ArgumentNullException.ThrowIfNull(value3, nameof(value3));

            var vList = GetList(4);

            vList.Add(value0);
            vList.Add(value1);
            vList.Add(value2);
            vList.Add(value3);

            return vList;
        }

        public static VList GetList(int capacity)
        {
            return new VList(capacity);
        }

        public static VList GetList()
        {
            return new VList();
        }

        public Var this[int index]
        {
            get => ((VList)this)[index];
            set
            {
                value ??= GetNull();
                ((VList)this)[index] = value;    
            }
        }

        public Var this[string key]
        {
            get => ((VDictionary)this)[key];
            set
            {
                value ??= GetNull(); 
                ((VDictionary)this)[key] = value;    
            }
        }

        public static VObject GetObject(string type, int capacity)
        {
            return new VObject(type, capacity);
        }

        public static VObject GetObject(string type)
        {
            return new VObject(type);
        }

        public static VBytes GetBytes(byte[] value)
        {
            return new VBytes(value);
        }

        public static VType GetType(VariantType type)
        {
            return new VType(type);
        }
    }
}


namespace WiB
{
    public static partial class Conversion
    {
        public static bool IsVar(VariantType type, ReadOnlySpan<char> source)
        {
            switch (type)
            {
                case VariantType.Null: return true;
                case VariantType.Bool: return IsBool(source, out _);
                case VariantType.Int32: return IsInt32(source, out _);
                case VariantType.Float: return IsFloat(source, out _);
                case VariantType.String: return true;
                case VariantType.Bytes: return IsByteArray(source);
                case VariantType.Type: return IsVariantType(source, out _);
            }

            return false;
        }

        public static Var ToVar(VariantType type, ReadOnlySpan<char> source)
        {
            switch (type)
            {
                case VariantType.Null: return Var.GetNull();
                case VariantType.Bool: return Var.GetBool(ToBool(source));
                case VariantType.Int32: return Var.GetInt32(ToInt32(source));
                case VariantType.Float: return Var.GetFloat(ToFloat(source));
                case VariantType.String: return Var.GetString(source);
                case VariantType.Bytes: return Var.GetBytes(ToByteArray(source));
                case VariantType.Type: return Var.GetType(ToVariantType(source));
            }

            //throw new VariantConvertException(typeof(string), type);
            throw new InvalidOperationException();
        }

        public static Var ToVar(Exception exception)
        {
            var list = Var.GetList();

            var ex = exception;
            do
            {
                list.Add(Var.GetString(ex.Message));
                ex = ex.InnerException;
            } while (ex != null);


            return list;
        }
    }
}