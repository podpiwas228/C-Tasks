using System;

/// <summary>
/// Handles interaction with the user via console.
/// </summary>
public class UserInteraction
{
    private TextProcessor _textProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserInteraction"/> class.
    /// </summary>
    public UserInteraction()
    {
        SentenceProcessor sentenceProcessor = new SentenceProcessor();
        _textProcessor = new TextProcessor(sentenceProcessor);
    }

    /// <summary>
    /// Starts the user interaction and processes the input text.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Enter the text:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Enter the exchange rate (USD to BYN):");
        if (!decimal.TryParse(Console.ReadLine(), out decimal exchangeRate))
        {
            Console.WriteLine("Invalid exchange rate.");
            return;
        }
        DateTime currentDate = DateTime.Now;
        try
        {
            string processedText = _textProcessor.ProcessText(inputText, exchangeRate, currentDate);
            Console.WriteLine("Result:");
            Console.WriteLine(processedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}