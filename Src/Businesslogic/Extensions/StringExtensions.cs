namespace Businesslogic.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this string self, IEnumerable<char> items)
        {
            return self.Any(x => items.Contains(x));
        }

        public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public static bool IsNumeric(this string str)
        {
            return int.TryParse(str, out _);
        }

        public static int GetInt(this string str)
        {
            int.TryParse(str, out var output);
            return output;
        }
    }
}
