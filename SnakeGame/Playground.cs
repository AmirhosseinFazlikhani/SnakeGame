namespace SnakeGame;

public class Playground
{
    public int Margin { get; }

    public int Width { get; }

    public int Height { get; }

    public Food Food { get; private set; }

    public Playground(int width, int height, int margin = 0)
    {
        Width = width;
        Height = height;
        Margin = margin;

        Console.Clear();
        Console.CursorTop = margin + 1;

        while (Console.CursorTop <= height + margin)
        {
            Console.CursorLeft = margin;
            Console.Write("|");
            Console.CursorLeft = width + margin;
            Console.Write("|");

            Console.CursorTop++;
        }

        Console.CursorLeft = margin + 1;

        while (Console.CursorLeft < width + margin)
        {
            Console.CursorTop = margin;
            Console.Write("_");
            Console.CursorTop = height + margin;
            Console.CursorLeft--;
            Console.Write("_");
        }

        NewFood();
    }

    public bool FoodExists(IEnumerable<Point> points)
    {
        return points.Contains(Food.Position);
    }

    public bool IsValid(Point point)
    {
        return point.Left > Margin
               && point.Left < Width + Margin
               && point.Top > Margin
               && point.Top < Height + Margin;
    }

    private readonly Random _random = new();

    public void NewFood()
    {
        var left = _random.Next(Margin + 1, Margin + Width);
        var top = _random.Next(Margin + 1, Margin + Height);

        var foods = Enumerable.Range(0, 3)
            .Select(_ => new Apple(new Point(left, top)) as Food)
            .Concat(Enumerable.Range(0, 2)
                .Select(_ => new Banana(new Point(left, top)) as Food))
            .ToArray();

        Food = foods[_random.Next(1, 5)];

        Console.CursorTop = top;
        Console.CursorLeft = left;
        Console.Write(Food.Char);
    }
}