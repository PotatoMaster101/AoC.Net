using AoC.Input;

namespace AoC.Test.Input;

/// <summary>
/// Unit tests for <see cref="InputReader"/>.
/// </summary>
public class InputReaderTest
{
    private const string FilePath = $"{nameof(InputReaderTest)}.txt";
    private readonly string[] _lines =
    [
        "abc",
        "",
        "def",
        "    ",
        "        ",
        "ghi",
        " ",
    ];

    public InputReaderTest()
    {
        File.WriteAllLines(FilePath, _lines);
    }

    [Theory]
    [InlineData(true, "abc", "def", "ghi")]
    [InlineData(false, "abc", "", "def", "    ", "        ", "ghi", " ")]
    public async Task ReadLines_ReturnsCorrectValue(bool skipEmpty, params string[] expected)
    {
        // act
        var lines = InputReader.ReadLines(FilePath, skipEmpty);

        // assert
        var result = await ToListAsync(lines);
        Assert.Equal(expected.Length, result.Count);
        foreach (var item in result)
            Assert.Contains(expected, l => l == item);
    }

    private static async Task<List<string>> ToListAsync(IAsyncEnumerable<string> enumerable)
    {
        var result = new List<string>();
        await foreach (var line in enumerable)
            result.Add(line);
        return result;
    }
}
