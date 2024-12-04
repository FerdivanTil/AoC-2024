namespace Day4;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test1SampleResult);
    }
}
