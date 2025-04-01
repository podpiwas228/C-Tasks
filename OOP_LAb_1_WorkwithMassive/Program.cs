class Program
{
    /// <summary>
    /// Method to calculate f
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException"></exception>
    static double CalculateF(int a, int b, int c)
    {
        double numerator = 2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3);
        double denominator = a + b;

        if (denominator == 0)
            throw new DivideByZeroException("Denominator is zero!");

        return numerator / denominator;
    }

    static void Main(string[] args)
    {
        try
        {
            /// Input arrays A and B
            ArrayClass A = new ArrayClass();
            Console.WriteLine("Enter array A:");
            A.InputElements();

            ArrayClass B = new ArrayClass();
            Console.WriteLine("Enter array B:");
            B.InputElements();

            /// Input specified index
            Console.WriteLine("Enter the specified index for array A:");
            int specifiedIndex = int.Parse(Console.ReadLine());

            /// Find leftmost and rightmost minimums and form array C
            int leftmostMinIndexB = B.Elements.IndexOf(B.Elements.Min());
            int rightmostMinIndexA = A.Elements.Count - 1 - A.Elements.LastIndexOf(A.Elements.Min());
            List<int> CElements = B.Elements.Skip(leftmostMinIndexB + 1).ToList();
            CElements.AddRange(A.Elements.Skip(rightmostMinIndexA).Take(specifiedIndex - rightmostMinIndexA));

            ArrayClass C = new ArrayClass(CElements);

            /// Calculate a, b, c
            int a = A.CalculateSpecialValue();
            int b = B.CalculateSpecialValue();
            int c = C.CalculateSpecialValue();

            /// Calculate f
            double f = CalculateF(a, b, c);

            /// Output results
            Console.WriteLine("Array A:");
            A.OutputElements();
            Console.WriteLine($"a = {a}");

            Console.WriteLine("Array B:");
            B.OutputElements();
            Console.WriteLine($"b = {b}");

            Console.WriteLine("Array C:");
            C.OutputElements();
            Console.WriteLine($"c = {c}");

            Console.WriteLine($"Value of function f: {f}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}