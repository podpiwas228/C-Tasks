class Program
{
    /// <summary>
    /// Main code, which demonsrtates work class
    /// </summary>
    /// <param name="args"></param>
    static public void Main(string[] args)
    {
        SportGame football = new FootballGame();
        Console.WriteLine($"{football.PlayGame()}");

        SportGame basketball = new BasketballGame();
        Console.WriteLine($"{basketball.PlayGame()}");

        SportGame tennis = new TennisGame();
        Console.WriteLine($"{tennis.PlayGame()}");
    }
}
