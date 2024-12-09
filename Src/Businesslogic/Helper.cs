using Businesslogic.Attributes;
using Businesslogic.Enums;
using Businesslogic.Extensions;
using System.Diagnostics;
using System.Text;

namespace Businesslogic
{
    public static class Helper
    {
        public static List<string> GetFileContents(FileType fileType)
        {
            var filename = fileType.GetAttributeOfType<FileNameAttribute>().FileName;
            var text = System.IO.File.ReadAllText(filename);
            return [.. text.Split(Environment.NewLine)];
        }

        public static void WriteResult(Func<List<string>,int> func, FileType fileType, int result = 0)
        {
            WriteResult((x) => func(x).ToString(), fileType, result.ToString());
        }

        public static void WriteResult(Func<List<string>, string> func, FileType fileType, string result)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result1Test = func(GetFileContents(fileType));
            stopwatch.Stop();
            AnsiConsole.MarkupLine($"Result of {fileType} is: [red]{result1Test}[/]");
            if (result == "0")
            {
                AnsiConsole.MarkupLine($"Result took [aqua]{stopwatch.ElapsedMilliseconds}[/] ms");
                return;
            }

            var resultString = new StringBuilder();
            resultString.Append(result).Append(" == ").Append(result1Test);
            resultString.Append(result == result1Test ? " [lime]CORRECT[/]" : " [red]INCORRECT[/]");

            AnsiConsole.MarkupLine($"Result of {fileType} is: {resultString}");
        }

        public static void WriteResult(Func<List<string>, long> func, FileType fileType, int result = 0)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            WriteResult((x) => func(x).ToString(), fileType, result.ToString());
            stopwatch.Stop();
            AnsiConsole.MarkupLine($"Result took [aqua]{stopwatch.ElapsedMilliseconds}[/] ms");
        }
    }
}
