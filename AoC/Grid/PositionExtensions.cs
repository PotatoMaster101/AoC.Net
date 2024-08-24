namespace AoC.Grid;

/// <summary>
/// Extension methods for <see cref="Position{T}"/>.
/// </summary>
public static class PositionExtensions
{
    /// <summary>
    /// Returns a character in a specific position.
    /// </summary>
    /// <param name="grid">The grid containing the characters.</param>
    /// <param name="position">The position of the character.</param>
    /// <returns>The character in the specific position.</returns>
    public static char At(this IReadOnlyList<string> grid, Position<int> position)
    {
        return grid[position.Y][position.X];
    }

    /// <summary>
    /// Returns an element in a specific position.
    /// </summary>
    /// <param name="grid">The grid containing the elements.</param>
    /// <param name="position">The position of the element.</param>
    /// <returns>The element in the specific position.</returns>
    public static T At<T>(this IReadOnlyList<IReadOnlyList<T>> grid, Position<int> position)
    {
        return grid[position.Y][position.X];
    }
}
