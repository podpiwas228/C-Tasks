using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Class to process text containing sentences with payment dates and amounts.
/// </summary>
public class TextProcessor
{
    private readonly SentenceProcessor _sentenceProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextProcessor"/> class.
    /// </summary>
    /// <param name="sentenceProcessor">The sentence processor instance used for validation and conversion.</param>
    public TextProcessor(SentenceProcessor sentenceProcessor)
    {
        _sentenceProcessor = sentenceProcessor;
    }

    /// <summary>
    /// Processes the input text, filters out invalid sentences, and converts amounts to BYN if within the last month.
    /// </summary>
    /// <param name="inputText">The input text containing sentences.</param>
    /// <param name="exchangeRate">The exchange rate to convert USD to BYN.</param>
    /// <param name="currentDate">The current date to compare payment dates against.</param>
    /// <returns>A processed string with valid sentences, converted to BYN.</returns>
    public string ProcessText(string inputText, decimal exchangeRate, DateTime currentDate)
    {
        var sentences = inputText.Split(new[] { ". " }, StringSplitOptions.RemoveEmptyEntries);

        return string.Join(". ", sentences
            .Select(sentence =>
            {
                sentence = sentence.Trim().TrimEnd('.');

                try
                {
                    _sentenceProcessor.ValidateSentence(sentence);
                    if (_sentenceProcessor.TryParseSentence(sentence, out DateTime date, out decimal amount)
                        && _sentenceProcessor.IsDateWithinOneMonth(date, currentDate))
                    {
                        return _sentenceProcessor.ConvertCurrency(date, amount, exchangeRate);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Skipping sentence: \"{sentence}\". Error: {ex.Message}");
                }

                return null;
            })
            .Where(result => result != null));
    }
}
