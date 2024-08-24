using AoC.Input;

namespace AoC.Test.Input;

/// <summary>
/// Unit tests for <see cref="InputExtensions"/>.
/// </summary>
public class InputExtensionsTest
{
    [Theory]
    [InlineData("123,456", ",", 123, 456)]
    [InlineData("-123::456", "::", -123, 456)]
    [InlineData("   -123 ::::    456  ::::", "::", -123, 456)]
    [InlineData("   -123 ::    456  ::789", "::", -123, 456)]
    public void ToLongPosition_ReturnsCorrectValue(string sut, string delim, long expectedX, long expectedY)
    {
        // act
        var result = sut.ToLongPosition(delim);

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData("123,456", ",", 123, 456)]
    [InlineData("-123::456", "::", -123, 456)]
    [InlineData("   -123 ::::    456  ::::", "::", -123, 456)]
    [InlineData("   -123 ::    456  ::789", "::", -123, 456)]
    public void ToPosition_ReturnsCorrectValue(string sut, string delim, int expectedX, int expectedY)
    {
        // act
        var result = sut.ToPosition(delim);

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData("123.123,456.456", ",", 123.123, 456.456)]
    [InlineData("-123.123::456", "::", -123.123, 456)]
    [InlineData("   -123.456 ::::    456.123  ::::", "::", -123.456, 456.123)]
    [InlineData("   -123 ::    456  ::789", "::", -123, 456)]
    public void ToVector2_ReturnsCorrectValue(string sut, string delim, float expectedX, float expectedY)
    {
        // act
        var result = sut.ToVector2(delim);

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData("123.123,456.456,789.789", ",", 123.123, 456.456, 789.789)]
    [InlineData("-123.123::456::789.789", "::", -123.123, 456, 789.789)]
    [InlineData("   -123.456 ::::    456.123  ::::789", "::", -123.456, 456.123, 789)]
    [InlineData("   -123 ::    456  ::789", "::", -123, 456, 789)]
    public void ToVector3_ReturnsCorrectValue(string sut, string delim, float expectedX, float expectedY, float expectedZ)
    {
        // act
        var result = sut.ToVector3(delim);

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
        Assert.Equal(expectedZ, result.Z);
    }
}
