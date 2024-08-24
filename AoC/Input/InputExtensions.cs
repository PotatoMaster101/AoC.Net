using System.Globalization;
using System.Numerics;
using AoC.Grid;

namespace AoC.Input;

/// <summary>
/// Extension methods for parsing input.
/// </summary>
public static class InputExtensions
{
    /// <summary>
    /// Parses a string to a long <see cref="Position{T}"/>.
    /// </summary>
    /// <param name="str">The string containing the position.</param>
    /// <param name="delim">The elements delimiter.</param>
    /// <returns>The parsed long <see cref="Position{T}"/>.</returns>
    public static Position<long> ToLongPosition(this string str, string delim = ",")
    {
        var splits = str.Split(delim, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Position<long>(long.Parse(splits[0]), long.Parse(splits[1]));
    }

    /// <summary>
    /// Parses a string to an integer <see cref="Position{T}"/>.
    /// </summary>
    /// <param name="str">The string containing the position.</param>
    /// <param name="delim">The elements delimiter.</param>
    /// <returns>The parsed integer <see cref="Position{T}"/>.</returns>
    public static Position<int> ToPosition(this string str, string delim = ",")
    {
        var splits = str.Split(delim, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Position<int>(int.Parse(splits[0]), int.Parse(splits[1]));
    }

    /// <summary>
    /// Parses a string to a <see cref="Vector2"/>.
    /// </summary>
    /// <param name="str">The string containing the vector.</param>
    /// <param name="delim">The elements delimiter.</param>
    /// <returns>The parsed <see cref="Vector2"/>.</returns>
    public static Vector2 ToVector2(this string str, string delim = ",")
    {
        var splits = str.Split(delim, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Vector2(float.Parse(splits[0], CultureInfo.InvariantCulture), float.Parse(splits[1], CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Parses a string to a <see cref="Vector3"/>.
    /// </summary>
    /// <param name="str">The string containing the vector.</param>
    /// <param name="delim">The elements delimiter.</param>
    /// <returns>The parsed <see cref="Vector3"/>.</returns>
    public static Vector3 ToVector3(this string str, string delim = ",")
    {
        var splits = str.Split(delim, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return new Vector3(
            float.Parse(splits[0], CultureInfo.InvariantCulture),
            float.Parse(splits[1], CultureInfo.InvariantCulture),
            float.Parse(splits[2], CultureInfo.InvariantCulture));
    }
}
