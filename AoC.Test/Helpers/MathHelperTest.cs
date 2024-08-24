using AoC.Helpers;

namespace AoC.Test.Helpers;

/// <summary>
/// Unit tests for <see cref="MathHelper"/>.
/// </summary>
public class MathHelperTest
{
    [Theory]
    [InlineData(0L)]
    [InlineData(16409L, 16409L)]
    [InlineData(269L, 16409L, 19637L, 18023L, 15871L, 14257L, 12643L)]
    public void Gcd_List_ReturnsCorrectValue(long expected, params long[] input)
    {
        // act
        var result = MathHelper.Gcd(input);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(8, 16, 8)]
    [InlineData(7, 16, 1)]
    public void Gcd_ReturnsCorrectValue(int a, int b, int expected)
    {
        // act
        var result = MathHelper.Gcd(a, b);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0L)]
    [InlineData(16409L, 16409L)]
    [InlineData(11795205644011L, 16409L, 19637L, 18023L, 15871L, 14257L, 12643L)]
    public void Lcm_List_ReturnsCorrectValue(long expected, params long[] input)
    {
        // act
        var result = MathHelper.Lcm(input);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(8, 16, 16)]
    [InlineData(12, 15, 60)]
    public void Lcm_ReturnsCorrectValue(long a, long b, long expected)
    {
        // act
        var result = MathHelper.Lcm(a, b);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(0, -1, -1, 0)]
    [InlineData(-1, 0, -1, 0)]
    [InlineData(0, 1, 0, 1)]
    [InlineData(1, 0, 0, 1)]
    public void MinMax(long a, long b, long expectedMin, long expectedMax)
    {
        // act
        var result = MathHelper.MinMax(a, b);

        // assert
        Assert.Equal(expectedMin, result.Min);
        Assert.Equal(expectedMax, result.Max);
    }

    [Theory]
    [InlineData(10, 5, 0)]
    [InlineData(5, 2, 1)]
    [InlineData(-10, -5, 0)]
    [InlineData(-5, -9, -5)]
    [InlineData(-9, -5, -4)]
    public void Mod_ReturnsCorrectValue(long a, long b, long expected)
    {
        // act
        var result = MathHelper.Mod(a, b);

        // assert
        Assert.Equal(expected, result);
    }
}
