namespace Day5
{
    public static class Program
    {
        public static int Test1SampleResult = 143;
        public static int Test2SampleResult = 123;

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
            var (pages, rules) = Parse(input);
            var valids = pages.Where(i => IsValid(i, rules));
            return valids.Sum(GetMiddle);
        }

        internal static int Test2(List<string> input)
        {
            var (pages, rules) = Parse(input);
            var invalids = pages.Where(i => !IsValid(i, rules));
            var middles = invalids.Select(i => ReOrder(i, rules)).Select(GetMiddle);
            return middles.Sum();
        }

        public static int GetMiddle(List<int> input)
        {
            return input[input.Count / 2];
        }

        internal static (List<List<int>> pages, List<Rule> rules) Parse(List<string> input)
        {
            var pages = new List<List<int>>();
            var rules = new List<Rule>();
            var isRule = true;
            foreach (var line in input)
            {
                if (line?.Length == 0)
                {
                    isRule = !isRule;
                    continue;
                }
                if (isRule)
                {
                    var split = line.Split("|");
                    rules.Add(new(split[0].GetInt(), split[1].GetInt()));
                }
                else
                {
                    pages.Add(line.Split(",").Select(i => i.GetInt()).ToList());
                }
            }
            return (pages, rules);
        }

        public static bool IsValid(List<int> pages, List<Rule> rules)
        {
            var pagesReverse = pages.DeepCopy();
            pagesReverse.Reverse();
            var first = new Queue<int>();
            var last = new Stack<int>(pagesReverse);
            foreach (var i in Enumerable.Range(0, pages.Count))
            {
                foreach (var rule in rules)
                {
                    if (last.Peek() == rule.Before && first.Contains(rule.After))
                    {
                        AnsiConsole.MarkupLine($"[red]Invalid {rule.Before}|{rule.After}[/]");
                        return false;
                    }
                }
                first.Enqueue(last.Pop());
            }
            return true;
        }

        public static List<int> ReOrder(List<int> pages, List<Rule> rules)
        {
            AnsiConsole.MarkupLine($"[bold red]Reordering {string.Join(",", pages)}[/]");
            var first = new LinkedList<int>(pages);
            bool hasPermutation;
            do
            {
                hasPermutation = false;
                var last = new LinkedList<int>(first);
                first.Clear();
                first.AddLast(last.PopFirst());
                foreach (var i in Enumerable.Range(0, pages.Count -1))
                {
                    foreach (var rule in rules)
                    {
                        if (first.Last.Value == rule.After && last.First.Value == rule.Before)
                        {
                            var a = first.PopLast();
                            var b = last.PopFirst();
                            first.AddLast(b);
                            last.AddFirst(a);
                            hasPermutation = true;
                        }
                    }
                    first.AddLast(last.PopFirst());
                }
            }
            while (hasPermutation);
            AnsiConsole.MarkupLine($"[lime]Reordered {string.Join(",", first)} and is {IsValid([.. first], rules)} [/] ");
            return [.. first];
        }

        public class Rule(int before, int after)
        {
            public int Before { get; set; } = before;
            public int After { get; set; } = after;
        }
    }
}
