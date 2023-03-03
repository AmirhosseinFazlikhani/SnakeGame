namespace SnakeGame;

class Program
{
    public static void Main(string[] args)
    {
        StartGame();
    }

    private static void StartGame()
    {
        var snake = new Snake(new Point(3, 3));
        snake.WhenDead(GameOver);
        var playground = new Playground(40, 20, 2);

        while (playground.IsValid(snake.Head.Position))
        {
            snake.Move();

            if (playground.FoodExists(snake.Points))
            {
                snake.Eat(playground.Food);
                playground.NewFood();
                ShowScore(snake);
            }
        }

        snake.Kill();
    }

    private static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.ReadLine();
    }

    private static void ShowScore(Snake snake)
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.WriteLine("Score: {0}", snake.Score);
    }
}