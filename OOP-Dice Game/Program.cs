Game.Start();
Console.ReadKey();
// 


class Game
{
    private static int correctNumber = DiceRoll.Rolling();
    private static int tries = 3;
    
    public static void Start()
    {
        Console.WriteLine("Whats up my guy lets play! A DICE GAME! 🎲");
        Console.WriteLine($"Cheater! : {correctNumber}");
        Iterate();
    }

    private static void Iterate()
    {
        if (tries == 0)
        {
            Console.WriteLine("Game over BOZO!");
            return;
        }
        Console.WriteLine("Enter a number:");
        gameLogic();
    }

    private static void gameLogic()
    {
        var inp = Console.ReadLine();
        var input = int.TryParse(inp, out int guess);
        if (!input)
        {
            Console.WriteLine("Not a Number BOZO!");
            Iterate();
            
        }
        else if (guess == correctNumber)
        {
            Correct();
        }
        else if (guess != correctNumber)
        {
            tries--;
            TryAgain(guess);
        }
    }
    private static void TryAgain(int guess)
    {
        var isBigger = guess > correctNumber ? true: false;
        if (isBigger)
        {
            Console.WriteLine("Lower!");
        }
        else
        {
            Console.WriteLine("Higher!");
            
        }
        Iterate();
    }

    private static void Correct()
    {
        Console.WriteLine("You Win!");
    }
}

class DiceRoll
{
    public static int Rolling()
    {
        Random rnd = new Random();
        return rnd.Next(1, 7);
    }
}