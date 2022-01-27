using Xunit;

namespace StringUtils.Tests;

public class StringExtensionsTests
{
    #region IsNullOrEmpty

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void IsNullOrEmpty_WhenNullOrEmpty_ShouldReturnTrue(string input)
    {
        Assert.True(input.IsNullOrEmpty());
    }

    [Fact]
    public void IsNullOrEmpty_WhenNotEmpty_ShouldReturnFalse()
    {
        const string input = "test string";
        Assert.False(input.IsNullOrEmpty());
    }

    #endregion

    #region ToUpper

    [Fact]
    public void ToUpper_WhenNull_ShouldThrowException()
    {
        const string input = null!;
#pragma warning disable CS8625
        var exception = Record.Exception(() => input.ToUpper(0));
#pragma warning restore CS8625
        Assert.NotNull(exception);
    }

    [Fact]
    public void ToUpper_WhenEmpty_ShouldReturnEmpty()
    {
        var empty = string.Empty;
        Assert.Equal(empty.ToUpper(0), empty);
    }

    [Theory]
    [InlineData("test string", 20)]
    [InlineData("test string", -20)]
    public void ToUpper_WhenOutOfIndex_ShouldReturnOriginal(string input, int index)
    {
        Assert.Equal(input.ToUpper(index), input);
    }

    [Fact]
    public void ToUpper_WhenFirst_ShouldReturnUpperFirst()
    {
        const string input = "test string";
        const string result = "Test string";

        Assert.Equal(input.ToUpper(0), result);
    }
    
    [Fact]
    public void ToUpper_WhenLast_ShouldReturnUpperLast()
    {
        const string input = "test string";
        const string result = "test strinG";

        Assert.Equal(input.ToUpper(-1), result);
    }

    [Fact]
    public void ToUpper_WhenMiddle_ShouldReturnUpperMiddle()
    {
        const string input = "test string";
        const string result = "test String";

        Assert.Equal(input.ToUpper(5), result);
    }

    [Fact]
    public void ToUpper_WhenOneCharString_ShouldReturnUpper()
    {
        const string input = "t";
        const string result = "T";

        Assert.Equal(input.ToUpper(0), result);
    }

    #endregion

    #region ToLower

    [Fact]
    public void ToLower_WhenNull_ShouldThrowException()
    {
        const string input = null!;
#pragma warning disable CS8625
        var exception = Record.Exception(() => input.ToLower(0));
#pragma warning restore CS8625
        Assert.NotNull(exception);
    }

    [Fact]
    public void ToLower_WhenEmpty_ShouldReturnEmpty()
    {
        var empty = string.Empty;
        Assert.Equal(empty.ToLower(0), empty);
    }

    [Theory]
    [InlineData("TEST STRING", 20)]
    [InlineData("TEST STRING", -20)]
    public void ToLower_WhenOutOfIndex_ShouldReturnOriginal(string input, int index)
    {
        Assert.Equal(input.ToLower(index), input);
    }

    [Fact]
    public void ToLower_WhenFirst_ShouldReturnUpperFirst()
    {
        const string input = "TEST STRING";
        const string result = "tEST STRING";

        Assert.Equal(input.ToLower(0), result);
    }

    [Fact]
    public void ToLower_WhenLast_ShouldReturnUpperLast()
    {
        const string input = "TEST STRING";
        const string result = "TEST STRINg";

        Assert.Equal(input.ToLower(-1), result);
    }

    [Fact]
    public void ToLower_WhenMiddle_ShouldReturnUpperMiddle()
    {
        const string input = "TEST STRING";
        const string result = "TEST sTRING";

        Assert.Equal(input.ToLower(5), result);
    }

    [Fact]
    public void ToLower_WhenOneCharString_ShouldReturnUpper()
    {
        const string input = "T";
        const string result = "t";

        Assert.Equal(input.ToLower(0), result);
    }

    #endregion
}
