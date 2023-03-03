namespace SnakeGame;

public enum Direction
{
    Left,
    Top,
    Right = ~Left,
    Bottom = ~Top,
}