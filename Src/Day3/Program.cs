using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day3
{
    public static partial class Program
    {
        public static int Test1SampleResult = 161;
        public static int Test2SampleResult = 48;

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
                    Helper.WriteResult(Test2, FileType.Test2Sample, Test2SampleResult);
                    break;
                case FileType.Test2:
                    Helper.WriteResult(Test2, FileType.Test1);
                    break;
            }
        }

        internal static long Test1(List<string> input)
        {
            var result = input.SelectMany(ParselLines);
            return result.Sum(i => i.Operator switch
            {
                "mul" => (long)i.First * i.Second,
                _ => 0
            });
        }

        internal static long Test2(List<string> input)
        {
            var result = input.SelectMany(ParselLines);
            var active = true;
            var output = 0L;
            foreach (var command in result)
            {
                switch (command.Operator)
                {
                    case "don't":
                        active = false;
                        break;
                    case "do":
                        active = true;
                        break;
                    case "mul":
                        if(active)
                        {
                            output += command.First * command.Second;
                        }
                        break;
                }
            }
            return output;
        }

        [GeneratedRegex(@"(?<Operator>do|don't|mul)\(((?<First>\d{1,3}),(?<Second>\d{1,3}))?\)")]
        public static partial Regex MultiplicationRegex();

        public static IEnumerable<Value> ParselLines(string input)
        {
            var regex = MultiplicationRegex();
            var matches = regex.Matches(input);
            return matches.Select(i => new Value(i.Groups["First"].Value.GetInt(), i.Groups["Second"].Value.GetInt(), i.Groups["Operator"].Value)).ToList();
        }

        [DebuggerDisplay("{Operator}({First},{Second})")]
        public class Value(int first, int second, string @operator)
        {
            public int First { get; set; } = first;
            public int Second { get; set; } = second;
            public string Operator { get; set; } = @operator;
        }
    }
}
