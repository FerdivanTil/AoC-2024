using Businesslogic.Attributes;

namespace Businesslogic.Locations
{
    [Flags]
    public enum Direction
    {
        [Direction(0, 0)]
        None = 0,
        [Direction(0, -1)]
        Top = 1,
        [Direction(1, -1)]
        TopRight = 2,
        [Direction(1, 0)]
        Right = 4,
        [Direction(1, 1)]
        BottomRight = 8,
        [Direction(0, 1)]
        Bottom = 16,
        [Direction(-1, 1)]
        BottomLeft = 32,
        [Direction(-1, 0)]
        Left = 64,
        [Direction(-1, -1)]
        TopLeft = 128,
        All = Top | TopRight | Right | BottomRight | Bottom | BottomLeft | Left | TopLeft,
        Cross = TopRight | BottomRight | BottomLeft | TopLeft,
        Plus = Top | Right | Bottom | Left
    }
}
