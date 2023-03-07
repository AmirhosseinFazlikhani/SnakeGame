namespace SnakeGame;

public class Snake
{
    public int Score { get; private set; } = 0;

    public SnakeBodyBlock Head => _body.Last();

    public SnakeBodyBlock Tail => _body.First();

    private readonly List<SnakeBodyBlock> _body = new();

    public IEnumerable<Point> Points => _body.Select(b => b.Position);

    private (int horizontal, int vertical) GetNextStep(Direction direction)
    {
        return direction switch
        {
            Direction.Left => (-1, 0),
            Direction.Top => (0, -1),
            Direction.Right => (1, 0),
            Direction.Bottom => (0, 1),
            _ => (0, 0)
        };
    }

    private Direction _direction = Direction.Right;

    private int SpeedInMilliseconds => Direction is Direction.Bottom or Direction.Top ? 150 : 100;

    private Direction Direction
    {
        get => _direction;
        set
        {
            if (_direction == ~value)
            {
                return;
            }

            _direction = value;
        }
    }

    public Snake(Point initialPosition)
    {
        Task.Run(() =>
        {
            while (true)
            {
                Direction = Console.ReadKey().Key switch
                {
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.UpArrow => Direction.Top,
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.DownArrow => Direction.Bottom,
                    _ => Direction,
                };
            }
        });

        _body.Add(new SnakeBodyBlock(initialPosition, _direction));
        Appear(Head);
    }

    public void Move()
    {
        Thread.Sleep(SpeedInMilliseconds);

        var step = GetNextStep(Direction);

        _body.Add(new SnakeBodyBlock(
            Head.Position.Move(step.horizontal, step.vertical),
            _direction));

        if (HasCollision())
        {
            Kill();
        }

        Disappear(Tail);
        Appear(Head);
        
        _body.RemoveAt(0);
    }

    private bool HasCollision()
    {
        return _body.SkipLast(1).Any(b => b.Position.Equals(Head.Position));
    }

    private void Disappear(SnakeBodyBlock block)
    {
        Console.CursorLeft = block.Position.Left;
        Console.CursorTop = block.Position.Top;
        Console.Write(" ");
    }

    private void Appear(SnakeBodyBlock block)
    {
        Console.CursorLeft = block.Position.Left;
        Console.CursorTop = block.Position.Top;
        Console.Write("O");
    }

    public void Eat(Food food)
    {
        Score += food.Score;

        for (var i = 0; i < food.Score; i++)
        {
            var step = GetNextStep(Tail.Direction);

            _body.Insert(0, new SnakeBodyBlock(
                Tail.Position.Move(-step.horizontal, -step.vertical),
                Tail.Direction));
        }
    }

    public void Kill()
    {
        _whenDead();
    }

    private Action _whenDead = () => { };

    public void WhenDead(Action action)
    {
        _whenDead = action;
    }
}