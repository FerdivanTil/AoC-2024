namespace Day3;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test1SampleResult);
    }

    [Theory]
    [MemberData(nameof(TestData.Step1), MemberType = typeof(TestData))]
    public void TestStep1(string input, List<Program.Value> result)
    {
        // arrange
        // act
        var output = Program.ParselLines(input);
        // assert
        output.Should().BeEquivalentTo(result);
    }

    public static class TestData
    {
        public static IEnumerable<object[]> Step1()
        {
            yield return new object[] { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", new List<Program.Value> { new(2,4,"mul"), new(5,5, "mul"), new(11,8, "mul"), new(8,5, "mul") } };
        }
    }
}
