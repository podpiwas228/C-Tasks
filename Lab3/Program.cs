using System;

class Program
{
    /// <summary>
    /// Main code, which demonstrates the work of the class
    /// </summary>
    /// <param name="args"></param>
     public void Main(string[] args)
    {
        UserInteraction ui = new UserInteraction();

        SportGame football = new FootballGame();
        ui.DisplayMessage(football.PlayGame());

        SportGame basketball = new BasketballGame();
        ui.DisplayMessage(basketball.PlayGame());

        SportGame tennis = new TennisGame();
        ui.DisplayMessage(tennis.PlayGame());
    }
}