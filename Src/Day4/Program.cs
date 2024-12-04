using System.IO;

namespace Day4
{
    internal static class Program
    {
        public static int Test1SampleResult = 18;
        public static int Test2SampleResult = 9;

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
            var result = 0;
            var grid = new Businesslogic.Locations.Grid<char>();
            grid.Parse(input.Select(i => i.ToList()).ToList());
            foreach (var coord in grid.All)
            {
                var cell = grid.GetValue(coord.x, coord.y);
                if (cell != 'X')
                {
                    continue;
                }
                var ajoining = grid.GetAdjoiningAll(coord.x, coord.y).Where(i => i.Value == 'M');

                if (!ajoining.Any())
                {
                    continue;
                }

                foreach (var item in ajoining)
                {
                    AnsiConsole.MarkupLine($"Found ajoining X at [red]{coord.y},{coord.x}[/]");
                    AnsiConsole.MarkupLine($"Found ajoining M at [red]{item.Y},{item.X}[/]");
                    var directionX = item.X - coord.x;
                    var directionY = item.Y - coord.y;
                    if (!grid.Exists(item.X + directionX, item.Y + directionY) || !grid.Exists(item.X + directionX * 2, item.Y + directionY * 2))
                    {
                        continue;
                    }
                    var a = grid.GetValue(item.X + directionX, item.Y + directionY);
                    AnsiConsole.MarkupLine($"Found ajoining {a} at [red]{item.X + directionX},{item.Y + directionY}[/]");
                    var s = grid.GetValue(item.X + directionX * 2, item.Y + directionY * 2);
                    AnsiConsole.MarkupLine($"Found ajoining {s} at [red]{item.X + directionX * 2},{item.Y + directionY * 2}[/]");

                    if (a == 'A' && s == 'S')
                    {
                        AnsiConsole.MarkupLine($"[lime]Found XMAS[/]");
                        result++;
                        continue;
                    }
                    AnsiConsole.MarkupLine($"[purple]NO XMAS found[/]");
                }
            }
            return result;
        }

        internal static int Test2(List<string> input)
        {
            var result = 0;
            var grid = new Businesslogic.Locations.Grid<char>();
            grid.Parse(input.Select(i => i.ToList()).ToList());
            foreach (var coord in grid.All)
            {
                // Get the middle of the cross
                var cell = grid.GetValue(coord.x, coord.y);
                if (cell != 'A')
                {
                    continue;
                }
                AnsiConsole.MarkupLine($"Found ajoining A at [red]{coord.y},{coord.x}[/]");

                var ajoining = grid.GetAdjoiningCross(coord.x, coord.y);

                // A cross should contain two M and two S
                if (ajoining.Count(i => i.Value == 'M') != 2 || ajoining.Count(i => i.Value == 'S') != 2)
                {
                    AnsiConsole.MarkupLine($"[purple]NO MAS found[/]");
                    continue;
                }
                
                // Just for debugging
                foreach (var item in ajoining.Where(i => i.Value == 'M'))
                {
                    AnsiConsole.MarkupLine($"Found ajoining M at [red]{item.Y},{item.X}[/]");
                }
                foreach (var item in ajoining.Where(i => i.Value == 'S'))
                {
                    AnsiConsole.MarkupLine($"Found ajoining S at [red]{item.Y},{item.X}[/]");
                }

                // Make sure that one M has an opposite with a S
                var firstM = ajoining.First(i => i.Value == 'M');
                var directionX = (firstM.X - coord.x) * -1;
                var directionY = (firstM.Y - coord.y) * -1;
                var opposite = grid.GetValue(coord.x + directionX, coord.y + directionY);
                AnsiConsole.MarkupLine($"Found ajoining {opposite} at [red]{coord.y + directionY},{coord.x + directionX}[/]");
                if (opposite != 'S')
                {
                    AnsiConsole.MarkupLine($"[purple]NO MAS found[/]");
                    continue;
                }
                AnsiConsole.MarkupLine($"[lime]Found MAS[/]");
                result++;
            }
            return result;
        }
    }
}
