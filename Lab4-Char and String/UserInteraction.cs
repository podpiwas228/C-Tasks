using System;

/// <summary>
/// Handles user interaction via console input and output.
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
    /// Starts user interaction and processes input text.
    /// </summary>
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
            string processedText = _textProcessor.ProcessText(inputText, exchangeRate, currentDate);
            Console.WriteLine("Result:");
            Console.WriteLine(processedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing error: {ex.Message}");
        }
    }
}