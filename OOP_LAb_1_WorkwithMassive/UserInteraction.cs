using System;
using System.Collections.Generic;
using System.Linq;

class UserInteraction
{
    private const string InputPromptTemplate = "Enter array {0} elements separated by spaces:";
    private const string IndexPrompt = "Enter the specified index for array A:";
    private const string OutputLabelTemplate = "Array {0}:";
    private const string ErrorMessage = "Input error: elements must be integers.";

    /// <summary>
    /// Prompts the user to enter array elements for a specified array name.
    /// </summary>
    /// <param name="arrayName">The name of the array (e.g., "A" or "B").</param>
    /// <returns>List of integers entered by the user.</returns>
    /// <exception cref="Exception">Thrown when input cannot be parsed into integers.</exception>
    public List<int> GetArrayInput(string arrayName)
    {
        Console.WriteLine(string.Format(InputPromptTemplate, arrayName));
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

    /// <summary>
    /// Prompts the user to enter a specified index.
    /// </summary>
    /// <returns>The index entered by the user as an integer.</returns>
    /// <exception cref="Exception">Thrown when input is not a valid integer.</exception>
    public int GetIndexInput()
    {
        Console.WriteLine(IndexPrompt);
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            throw new Exception("Invalid index input.");
        }
        return index;
    }

    /// <summary>
    /// Displays the contents of an array along with its special calculated value.
    /// </summary>
    /// <param name="name">The name of the array ("A", "B", or "C").</param>
    /// <param name="elements">The list of elements in the array.</param>
    /// <param name="specialValue">The special value calculated from the array.</param>
    public void ShowArray(string name, List<int> elements, int specialValue)
    {
        Console.WriteLine(string.Format(OutputLabelTemplate, name));
        Console.WriteLine(string.Join(" ", elements));
        Console.WriteLine($"{name.ToLower()} = {specialValue}");
    }

    /// <summary>
    /// Displays the final result of the function calculation.
    /// </summary>
    /// <param name="value">The calculated value of the function.</param>
    public void ShowFunctionResult(double value)
    {
        Console.WriteLine($"Value of function f: {value}");
    }

    /// <summary>
    /// Displays an error message to the user.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    public void ShowError(string message)
    {
        Console.WriteLine("An error occurred: " + message);
    }
}

