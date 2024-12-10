namespace Day5;

public class Test2Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test2(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test2SampleResult);
    }

    [Theory]
    [MemberData(nameof(TestData.Step1), MemberType = typeof(TestData))]
    public void TestStep1(List<int> input, List<Program.Rule> rules, List<int> result)
    {
        // arrange
        // act
        var output = Program.ReOrder(input, rules);
        // assert
        output.Should().BeEquivalentTo(result, options => options.WithStrictOrdering());
    }
    public static class TestData
    {
        public static List<Program.Rule> GetRules() => new List<Program.Rule>
            {
                new (47,53),
                new (97,13),
                new (97,61),
                new (97,47),
                new (75,29),
                new (61,13),
                new (75,53),
                new (29,13),
                new (97,29),
                new (53,29),
                new (61,53),
                new (97,53),
                new (61,29),
                new (47,13),
                new (75,47),
                new (97,75),
                new (47,61),
                new (75,61),
                new (47,29),
                new (75,13),
                new (53,13),
            };

        public static IEnumerable<object[]> Step1()
        {
            yield return new object[] { new List<int> { 75, 97, 47, 61, 53 }, GetRules(), new List<int> { 97, 75, 47, 61, 53 } };
            yield return new object[] { new List<int> { 61, 13, 29 }, GetRules(), new List<int> { 61, 29, 13 } };
            yield return new object[] { new List<int> { 97, 13, 75, 29, 47 }, GetRules(), new List<int> { 97, 75, 47, 29, 13 } };
        }
    }
}
