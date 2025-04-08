using System;
using System.Collections.Generic;
using System.Linq;

class UserInteraction
{
    // Constants for messages
    private const string InputPrompt = "Enter array elements separated by spaces:";
    private const string OutputPrompt = "Array elements: ";
    private const string ErrorMessage = "Input error: elements must be numbers.";

    // Method for inputting array elements
    public static List<int> InputElements()
    {
        Console.WriteLine(InputPrompt);
        try
        {
            string input = Console.ReadLine();
            return input.Split(' ').Select(int.Parse).ToList();
        }
        catch (FormatException)
        {
            throw new Exception(ErrorMessage);
        }
    }

    // Method for outputting array elements
    public static void OutputElements(List<int> elements)
    {
        Console.WriteLine(OutputPrompt + string.Join(" ", elements));
    }

    // Method for inputting specified index
    public static int InputIndex()
    {
        Console.WriteLine("Enter the specified index for array A:");
        return int.Parse(Console.ReadLine());
    }
}
