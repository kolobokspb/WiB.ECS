using System;
using WiB.Math2;
using WiB.Variant;

namespace WiB.Math2
{
    public enum Direction2
    {
        Right = 0,
        Top = 1,
        Left = 2,
        Bottom = 3
    }
}

namespace WiB
{
    public static partial class Conversion
    {
        public const int Direction2Count = 4;

        private static readonly Direction2[,,] _directionRotation =
        {
            {
                { Direction2.Right, Direction2.Left },
                { Direction2.Top, Direction2.Bottom },
                { Direction2.Left, Direction2.Right },
                { Direction2.Bottom, Direction2.Top }
            },
            {
                { Direction2.Top, Direction2.Top },
                { Direction2.Left, Direction2.Left },
                { Direction2.Bottom, Direction2.Bottom },
                { Direction2.Right, Direction2.Right }
            },
            {
                { Direction2.Left, Direction2.Right },
                { Direction2.Bottom, Direction2.Top },
                { Direction2.Right, Direction2.Left },
                { Direction2.Top, Direction2.Bottom }
            },
            {
                { Direction2.Bottom, Direction2.Bottom },
                { Direction2.Right, Direction2.Right },
                { Direction2.Top, Direction2.Top },
                { Direction2.Left, Direction2.Left }
            }
        };

        private static readonly Direction2[,,] _directionRotationInverse =
        {
            {
                { Direction2.Right, Direction2.Left },
                { Direction2.Bottom, Direction2.Bottom },
                { Direction2.Left, Direction2.Right },
                { Direction2.Top, Direction2.Top }
            },
            {
                { Direction2.Top, Direction2.Top },
                { Direction2.Right, Direction2.Left },
                { Direction2.Bottom, Direction2.Bottom },
                { Direction2.Left, Direction2.Right }
            },
            {
                { Direction2.Left, Direction2.Right },
                { Direction2.Top, Direction2.Top },
                { Direction2.Right, Direction2.Left },
                { Direction2.Bottom, Direction2.Bottom }
            },
            {
                { Direction2.Bottom, Direction2.Bottom },
                { Direction2.Left, Direction2.Right },
                { Direction2.Top, Direction2.Top },
                { Direction2.Right, Direction2.Left }
            }
        };

        public static Direction2 ToDirection(Direction2 direction, Orientation2 orientation)
        {
            return _directionRotation[(int)direction, (int)orientation.Rotation, (int)orientation.Flip];
        }

        public static Direction2 ToDirection(Direction2 direction, InverseOrientation2 orientation)
        {
            return _directionRotationInverse[(int)direction, (int)orientation.Rotation, (int)orientation.Flip];
        }
        
        public static Var ToVar(Direction2 direction)
        {
            return ToInt32(direction);
        }
        
        public static Direction2 ToDirection2(ReadOnlySpan<char> source)
        {
            if (!IsDirection2(source, out var value))
                throw new Exception($"Cannot convert: {source.ToString()} to type: {nameof(value)}.");

            return value;
        }
        
        public static bool IsDirection2(ReadOnlySpan<char> source, out Direction2 destination)
        {
            return Enum.TryParse(source, out destination);
        }
        
        public static int ToInt32(Direction2 direction)
        {
            return (int)direction;
        }

        public static Direction2 ToDirection2(int direction)
        {
            return (Direction2)direction;
        }
    }
}