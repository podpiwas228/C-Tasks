/// <summary>
/// The main entry point for the program, handling user interaction and transport selection.
/// </summary>
class Program
{
    static void Main()
    {
        UserInteraction userInteraction = new UserInteraction();
        userInteraction.GetHelloMessage();
        userInteraction.GetInput();
    }
}
