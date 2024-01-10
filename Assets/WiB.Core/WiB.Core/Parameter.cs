using System;
using WiB;
using WiB.Variant;

namespace WiB
{
    [Serializable]
    public enum ParamType
    {
        Bool = 1,
        Int = 2,
        Float = 3
    }

    [Serializable]
    public readonly struct Param
    {
#if UNITY_2019_1_OR_NEWER
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _type;

        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private readonly uint _data;
#else
        private readonly ParamType _type;
        private readonly Data4 _data;
#endif

        /*
        public Param(ReadOnlySpan<char> sources)
        {
            var param = Conversion.ToParam(sources);
            _type = param._type;
            _data = param._data;
        }
        */
        /*
        public Param()
        {
            _type = ParamType.None;
            _data = new Data4();
        }
        */

        public Param(bool b)
        {
            _type = ParamType.Bool;
            _data = Memory.As<bool, Data4>(b);
        }

        public Param(int i)
        {
            _type = ParamType.Int;
            _data = Memory.As<int, Data4>(i);
        }

        public Param(float f)
        {
            _type = ParamType.Float;
            _data = Memory.As<float, Data4>(f);
        }

        private bool GetBool()
        {
            return Memory.As<Data4, bool>(_data);
        }

        private int GetInt()
        {
            return Memory.As<Data4, int>(_data);
        }

        private float GetFloat()
        {
            return Memory.As<Data4, float>(_data);
        }

        public ParamType Type => _type;

        public static implicit operator bool(Param p)
        {
            if (p.Type != ParamType.Bool)
                throw new Exception($"Impossible cast from: {p.Type} to {ParamType.Bool}");

            return p.GetBool();
        }

        public static implicit operator int(Param p)
        {
            if (p.Type != ParamType.Int)
                throw new Exception($"Impossible cast from: {p.Type} to {ParamType.Int}");

            return p.GetInt();
        }

        public static implicit operator float(Param p)
        {
            if (p.Type != ParamType.Float)
                throw new Exception($"Impossible cast from: {p.Type} to {ParamType.Float}");

            return p.GetFloat();
        }

        public static implicit operator Param(int p) => new(p);

        public static implicit operator Param(bool p) => new(p);

        public static implicit operator Param(float p) => new(p);

        public override string ToString()
        {
            return Type switch
            {
                ParamType.Bool => Conversion.ToString(GetBool()),
                ParamType.Int => Conversion.ToString(GetInt()),
                ParamType.Float => Conversion.ToString(GetFloat()),
                _ => "null"
            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Param param))
                return false;

            return this == param;
        }

        public override int GetHashCode()
        {
            return _type.GetHashCode() * _data.GetHashCode();
        }

        public static bool operator !(Param param)
        {
            if (param.Type == ParamType.Bool)
                return !param.GetBool();

            throw new Exception($"Cannot invert operation (!): {param}.");
        }

        public static bool operator ==(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Bool => left.GetBool() == right.GetBool(),
                ParamType.Int => left.GetInt() == right.GetInt(),
                ParamType.Float => Math.CompareFloat(left.GetFloat(), right.GetFloat()),
                _ => true
            };
        }

        public static bool operator !=(Param left, Param right)
        {
            return !(left == right);
        }

        public static bool operator >=(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() >= right.GetInt(),
                ParamType.Float => left.GetFloat() >= right.GetFloat(),
                _ => false
            };
        }

        public static bool operator <=(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() <= right.GetInt(),
                ParamType.Float => left.GetFloat() <= right.GetFloat(),
                _ => false
            };
        }

        public static bool operator >(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() > right.GetInt(),
                ParamType.Float => left.GetFloat() > right.GetFloat(),
                _ => false
            };
        }

        public static bool operator <(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() < right.GetInt(),
                ParamType.Float => left.GetFloat() < right.GetFloat(),
                _ => false
            };
        }

        public static Param operator -(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() - right.GetInt(),
                ParamType.Float => left.GetFloat() - right.GetFloat(),
                _ => throw new Exception(
                    $"impossible to perform a mathematical operation (-), left: {left} right: {right}")
            };
        }

        public static Param operator +(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() + right.GetInt(),
                ParamType.Float => left.GetFloat() + right.GetFloat(),
                _ => throw new Exception($"impossible to perform a mathematical operation (+): {left} right: {right}")
            };
        }

        public static Param operator *(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => left.GetInt() * right.GetInt(),
                ParamType.Float => left.GetInt() * right.GetInt(),
                _ => throw new Exception($"impossible to perform a mathematical operation (*): {left} right: {right}")
            };
        }

        public static Param operator /(Param left, Param right)
        {
            if (left.Type != right.Type)
                throw new Exception($"variable types must be the same, left: {left} right: {right}");

            return left.Type switch
            {
                ParamType.Int => Conversion.ToInt32(left.GetInt() / right.GetInt()),
                ParamType.Float => left.GetFloat() / right.GetFloat(),
                _ => throw new Exception(
                    $"impossible to perform a mathematical operation (/) left: {left} right: {right}")
            };
        }
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public static Param ToParam(ReadOnlySpan<char> source)
        {
            if (!IsParam(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }

        public static bool IsParam(ParamType type, ReadOnlySpan<char> source, out Param destination)
        {
            switch (type)
            {
                case ParamType.Bool when IsBool(source, out var b):
                    destination = new Param(b);
                    return true;
                case ParamType.Int when IsInt32(source, out var i):
                    destination = new Param(i);
                    return true;
                case ParamType.Float when IsFloat(source, out var f):
                    destination = new Param(f);
                    return true;
                default:
                    destination = default;
                    return false;
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static bool IsParam(ReadOnlySpan<char> source, out Param destination)
        {
            if (IsBool(source, out var b))
            {
                destination = new Param(b);
                return true;
            }

            if (IsInt32(source, out var i))
            {
                destination = new Param(i);
                return true;
            }

            if (IsFloat(source, out var f))
            {
                destination = new Param(f);
                return true;
            }

            destination = default;
            return false;
        }

        public static Var ToVar(Param value)
        {
            return value.Type switch
            {
                ParamType.Bool => (bool)value,
                ParamType.Int => (int)value,
                ParamType.Float => (float)value,
                _ => throw new Exception("impossible to convert param to var")
            };
        }

        public static Param ToParam(Var value)
        {
            return value.VariantType switch
            {
                VariantType.Bool => new Param((bool)value),
                VariantType.Int32 => new Param((int)value),
                VariantType.Float => new Param((float)value),
                _ => throw new Exception("impossible to convert var to param")
            };
        }
    }
}