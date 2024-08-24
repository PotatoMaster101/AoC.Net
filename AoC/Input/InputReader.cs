using System.Runtime.CompilerServices;

namespace AoC.Input;

/// <summary>
/// Methods for reading input.
/// </summary>
public static class InputReader
{
    /// <summary>
    /// Reads lines from a file.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="skipEmpty">Whether to skip empty lines.</param>
    /// <param name="token">The cancellation token for cancelling the operation.</param>
    /// <returns>The lines from the file.</returns>
    public static async IAsyncEnumerable<string> ReadLines(string path, bool skipEmpty = true, [EnumeratorCancellation] CancellationToken token = default)
    {
        using var reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync(token).ConfigureAwait(false);
            if (!skipEmpty || !string.IsNullOrWhiteSpace(line))
                yield return line ?? string.Empty;
        }
    }
}
