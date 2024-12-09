namespace Businesslogic.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DirectionAttribute(int x, int y) : Attribute
    {
        public int X { get; } = x;
        public int Y { get; } = y;
    }
}
