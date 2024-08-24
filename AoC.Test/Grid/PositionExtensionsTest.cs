using System.Collections;
using AoC.Grid;

namespace AoC.Test.Grid;

/// <summary>
/// Unit tests for <see cref="PositionExtensions"/>.
/// </summary>
public class PositionExtensionsTest
{
    [Theory]
    [InlineData(0, 0, 'a', "abc", "def")]
    [InlineData(1, 0, 'b', "abc", "def")]
    [InlineData(0, 1, 'd', "abc", "def")]
    [InlineData(2, 1, 'f', "abc", "def")]
    public void AtChar_ReturnsCorrectValue(int x, int y, char expected, params string[] sut)
    {
        // arrange
        var pos = new Position<int>(x, y);

        // act
        var result = sut.At(pos);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(AtTestData))]
    public void At_ReturnsCorrectValue(int x, int y, int expected, int[][] sut)
    {
        // arrange
        var pos = new Position<int>(x, y);

        // act
        var result = sut.At(pos);

        // assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test data for <see cref="PositionExtensions.At{T}"/>
    /// </summary>
    private class AtTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return
            [
                0, 0, 1, new int[][]
                {
                    [1, 2, 3],
                    [4, 5, 6],
                }
            ];
            yield return
            [
                1, 0, 2, new int[][]
                {
                    [1, 2, 3],
                    [4, 5, 6],
                }
            ];
            yield return
            [
                0, 1, 4, new int[][]
                {
                    [1, 2, 3],
                    [4, 5, 6],
                }
            ];
            yield return
            [
                2, 1, 6, new int[][]
                {
                    [1, 2, 3],
                    [4, 5, 6],
                }
            ];
        }
    }
}
