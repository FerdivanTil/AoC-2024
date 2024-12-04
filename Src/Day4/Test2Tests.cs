namespace Day4;

public class Test2Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test2(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test2SampleResult);
    }
}
