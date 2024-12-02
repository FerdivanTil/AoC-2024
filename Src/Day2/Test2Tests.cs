using static Day2.Test1Tests;

namespace Day2;

public class Test2Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test2(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test2SampleResult);
    }

    [Theory]
    [MemberData(nameof(TestData.Step1), MemberType = typeof(TestData))]
    public void TestStep1(string input, bool result)
    {
        // arrange
        // act
        var lines = Program.ParseLine(input);
        var output = Program.IsSave2(lines.ToList());
        // assert
        output.Should().Be(result);
    }

    internal static class TestData
    {
        public static IEnumerable<object[]> Step1()
        {
            yield return new object[] { "74 73 74 75 78", true };
            yield return new object[] { "87 90 92 95 96 93", true };
            yield return new object[] { "7 6 4 2 1", true };
            yield return new object[] { "1 2 7 8 9", false };
            yield return new object[] { "9 7 6 2 1", false };
            yield return new object[] { "1 3 2 4 5", true };
            yield return new object[] { "8 6 4 4 1", true };
            yield return new object[] { "1 3 6 7 9", true };
        }
    }
}
