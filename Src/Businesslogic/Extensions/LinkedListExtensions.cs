namespace Businesslogic.Extensions
{
    public static class LinkedListExtensions
    {
        public static T PopFirst<T>(this LinkedList<T> list)
        {
            var node = list.First;
            if (node == null)
            {
                throw new InvalidOperationException("The LinkedList is empty");
            }
            list.RemoveFirst();
            return node.Value;
        }
        public static T PopLast<T>(this LinkedList<T> list)
        {
            var node = list.Last;
            if (node == null)
            {
                throw new InvalidOperationException("The LinkedList is empty");
            }
            list.RemoveLast();
            return node.Value;
        }
    }
}
