using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Method to calculate f
    private static double CalculateF(int a, int b, int c)
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
            // Input arrays A and B
            Console.WriteLine("Enter array A:");
            ArrayClass A = new ArrayClass(UserInteraction.InputElements());

            Console.WriteLine("Enter array B:");
            ArrayClass B = new ArrayClass(UserInteraction.InputElements());

            // Input specified index
            int specifiedIndex = UserInteraction.InputIndex();

            // Find leftmost and rightmost minimums and form array C
            int leftmostMinIndexB = B.Elements.IndexOf(B.Elements.Min());
            int rightmostMinIndexA = A.Elements.Count - 1 - A.Elements.LastIndexOf(A.Elements.Min());
            List<int> CElements = B.Elements.Skip(leftmostMinIndexB + 1).ToList();
            CElements.AddRange(A.Elements.Skip(rightmostMinIndexA).Take(specifiedIndex - rightmostMinIndexA));

            ArrayClass C = new ArrayClass(CElements);

            // Calculate a, b, c
            int a = A.CalculateSpecialValue();
            int b = B.CalculateSpecialValue();
            int c = C.CalculateSpecialValue();

            // Calculate f
            double f = CalculateF(a, b, c);

            // Output results
            Console.WriteLine("Array A:");
            UserInteraction.OutputElements(A.Elements);
            Console.WriteLine($"a = {a}");

            Console.WriteLine("Array B:");
            UserInteraction.OutputElements(B.Elements);
            Console.WriteLine($"b = {b}");

            Console.WriteLine("Array C:");
            UserInteraction.OutputElements(C.Elements);
            Console.WriteLine($"c = {c}");

            Console.WriteLine($"Value of function f: {f}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
// Numbers to check
//Massive A -5 - 3 8 - 1 6 - 7 10 - 2
//Massive B 3 -5 0 -2 7 -4 9 -6
// Index for A 5
