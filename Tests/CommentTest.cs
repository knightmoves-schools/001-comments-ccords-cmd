namespace Tests;

using km__c_sharp__001_comments;
using Xunit;
using System.Text.RegularExpressions;

public class CommentTest
{
    [Fact]
    public void Should_Return_39()
    {
        var calculator = new TotalCalculator();
        var total = calculator.Calculate();

        Assert.Equal(39, total);
    }

    [Fact]
    public void Should_Contain_A_Single_Line_Comment_That_Comments_Out_Line_8()
    {
        string filePath = Path.Combine(Path.GetDirectoryName(typeof(TotalCalculator).Assembly.Location) ?? string.Empty, "../../../TotalCalculator.cs");

        Assert.True(File.Exists(filePath), "File does not exist");

        string content = File.ReadAllText(filePath);
        Regex rx = new Regex(@"\/\/.*total = total - 2;");

        Assert.True(rx.IsMatch(content), "File does not contain a single-line comment that comments out line 8 (total = total - 2;)");
    }

    [Fact]
    public void Should_Contain_A_Multiline_Comment_That_Comments_Out_Lines_10_11_And_12()
    {
        string filePath = Path.Combine(Path.GetDirectoryName(typeof(TotalCalculator).Assembly.Location) ?? string.Empty, "../../../TotalCalculator.cs");

        Assert.True(File.Exists(filePath), "File does not exist");

        string content = File.ReadAllText(filePath);
        Regex rx = new Regex(@"\/\*[\s\S]*?total = total - 4;[\s\S]*?total = total - 5;[\s\S]*?total = total - 6;[\s\S]*?\*\/");

        Assert.True(rx.IsMatch(content), "File does not contain a multi-line comment that comments out lines 10, 11, and 12 (`total = total - 4;`, `total = total - 5;`, and `total = total - 6;`)");
    }
}
