using System;

namespace WiB
{
    public static class StringExtensions
    {
        public static LineSplitEnumerator Split(this ReadOnlySpan<char> sources, char separator = '.')
        {
            return new LineSplitEnumerator(sources, separator);
        }

        public ref struct LineSplitEnumerator
        {
            private ReadOnlySpan<char> _sources;
            private readonly char _separator;

            public LineSplitEnumerator(ReadOnlySpan<char> sources, char separator = '.')
            {
                _sources = sources;
                _separator = separator;
                Current = default;
            }

            public LineSplitEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                var span = _sources;
                
                if (span.Length == 0)
                    return false;

                var index = span.IndexOf(_separator);

                if (index == -1)
                {
                    _sources = ReadOnlySpan<char>.Empty;
                    Current = span;
                    return true;
                }
                
                Current = span[..index];
                _sources = span[(index + 1)..];
                
                return true;
            }

            public ReadOnlySpan<char> Current { get; private set; }
        }
    }
}