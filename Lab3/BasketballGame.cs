class BasketballGame : SportGame
{
    /// <summary>
    /// redistributes the playgame method from SportGame class
    /// </summary>
    /// <returns></returns>
    public override string PlayGame()
    {
        return "Rules of basketball: Two teams of 5 players each, the goal is to score by throwing the ball into the opponent's hoop.";
    }
}