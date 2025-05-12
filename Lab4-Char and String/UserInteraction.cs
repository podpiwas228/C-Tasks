using System;

public class UserInteraction
{
    private readonly TextProcessor _textProcessor;

    public UserInteraction()
    {
        var sentenceProcessor = new SentenceProcessor();
        _textProcessor = new TextProcessor(sentenceProcessor);
    }

    public void Start()
    {
        Console.WriteLine("Enter the text:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Enter the exchange rate (USD -> BYN):");
        if (!decimal.TryParse(Console.ReadLine(), out decimal exchangeRate))
        {
            Console.WriteLine("Error: Invalid exchange rate format.");
            return;
        }

        DateTime currentDate = DateTime.Now;
        try
        {
            string result = _textProcessor.ProcessText(inputText, exchangeRate, currentDate);
            Console.WriteLine("Result:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing error: {ex.Message}");
        }
    }
}
