namespace SnakeGame;

public class Point : IEquatable<Point>
{
    public int Left { get; }

    public int Top { get; }

    public Point(int left, int top)
    {
        Left = left;
        Top = top;
    }

    public Point Move(int horizontal, int vertical)
    {
        return new Point(Left + horizontal, Top + vertical);
    }

    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Left == other.Left && Top == other.Top;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Left, Top);
    }
}