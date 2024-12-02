namespace Day2
{
    internal static class Program
    {
        public static int Test1SampleResult = 2;
        public static int Test2SampleResult = 4;

        static void Main()
        {
            switch (FileType.Test2)
            {
                case FileType.Test1Sample:
                    Helper.WriteResult(Test1, FileType.Test1Sample, Test1SampleResult);
                    break;
                case FileType.Test1:
                    Helper.WriteResult(Test1, FileType.Test1Sample);
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
            var lines = input.Select(i => ParseLine(i).ToList()).ToList();
            var result = lines.Where(x => IsSave(x.ToList()) && IsIncreasingOrDecreasing(x));
            return result.Count();
        }

        internal static int Test2(List<string> input)
        {
            var lines = input.Select(ParseLine).ToList();
            var result = lines.Where(i => IsSave2(i.ToList()));
            return result.Count();
        }

        internal static IEnumerable<int>ParseLine(string input)
        {
            return input.Split(' ').Select(int.Parse);
        }

        internal static bool IsIncreasingOrDecreasing(IEnumerable<int> input)
        {
            return input.OrderBy(x => x).SequenceEqual(input) || input.OrderByDescending(x => x).SequenceEqual(input);
        }

        internal static bool IsSave(List<int> input)
        {
            foreach (var i in Enumerable.Range(0, input.Count - 1))
            {
                var diff = input[i] - input[i + 1];
                if ((diff > 3 || diff < -3) || diff == 0)
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool IsSave2(List<int> input, bool canRetest = true)
        {
            var incease = input[0] < input[input.Count -1];
            if (canRetest)
            {
                AnsiConsole.MarkupLine($"===============================");
            }
            AnsiConsole.MarkupLine($"Input: {string.Join(" ", input)} {incease} {canRetest}");
            foreach (var i in Enumerable.Range(0, input.Count - 1))
            {
                if (incease && input[i] > input[i + 1])
                {
                    if (!canRetest)
                    {
                        AnsiConsole.MarkupLine($"Return1: false");
                        return false;
                    }
                    var item1 = input.DeepCopy();
                    item1.RemoveAt(i);
                    var item2 = input.DeepCopy();
                    item2.RemoveAt(i + 1);

                    return IsSave2(item1, false) || IsSave2(item2, false);
                }
                if (!incease && input[i] < input[i + 1])
                {
                    if (!canRetest)
                    {
                        AnsiConsole.MarkupLine($"Return2: false");
                        return false;
                    }
                    var item1 = input.DeepCopy();
                    item1.RemoveAt(i);
                    var item2 = input.DeepCopy();
                    item2.RemoveAt(i + 1);

                    return IsSave2(item1, false) || IsSave2(item2, false);
                }
                AnsiConsole.MarkupLine($"Compare: {input[i]}, {input[i+1]}");
                var diff = input[i] - input[i + 1];
                if ((diff > 3 || diff < -3) || diff == 0)
                {
                    if (!canRetest)
                    {
                        AnsiConsole.MarkupLine($"Return3: false");
                        return false;
                    }
                    var item1 = input.DeepCopy();
                    item1.RemoveAt(i);
                    var item2 = input.DeepCopy();
                    item2.RemoveAt(i + 1);

                    return IsSave2(item1, false) || IsSave2(item2, false);
                }
            }
            AnsiConsole.MarkupLine($"Return: true");
            return true;
        }
    }
}
