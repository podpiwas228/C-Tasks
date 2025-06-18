using System;

/// <summary>
/// Simple console UI helper class for input/output.
/// </summary>
public class ConsoleUI
{
    /// <summary>
    /// Prints a string to the console.
    /// </summary>
    /// <param name="message">Message to print.</param>
    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Reads a string input from the console after showing a prompt.
    /// </summary>
    /// <param name="prompt">Prompt message.</param>
    /// <returns>User input string.</returns>
    public string Read(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }
}
