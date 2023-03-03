namespace SnakeGame;

public interface Food
{
    int Score { get; }

    char Char { get; }

    Point Position { get; }
}

public class Apple : Food
{
    public Apple(Point position)
    {
        Position = position;
        Score = 1;
        Char = 'A';
    }

    public int Score { get; }
    
    public char Char { get; }
    
    public Point Position { get; }
}

public class Banana : Food
{
    public Banana(Point position)
    {
        Position = position;
        Score = 2;
        Char = 'B';
    }
    
    public int Score { get; }
    
    public char Char { get; }
    
    public Point Position { get; }
}