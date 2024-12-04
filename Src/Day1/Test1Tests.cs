namespace Day1;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test1SampleResult);
    }

    //[Theory]
    //[InlineData("input", "result")]
    //public void TestStep1(string input, string result)
    //{
    //    // arrange
    //    // act
    //    // assert
    //    input.Should().Be(result);
    //}
}
