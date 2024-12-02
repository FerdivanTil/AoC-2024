namespace Template
{
    internal static class Program
    {
        public static int Test1SampleResult = 0;
        public static int Test2SampleResult = 0;

        static void Main()
        {
            switch (FileType.Test1Sample)
            {
                case FileType.Test1Sample:
                    Helper.WriteResult(Test1, FileType.Test1Sample, Test1SampleResult);
                    break;
                case FileType.Test1:
                    Helper.WriteResult(Test1, FileType.Test1);
                    break;
                case FileType.Test2Sample:
                    Helper.WriteResult(Test2, FileType.Test2Sample, Test2SampleResult);
                    break;
                case FileType.Test2:
                    Helper.WriteResult(Test2, FileType.Test2);
                    break;
            }
        }

        internal static int Test1(List<string> input)
        {
            throw new NotImplementedException();
            return 0;
        }

        internal static int Test2(List<string> input)
        {
            throw new NotImplementedException();
            return 0;
        }
    }
}
