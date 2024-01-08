using System;

namespace WiB
{
    [Serializable]
    public readonly struct Version : IEquatable<Version>
    {
        public static Version Empty = new Version();

#if UNITY_2019_1_OR_NEWER
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private int _release;
        [UnityEngine.SerializeField]
        [UnityEngine.HideInInspector]
        private int _revision;
#else
        private readonly int _release;
        private readonly int _revision;
#endif
        public Version(ReadOnlySpan<char> sources)
        {
            _release = 0;
            _revision = 0;

            var part = 0;

            foreach (var line in sources.Split())
            {
                try
                {
                    var n = Conversion.ToInt32(line);

                    if (n > 999)
                        throw new ArgumentException("The maximum value: 999.");

                    if (part == 0)
                        _release = n;
                    if (part == 1)
                        _revision = n;

                    if (++part > 2)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("The version must contain 2 numeric blocks separated by a dot.", ex);
                }
            }
        }

        internal Version(byte[] version, int offset = 0)
        {
            _release = Memory.UnpackInt32(version, ref offset);
            _revision = Memory.UnpackInt32(version, ref offset);
        }

        public static bool operator ==(Version l, Version r)
        {
            if (l._release != r._release)
                return false;
            if (l._revision != r._revision)
                return false;

            return true;
        }

        public static bool operator !=(Version l, Version r)
        {
            return !(l == r);
        }

        public bool Equals(Version other)
        {
            return this == other;
        }

        public override string ToString()
        {
            return $"{_release}.{_revision}";
        }

        public override int GetHashCode()
        {
            return Conversion.ToInt32(_release * 1000 + _revision);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Version version))
                return false;

            return this == version;
        }

        public static bool operator >(Version version1, Version version2)
        {
            return version1.GetHashCode() > version2.GetHashCode();
        }

        public static bool operator <(Version version1, Version version2)
        {
            return version1.GetHashCode() < version2.GetHashCode();
        }

        public static bool operator >=(Version version1, Version version2)
        {
            return version1.GetHashCode() >= version2.GetHashCode();
        }

        public static bool operator <=(Version version1, Version version2)
        {
            return version1.GetHashCode() <= version2.GetHashCode();
        }
    }

    public static partial class Conversion
    {
        public static string ToString(Version version)
        {
            return version.ToString();
        }

        public static bool IsVersion(ReadOnlySpan<char> sources, char separator = '.')
        {
            var parts = 0;

            foreach (var line in sources.Split(separator))
            {
                if (!AreNumbers(line))
                    return false;

                if (line.Length > 3)
                    return false;

                if (++parts > 2)
                    return false;
            }

            return true;
        }
    }
}