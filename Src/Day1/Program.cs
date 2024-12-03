namespace Day1
{
    internal static class Program
    {
        public static int Test1SampleResult = 11;
        public static int Test2SampleResult = 31;

        static void Main()
        {
            switch (FileType.Test2)
            {
                case FileType.Test1Sample:
                    Helper.WriteResult(Test1, FileType.Test1Sample, Test1SampleResult);
                    break;
                case FileType.Test1:
                    Helper.WriteResult(Test1, FileType.Test1);
                    break;
                case FileType.Test2Sample:
                    Helper.WriteResult(Test2, FileType.Test1Sample, Test2SampleResult);
                    break;
                case FileType.Test2:
                    Helper.WriteResult(Test2, FileType.Test1);
                    break;
            }
        }

        internal static int Test1(List<string> input)
        {
            var output = input.Select(i => i.Split("   "));
            var list1 = output.Select(i => i[0].GetInt()).Order().ToList();
            var list2 = output.Select(i => i[1].GetInt()).Order().ToList();
            return list1.Select((item, index) => Math.Abs(item - list2[index])).Sum();
        }

        internal static int Test2(List<string> input)
        {
            var output = input.Select(i => i.Split("   "));
            var list1 = output.Select(i => i[0].GetInt()).ToList();
            var list2 = output.Select(i => i[1].GetInt()).ToList();
            return list1.Sum(item => list2.Count(i => i == item) * item);
        }
    }
}
