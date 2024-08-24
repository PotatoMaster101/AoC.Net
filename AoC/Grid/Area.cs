using System.Collections;
using System.Numerics;

namespace AoC.Grid;

/// <summary>
/// Represents a grid area.
/// </summary>
public readonly record struct Area<T> : IEnumerable<Position<T>>
    where T: struct, IBinaryInteger<T>
{
    /// <summary>
    /// Gets the bottom left position of the area.
    /// </summary>
    public Position<T> BottomLeft => new(MinX, MinY);

    /// <summary>
    /// Gets the bottom right position of the area.
    /// </summary>
    public Position<T> BottomRight => new(MaxX, MinY);

    /// <summary>
    /// Gets the maximum X value.
    /// </summary>
    public T MaxX { get; }

    /// <summary>
    /// Gets the maximum Y value.
    /// </summary>
    public T MaxY { get; }

    /// <summary>
    /// Gets the minimum X value.
    /// </summary>
    public T MinX { get; }

    /// <summary>
    /// Gets the minimum Y value.
    /// </summary>
    public T MinY { get; }

    /// <summary>
    /// Gets the top left position of the area.
    /// </summary>
    public Position<T> TopLeft => new(MinX, MaxY);

    /// <summary>
    /// Gets the top right position of the area.
    /// </summary>
    public Position<T> TopRight => new(MaxX, MaxY);

    /// <summary>
    /// Constructs a new instance of <see cref="Area{T}"/>.
    /// </summary>
    /// <param name="maxX">The maximum X value.</param>
    /// <param name="maxY">The maximum Y value.</param>
    /// <param name="minX">The minimum X value.</param>
    /// <param name="minY">The minimum Y value.</param>
    public Area(T maxX, T maxY, T minX = default, T minY = default)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(minX, maxX);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(minY, maxY);

        MaxX = maxX;
        MaxY = maxY;
        MinX = minX;
        MinY = minY;
    }

    /// <summary>
    /// Gets a column in the area.
    /// </summary>
    /// <param name="x">The X position of the column.</param>
    /// <returns>A column in the area.</returns>
    public IEnumerable<Position<T>> GetColumn(T x)
    {
        if (x < MinX || x > MaxX)
            yield break;
        for (var y = MinY; y <= MaxY; y++)
            yield return new Position<T>(x, y);
    }

    /// <inheritdoc />
    public IEnumerator<Position<T>> GetEnumerator()
    {
        for (var x = MinX; x <= MaxX; x++)
        for (var y = MinY; y <= MaxY; y++)
            yield return new Position<T>(x, y);
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Gets the neighbour positions that are in this area.
    /// </summary>
    /// <param name="center">The center position.</param>
    /// <param name="distance">The distance to neighbours.</param>
    /// <returns>The neighbour positions that are in this area.</returns>
    public IReadOnlyList<Position<T>> GetNeighbours(Position<T> center, T distance)
    {
        var result = new List<Position<T>>(4);
        if (center.Y + distance <= MaxY && center.X >= MinX && center.X <= MaxX)
            result.Add(center with { Y = center.Y + distance });
        if (center.Y - distance >= MinY && center.X >= MinX && center.X <= MaxX)
            result.Add(center with { Y = center.Y - distance });
        if (center.X + distance <= MaxX && center.Y >= MinY && center.Y <= MaxY)
            result.Add(center with { X = center.X + distance });
        if (center.X - distance >= MinX && center.Y >= MinY && center.Y <= MaxY)
            result.Add(center with { X = center.X - distance });
        return result;
    }

    /// <summary>
    /// Gets a row in the area.
    /// </summary>
    /// <param name="y">The Y position of the row.</param>
    /// <returns>A row in this area.</returns>
    public IEnumerable<Position<T>> GetRow(T y)
    {
        if (y < MinY || y > MaxY)
            yield break;
        for (var x = MinX; x <= MaxX; x++)
            yield return new Position<T>(x, y);
    }

    /// <summary>
    /// Determines whether this area contains a specific position.
    /// </summary>
    /// <param name="position">The position to check.</param>
    /// <returns>Whether this area contains a specific position.</returns>
    public bool Has(Position<T> position)
    {
        return position.X >= MinX && position.X <= MaxX && position.Y >= MinY && position.Y <= MaxY;
    }

    /// <summary>
    /// Determines whether this area contains another area.
    /// </summary>
    /// <param name="another">The area to check.</param>
    /// <returns>Whether this area contains another area.</returns>
    public bool Has(Area<T> another)
    {
        return MaxX >= another.MaxX && MinX <= another.MinX && MaxY >= another.MaxY && MinY <= another.MinY;
    }

    /// <summary>
    /// Determines whether this area intersects another area.
    /// </summary>
    /// <param name="another">The area to check.</param>
    /// <returns>Whether this area intersects another area.</returns>
    public bool Intersects(Area<T> another)
    {
        return MinX <= another.MaxX && MaxX >= another.MinX && MinY <= another.MaxY && MaxY >= another.MinY;
    }
}
