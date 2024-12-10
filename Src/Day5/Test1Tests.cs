using System.Collections.Generic;

namespace Day5;

public class Test1Tests
{
    [Fact]
    public void TestSample()
    {
        Program.Test1(Helper.GetFileContents(FileType.Test1Sample)).Should().Be(Program.Test1SampleResult);
    }

    [Theory]
    [MemberData(nameof(TestData.Step1), MemberType = typeof(TestData))]
    public void TestStep1(List<string> input, List<List<int>> pages, List<Program.Rule> rules)
    {
        // arrange
        // act
        var result = Program.Parse(input);
        // assert
        result.rules.Should().BeEquivalentTo(rules);
        result.pages.Should().BeEquivalentTo(pages);
    }

    [Theory]
    [MemberData(nameof(TestData.Step2), MemberType = typeof(TestData))]
    public void TestStep2(List<int> input, List<Program.Rule> rules, bool result)
    {
        // arrange
        // act
        var output = Program.IsValid(input, rules);
        // assert
        output.Should().Be(result);
    }

    [Theory]
    [MemberData(nameof(TestData.Step3), MemberType = typeof(TestData))]
    public void TestStep3(List<int> input, int result)
    {
        // arrange
        // act
        var output = Program.GetMiddle(input);
        // assert
        output.Should().Be(result);
    }

    public static class TestData
    {
        public static IEnumerable<object[]> Step1()
        {
            yield return new object[]
            {
                new List<string>() { "47|53", "97|13", "", "75,47,61,53,29", "97,61,53,29,13" },
                new List<List<int>> { new() { 75, 47, 61, 53, 29 }, new() { 97, 61, 53, 29, 13 } },
                new List <Program.Rule> { new( 47, 53 ), new(97, 13) }
            };
        }
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

        public static IEnumerable<object[]> Step2()
        {
            yield return new object[] { new List<int> { 75, 47, 61, 53, 29 }, GetRules(), true };
            yield return new object[] { new List<int> { 97, 61, 53, 29, 13 }, GetRules(), true };
            yield return new object[] { new List<int> { 75, 97, 47, 61, 53 }, GetRules(), false };
            yield return new object[] { new List<int> { 61, 13, 29 }, GetRules(), false };
            yield return new object[] { new List<int> { 97, 13, 75, 29, 47 }, GetRules(), false };
            yield return new object[] { new List<int> { 75, 29, 13 }, GetRules(), true };
        }

        public static IEnumerable<object[]> Step3()
        {
            yield return new object[] { new List<int> { 75, 47, 61, 53, 29 }, 61 };
            yield return new object[] { new List<int> { 97, 61, 53, 29, 13 }, 53 };
            yield return new object[] { new List<int> { 75, 97, 47, 61, 53 }, 47 };
            yield return new object[] { new List<int> { 61, 13, 29 }, 13 };
            yield return new object[] { new List<int> { 97, 13, 75, 29, 47 }, 75 };
            yield return new object[] { new List<int> { 75, 29, 13 }, 29 };
        }
    }
}
