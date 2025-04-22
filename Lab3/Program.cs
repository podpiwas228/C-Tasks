using System;

class Program
{
    /// <summary>
    /// Main code, which demonstrates the work of the class
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        UserInteraction ui;
        ui = new UserInteraction();

        SportGame football;
        football = new FootballGame();

        string footballMessage;
        footballMessage = football.PlayGame();

        ui.DisplayMessage(footballMessage);

        SportGame basketball;
        basketball = new BasketballGame();

        string basketballMessage;
        basketballMessage = basketball.PlayGame();

        ui.DisplayMessage(basketballMessage);

        SportGame tennis;
        tennis = new TennisGame();

        string tennisMessage;
        tennisMessage = tennis.PlayGame();

        ui.DisplayMessage(tennisMessage);
    }
}