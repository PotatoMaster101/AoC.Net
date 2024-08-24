using System.Collections;
using AoC.Grid;

namespace AoC.Test.Grid;

/// <summary>
/// Unit tests for <see cref="Position{T}"/>.
/// </summary>
public class PositionTest
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(0, 0, 1, 1, -1)]
    [InlineData(0, 0, 1, 0, -1)]
    [InlineData(0, 0, 0, 1, -1)]
    [InlineData(1, 1, 0, 0, 1)]
    [InlineData(1, 0, 0, 0, 1)]
    [InlineData(0, 1, 0, 0, 1)]
    public void CompareTo_ReturnsCorrectValue(int x1, int y1, int x2, int y2, int expected)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var another = new Position<int>(x2, y2);

        // act
        var result = sut.CompareTo(another);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 10, 0, 10)]
    [InlineData(0, 0, Direction.Down, 10, 0, -10)]
    [InlineData(0, 0, Direction.Left, 10, -10, 0)]
    [InlineData(0, 0, Direction.Right, 10, 10, 0)]
    [InlineData(0, 0, Direction.Up, -10, 0, -10)]
    [InlineData(0, 0, Direction.Down, -10, 0, 10)]
    [InlineData(0, 0, Direction.Left, -10, 10, 0)]
    [InlineData(0, 0, Direction.Right, -10, -10, 0)]
    public void GetDestination_ReturnsCorrectValue(int x, int y, Direction direction, int distance, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut.GetDestination(direction, distance);

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [ClassData(typeof(GetNeighboursTestData))]
    public void GetNeighbours_ReturnsCorrectValue(int x, int y, int distance, Position<int>[] expected)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut.GetNeighbours(distance);

        // assert
        Assert.Equal(expected.Length, result.Length);
        foreach (var item in result)
            Assert.Contains(expected, p => p == item);
    }

    [Theory]
    [InlineData(0, 0, 1, 1, 0 + 1, 0 + 1)]
    [InlineData(-1, -1, 1, 1, -1 + 1, -1 + 1)]
    [InlineData(1, 2, 3, 4, 1 + 3, 2 + 4)]
    [InlineData(100, 250, 300, 450, 100 + 300, 250 + 450)]
    public void OperatorAdd_ReturnsCorrectValue(int x1, int y1, int x2, int y2, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut + right;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(10, 10, 5, 10 / 5, 10 / 5)]
    [InlineData(-10, -10, 5, -10 / 5, -10 / 5)]
    [InlineData(125, -520, 5, 125 / 5, -520 / 5)]
    public void OperatorDivide_ReturnsCorrectValue(int x, int y, int right, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut / right;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, false)]
    [InlineData(0, 0, 1, 1, false)]
    [InlineData(0, 0, 1, 0, false)]
    [InlineData(0, 0, 0, 1, false)]
    [InlineData(1, 1, 0, 0, true)]
    [InlineData(1, 0, 0, 0, true)]
    [InlineData(0, 1, 0, 0, true)]
    public void OperatorGreaterThan_ReturnsCorrectValue(int x1, int y1, int x2, int y2, bool expected)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut > right;

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, true)]
    [InlineData(0, 0, 1, 1, false)]
    [InlineData(0, 0, 1, 0, false)]
    [InlineData(0, 0, 0, 1, false)]
    [InlineData(1, 1, 0, 0, true)]
    [InlineData(1, 0, 0, 0, true)]
    [InlineData(0, 1, 0, 0, true)]
    public void OperatorGreaterThanOrEqualTo_ReturnsCorrectValue(int x1, int y1, int x2, int y2, bool expected)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut >= right;

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, false)]
    [InlineData(0, 0, 1, 1, true)]
    [InlineData(0, 0, 1, 0, true)]
    [InlineData(0, 0, 0, 1, true)]
    [InlineData(1, 1, 0, 0, false)]
    [InlineData(1, 0, 0, 0, false)]
    [InlineData(0, 1, 0, 0, false)]
    public void OperatorLessThan_ReturnsCorrectValue(int x1, int y1, int x2, int y2, bool expected)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut < right;

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, true)]
    [InlineData(0, 0, 1, 1, true)]
    [InlineData(0, 0, 1, 0, true)]
    [InlineData(0, 0, 0, 1, true)]
    [InlineData(1, 1, 0, 0, false)]
    [InlineData(1, 0, 0, 0, false)]
    [InlineData(0, 1, 0, 0, false)]
    public void OperatorLessThanOrEqualTo_ReturnsCorrectValue(int x1, int y1, int x2, int y2, bool expected)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut <= right;

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 1, 0 * 1, 0 * 1)]
    [InlineData(-1, -1, -1, -1 * -1, -1 * -1)]
    [InlineData(1, 2, 3, 1 * 3, 2 * 3)]
    [InlineData(100, 250, 999, 100 * 999, 250 * 999)]
    public void OperatorMultiply_ReturnsCorrectValue(int x, int y, int right, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut * right;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(-1, -1, 1, 1)]
    [InlineData(-1, 1, 1, -1)]
    [InlineData(1, -1, -1, 1)]
    [InlineData(1, 2, -1, -2)]
    public void OperatorNegate_ReturnsCorrectValue(int x, int y, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = -sut;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, 1, 1, 0 - 1, 0 - 1)]
    [InlineData(-1, -1, 1, 1, -1 - 1, -1 - 1)]
    [InlineData(1, 2, 3, 4, 1 - 3, 2 - 4)]
    [InlineData(100, 250, 300, 450, 100 - 300, 250 - 450)]
    public void OperatorSubtract_ReturnsCorrectValue(int x1, int y1, int x2, int y2, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x1, y1);
        var right = new Position<int>(x2, y2);

        // act
        var result = sut - right;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Fact]
    public void Origin_ReturnsCorrectValue()
    {
        // act
        var result = Position<int>.Origin;

        // assert
        Assert.Equal(0, result.X);
        Assert.Equal(0, result.Y);
    }

    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(1, -1, -1, 1)]
    [InlineData(-1, 1, 1, -1)]
    public void Swap_ReturnsCorrectValue(int x, int y, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut.Swap();

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, "(0, 0)")]
    [InlineData(1, -1, "(1, -1)")]
    public void ToString_ReturnsCorrectValue(int x, int y, string expected)
    {
        // arrange
        var sut = new Position<int>(x, y);

        // act
        var result = sut.ToString();

        // assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test data for <see cref="Position{T}.GetNeighbours"/>.
    /// </summary>
    private class GetNeighboursTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                10, 10, 1, new Position<int>[]
                {
                    new(10, 11),
                    new(11, 10),
                    new(10, 9),
                    new(9, 10),
                }
            ];
            yield return
            [
                10, 10, 3, new Position<int>[]
                {
                    new(10, 13),
                    new(13, 10),
                    new(10, 7),
                    new(7, 10),
                }
            ];
            yield return
            [
                -10, -10, 3, new Position<int>[]
                {
                    new(-10, -13),
                    new(-13, -10),
                    new(-10, -7),
                    new(-7, -10),
                }
            ];
        }
    }
}
