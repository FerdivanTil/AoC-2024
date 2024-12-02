using Businesslogic.Attributes;
using Businesslogic.Enums;
using Businesslogic.Extensions;
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
            var result1Test = func(GetFileContents(fileType));
            AnsiConsole.WriteLine($"Result of {fileType} is: [red]{result1Test}[/]");
            if (result == "0")
            {
                return;
            }

            var resultString = new StringBuilder();
            resultString.Append(result).Append(" == ").Append(result1Test);
            resultString.Append(result == result1Test ? " [lime]CORRECT[/]" : " [red]INCORRECT[/]");

            AnsiConsole.WriteLine($"Result of {fileType} is: {resultString}");
        }

        public static void WriteResult(Func<List<string>, long> func, FileType fileType, int result = 0)
        {
            WriteResult((x) => func(x).ToString(), fileType, result.ToString());
        }
    }
}
