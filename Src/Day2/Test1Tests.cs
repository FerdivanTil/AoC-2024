namespace Day2;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test1SampleResult);
    }

    [Theory]
    [MemberData(nameof(TestData.Step1), MemberType = typeof(TestData))]
    public void TestStep1(string input, List<int> result)
    {
        // arrange
        // act
        var output = Program.ParseLine(input);
        // assert
        output.Should().BeEquivalentTo(result);
    }

    [Theory]
    [MemberData(nameof(TestData.Step2), MemberType = typeof(TestData))]
    public void TestStep2(string input, bool result)
    {
        // arrange
        // act
        var lines = Program.ParseLine(input);
        var output = Program.IsIncreasingOrDecreasing(lines);
        // assert
        output.Should().Be(result);
    }

    [Theory]
    [MemberData(nameof(TestData.Step3), MemberType = typeof(TestData))]
    public void TestStep3(string input, bool result)
    {
        // arrange
        // act
        var lines = Program.ParseLine(input);
        var output = Program.IsSave(lines.ToList());
        // assert
        output.Should().Be(result);
    }

    internal static class TestData
    {
        public static IEnumerable<object[]> Step1()
        {
            yield return new object[] { "7 6 4 2 1", new List<int> { 7, 6, 4, 2, 1 } };
        }

        public static IEnumerable<object[]> Step2()
        {
            yield return new object[] { "7 6 4 2 1", true };
            yield return new object[] { "1 2 7 8 9", true };
            yield return new object[] { "9 7 6 2 1", true };
            yield return new object[] { "1 3 2 4 5", false };
            yield return new object[] { "8 6 4 4 1", true };
            yield return new object[] { "1 3 6 7 9", true };
        }

        public static IEnumerable<object[]> Step3()
        {
            yield return new object[] { "7 6 4 2 1", true };
            yield return new object[] { "1 2 7 8 9", false };
            yield return new object[] { "9 7 6 2 1", false };
            yield return new object[] { "1 3 2 4 5", true };
            yield return new object[] { "8 6 4 4 1", false };
            yield return new object[] { "1 3 6 7 9", true };
        }
    }
}
