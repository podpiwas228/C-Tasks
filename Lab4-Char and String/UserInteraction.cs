using System;

public class UserInteraction
{
    public void Start()
    {
        Console.WriteLine("Enter the text:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Enter the exchange rate (BYN to USD):");
        if (!decimal.TryParse(Console.ReadLine(), out decimal exchangeRate))
        {
            Console.WriteLine("Invalid exchange rate.");
            return;
        }

        DateTime currentDate = DateTime.Now;

        try
        {
            string processedText = TextProcessor.ProcessText(inputText, exchangeRate, currentDate);
            Console.WriteLine("Result:");
            Console.WriteLine(processedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}