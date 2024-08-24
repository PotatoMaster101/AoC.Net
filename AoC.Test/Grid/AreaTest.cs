using System.Collections;
using AoC.Grid;

namespace AoC.Test.Grid;

/// <summary>
/// Unit tests for <see cref="Area{T}"/>.
/// </summary>
public class AreaTest
{
    [Theory]
    [InlineData(10, 10, 0, 0, 0, 0)]
    [InlineData(3, 4, -5, -6, -5, -6)]
    [InlineData(0, 0, 0, 0, 0, 0)]
    public void BottomLeft_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.BottomLeft;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(10, 10, 0, 0, 10, 0)]
    [InlineData(3, 4, -5, -6, 3, -6)]
    [InlineData(0, 0, 0, 0, 0, 0)]
    public void BottomRight_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.BottomRight;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(10, 10, 0, 0)]
    [InlineData(1, 1, 0, 0)]
    [InlineData(0, 0, -1, -1)]
    [InlineData(10, 10, -10, -10)]
    [InlineData(0, 1, 0, 0)]
    [InlineData(1, 0, 0, 0)]
    [InlineData(0, 0, 0, 0)]
    public void Constructor_SetsMembers(int maxX, int maxY, int minX, int minY)
    {
        // act
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // assert
        Assert.Equal(maxX, sut.MaxX);
        Assert.Equal(maxY, sut.MaxY);
        Assert.Equal(minX, sut.MinX);
        Assert.Equal(minY, sut.MinY);
    }

    [Theory]
    [InlineData(10, -1, 0, 0)]
    [InlineData(-1, 10, 0, 0)]
    [InlineData(-1, -1, 0, 0)]
    public void Constructor_ThrowsOnOutOfRange(int maxX, int maxY, int minX, int minY)
    {
        // assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Area<int>(maxX, maxY, minX, minY));
    }

    [Theory]
    [ClassData(typeof(GetColumnTestData))]
    public void GetColumn_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int x, Position<int>[] expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.GetColumn(x).ToList();

        // assert
        Assert.Equal(expected.Length, result.Count);
        foreach (var item in result)
            Assert.Contains(expected, p => p == item);
    }

    [Theory]
    [ClassData(typeof(GetEnumeratorTestData))]
    public void GetEnumerator_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, Position<int>[] expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.ToList();

        // assert
        Assert.Equal(expected.Length, result.Count);
        foreach (var item in result)
            Assert.Contains(expected, p => p == item);
    }

    [Theory]
    [ClassData(typeof(GetNeighboursTestData))]
    public void GetNeighbours_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int x, int y, int distance, Position<int>[] expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);
        var center = new Position<int>(x, y);

        // act
        var result = sut.GetNeighbours(center, distance);

        // assert
        Assert.Equal(expected.Length, result.Count);
        foreach (var item in result)
            Assert.Contains(expected, p => p == item);
    }

    [Theory]
    [ClassData(typeof(GetRowTestData))]
    public void GetRow_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int x, Position<int>[] expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.GetRow(x).ToList();

        // assert
        Assert.Equal(expected.Length, result.Count);
        foreach (var item in result)
            Assert.Contains(expected, p => p == item);
    }

    [Theory]
    [InlineData(10, 10, -10, -10, 10, 10, -10, -10, true)]
    [InlineData(10, 10, -10, -10, 5, 5, 0, 0, true)]
    [InlineData(10, 10, -10, -10, 0, 0, -5, -5, true)]
    [InlineData(10, 10, -10, -10, 11, 10, -10, -10, false)]
    [InlineData(10, 10, -10, -10, 10, 11, -10, -10, false)]
    [InlineData(10, 10, -10, -10, 10, 10, -11, -10, false)]
    [InlineData(10, 10, -10, -10, 10, 10, -10, -11, false)]
    public void HasArea_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int subMaxX, int subMaxY, int subMinX, int subMinY, bool expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);
        var sub = new Area<int>(subMaxX, subMaxY, subMinX, subMinY);

        // act
        var result = sut.Has(sub);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, 0, 0, 0, 0, true)]
    [InlineData(10, 10, 0, 0, 5, 5, true)]
    [InlineData(10, 10, 0, 0, 10, 10, true)]
    [InlineData(10, 10, 0, 0, 11, 11, false)]
    [InlineData(10, 10, 0, 0, -1, -1, false)]
    [InlineData(0, 0, 0, 0, 0, 0, true)]
    [InlineData(0, 0, 0, 0, 1, 0, false)]
    public void HasPosition_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int x, int y, bool expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);
        var pos = new Position<int>(x, y);

        // act
        var result = sut.Has(pos);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, -10, -10, 10, 10, -10, -10, true)]
    [InlineData(10, 10, -10, -10, 5, 5, 0, 0, true)]
    [InlineData(10, 10, -10, -10, 0, 0, -5, -5, true)]
    [InlineData(10, 10, -10, -10, 11, 10, -10, -10, true)]
    [InlineData(10, 10, -10, -10, 10, 11, -10, -10, true)]
    [InlineData(10, 10, -10, -10, 10, 10, -11, -10, true)]
    [InlineData(10, 10, -10, -10, 10, 10, -10, -11, true)]
    [InlineData(10, 10, -10, -10, 100, 100, -100, -100, true)]
    [InlineData(10, 10, 0, 0, -1, -1, -10, -10, false)]
    [InlineData(10, 10, 0, 0, -1, 10, -10, 0, false)]
    [InlineData(10, 10, 0, 0, 10, -1, 0, -10, false)]
    [InlineData(0, 0, 0, 0, 0, 0, 0, 0, true)]
    public void Intersects_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int subMaxX, int subMaxY, int subMinX, int subMinY, bool expected)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);
        var sub = new Area<int>(subMaxX, subMaxY, subMinX, subMinY);

        // act
        var result = sut.Intersects(sub);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, 0, 0, 0, 10)]
    [InlineData(3, 4, -5, -6, -5, 4)]
    [InlineData(0, 0, 0, 0, 0, 0)]
    public void TopLeft_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.TopLeft;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(10, 10, 0, 0, 10, 10)]
    [InlineData(3, 4, -5, -6, 3, 4)]
    [InlineData(0, 0, 0, 0, 0, 0)]
    public void TopRight_ReturnsCorrectValue(int maxX, int maxY, int minX, int minY, int expectedX, int expectedY)
    {
        // arrange
        var sut = new Area<int>(maxX, maxY, minX, minY);

        // act
        var result = sut.TopRight;

        // assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    /// <summary>
    /// Test data for <see cref="Area{T}.GetColumn"/>.
    /// </summary>
    private class GetColumnTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [2, 2, 0, 0, 0, new Position<int>[] { new(), new(0, 1), new(0, 2) }];
            yield return [1, 2, -3, -4, 1, new Position<int>[] { new(1, -4), new(1, -3), new(1, -2), new(1, -1), new(1), new(1, 1), new(1, 2) }];
            yield return [1, 2, -3, -4, -2, new Position<int>[] { new(-2, -4), new(-2, -3), new(-2, -2), new(-2, -1), new(-2), new(-2, 1), new(-2, 2) }];
            yield return [1, 2, -3, -4, 100, Array.Empty<Position<int>>()];
            yield return [1, 2, -3, -4, -100, Array.Empty<Position<int>>()];
            yield return [0, 0, 0, 0, 0, new Position<int>[] { new() }];
        }
    }

    /// <summary>
    /// Test data for <see cref="Area{T}.GetEnumerator"/>.
    /// </summary>
    private class GetEnumeratorTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                2, 2, 0, 0, new Position<int>[] { new(0), new(1), new(2), new(0, 1), new(1, 1), new(2, 1), new(0, 2), new(1, 2), new(2, 2) }
            ];
            yield return
            [
                0, 0, -2, -2, new Position<int>[] { new(-2, -2), new(-1, -2), new(0, -2), new(-2, -1), new(-1, -1), new(0, -1), new(-2), new(-1), new(0) }
            ];
            yield return
            [
                0, 0, 0, 0, new Position<int>[] { new() }
            ];
        }
    }

    /// <summary>
    /// Test data for <see cref="Area{T}.GetNeighbours"/>.
    /// </summary>
    private class GetNeighboursTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [2, 2, 0, 0, 0, 0, 1, new Position<int>[] { new(1), new(0, 1) }];
            yield return [2, 2, 0, 0, 1, 1, 1, new Position<int>[] { new(1), new(0, 1), new(2, 1), new(1, 2) }];
            yield return [2, 2, 0, 0, 1, 1, 100, Array.Empty<Position<int>>()];
            yield return [2, 2, 0, 0, 0, -1, 1, new Position<int>[] { new() }];
            yield return [0, 0, 0, 0, 0, 0, 1, Array.Empty<Position<int>>()];
        }
    }

    /// <summary>
    /// Test data for <see cref="Area{T}.GetRow"/>.
    /// </summary>
    private class GetRowTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [2, 2, 0, 0, 0, new Position<int>[] { new(), new(1), new(2) }];
            yield return [1, 2, -3, -4, 1, new Position<int>[] { new(-3, 1), new(-2, 1), new(-1, 1), new(0, 1), new(1, 1) }];
            yield return [1, 2, -3, -4, -2, new Position<int>[] { new(-3, -2), new(-2, -2), new(-1, -2), new(0, -2), new(1, -2) }];
            yield return [1, 2, -3, -4, 100, Array.Empty<Position<int>>()];
            yield return [1, 2, -3, -4, -100, Array.Empty<Position<int>>()];
            yield return [0, 0, 0, 0, 0, new Position<int>[] { new() }];
        }
    }
}
