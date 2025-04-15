class Program
{
    private readonly UserInteraction ui;

    /// <summary>
    /// Initializes a new instance of the <see cref="Program"/> class and sets up user interaction.
    /// </summary>
    public Program()
    {
        ui = new UserInteraction();
    }

    /// <summary>
    /// Executes the main program logic: input handling, processing arrays, calculating results, and displaying output.
    /// </summary>
    public void Run()
    {
        try
        {
            var A = new ArrayClass(ui.GetArrayInput("A"));
            var B = new ArrayClass(ui.GetArrayInput("B"));
            int specifiedIndex = ui.GetIndexInput();

            int leftmostMinIndexB = B.Elements.IndexOf(B.Elements.Min());
            int rightmostMinIndexA = A.Elements.Count - 1 - A.Elements.LastIndexOf(A.Elements.Min());

            List<int> CElements = B.Elements.Skip(leftmostMinIndexB + 1).ToList();
            CElements.AddRange(A.Elements.Skip(rightmostMinIndexA).Take(specifiedIndex - rightmostMinIndexA));

            var C = new ArrayClass(CElements);

            int a = A.CalculateSpecialValue();
            int b = B.CalculateSpecialValue();
            int c = C.CalculateSpecialValue();

            double f = CalculateF(a, b, c);

            ui.ShowArray("A", A.Elements, a);
            ui.ShowArray("B", B.Elements, b);
            ui.ShowArray("C", C.Elements, c);
            ui.ShowFunctionResult(f);
        }
        catch (Exception ex)
        {
            ui.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Calculates a custom function value based on inputs a, b, and c.
    /// </summary>
    /// <param name="a">Special value from array A.</param>
    /// <param name="b">Special value from array B.</param>
    /// <param name="c">Special value from array C.</param>
    /// <returns>Result of the custom function.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the denominator (a + b) is zero.</exception>
    private double CalculateF(int a, int b, int c)
    {
        double numerator = 2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3);
        double denominator = a + b;

        if (denominator == 0)
            throw new DivideByZeroException("Denominator is zero!");

        return numerator / denominator;
    }

    /// <summary>
    /// Program entry point. Instantiates and runs the application.
    /// </summary>
    public static void Main()
    {
        new Program().Run();
    }
}
// Numbers to check
//Massive A -5 - 3 8 - 1 6 - 7 10 - 2
//Massive B 3 -5 0 -2 7 -4 9 -6
// Index for A 5