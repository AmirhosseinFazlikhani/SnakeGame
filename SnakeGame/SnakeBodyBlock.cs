namespace SnakeGame;

public class SnakeBodyBlock
{
    public SnakeBodyBlock(Point position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public Point Position { get; }

    public Direction Direction { get; }
}