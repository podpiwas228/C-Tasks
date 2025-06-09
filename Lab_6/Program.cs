/// <summary>
/// Entry point of the program.
/// </summary>
class Program
{
    /// <summary>
    /// Main method: reads, displays, and processes shapes from file.
    /// </summary>
    static void Main(string[] args)
    {
        UserInteraction ui = new UserInteraction();
        string filePath = "shapes.txt";

        List<Shape> shapes = ui.ReadShapesFromFile(filePath);
        ui.DisplayShapes(shapes);
        ui.CalculatePerimetersInSecondQuadrant(shapes);
    }
}
