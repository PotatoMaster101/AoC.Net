using System.Numerics;

namespace AoC.Grid;

/// <summary>
/// Represents a 2D position in a grid system.
/// </summary>
/// <param name="X">The X position.</param>
/// <param name="Y">The Y position.</param>
/// <typeparam name="T">The type of the axis.</typeparam>
public readonly record struct Position<T>(T X = default, T Y = default)
    : IAdditionOperators<Position<T>, Position<T>, Position<T>>,
      IComparable<Position<T>>,
      IComparisonOperators<Position<T>, Position<T>, bool>,
      IDivisionOperators<Position<T>, T, Position<T>>,
      IMultiplyOperators<Position<T>, T, Position<T>>,
      ISubtractionOperators<Position<T>, Position<T>, Position<T>>,
      IUnaryNegationOperators<Position<T>, Position<T>>
    where T: struct, IBinaryInteger<T>
{
    /// <summary>
    /// Gets the origin point.
    /// </summary>
    public static readonly Position<T> Origin = new();

    /// <inheritdoc />
    public int CompareTo(Position<T> other)
    {
        var xCompare = X.CompareTo(other.X);
        return xCompare == 0 ? Y.CompareTo(other.Y) : xCompare;
    }

    /// <summary>
    /// Gets the destination position.
    /// </summary>
    /// <param name="direction">The direction to travel.</param>
    /// <param name="distance">The distance to destination.</param>
    /// <returns>The destination position.</returns>
    public Position<T> GetDestination(Direction direction, T distance)
    {
        return direction switch
        {
            Direction.Down => this with { Y = Y - distance },
            Direction.Left => this with { X = X - distance },
            Direction.Right => this with { X = X + distance },
            _ => this with { Y = Y + distance },
        };
    }

    /// <summary>
    /// Gets the neighbour positions.
    /// </summary>
    /// <param name="distance">The distance to neighbour positions.</param>
    /// <returns>The neighbour positions.</returns>
    public Position<T>[] GetNeighbours(T distance)
    {
        return
        [
            this with { X = X + distance },
            this with { X = X - distance },
            this with { Y = Y + distance },
            this with { Y = Y - distance },
        ];
    }

    /// <summary>
    /// Gets a position with the X and Y swapped.
    /// </summary>
    /// <returns>A position with the X and Y swapped.</returns>
    public Position<T> Swap()
    {
        return new Position<T>(Y, X);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    /// <inheritdoc />
    public static Position<T> operator +(Position<T> left, Position<T> right)
    {
        return new Position<T>(left.X + right.X, left.Y + right.Y);
    }

    /// <inheritdoc />
    public static Position<T> operator -(Position<T> left, Position<T> right)
    {
        return new Position<T>(left.X - right.X, left.Y - right.Y);
    }

    /// <inheritdoc />
    public static Position<T> operator -(Position<T> value)
    {
        return new Position<T>(-value.X, -value.Y);
    }

    /// <inheritdoc />
    public static Position<T> operator *(Position<T> left, T right)
    {
        return new Position<T>(left.X * right, left.Y * right);
    }

    /// <inheritdoc />
    public static Position<T> operator /(Position<T> left, T right)
    {
        return new Position<T>(left.X / right, left.Y / right);
    }

    /// <inheritdoc />
    public static bool operator >(Position<T> left, Position<T> right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <inheritdoc />
    public static bool operator >=(Position<T> left, Position<T> right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <inheritdoc />
    public static bool operator <(Position<T> left, Position<T> right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <inheritdoc />
    public static bool operator <=(Position<T> left, Position<T> right)
    {
        return left.CompareTo(right) <= 0;
    }
}
