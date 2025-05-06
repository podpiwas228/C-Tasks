using System;
using System.Linq;

/// <summary>
/// Processes input text, filters valid sentences, and converts currency values.
/// </summary>
public class TextProcessor
{
    private SentenceProcessor _sentenceProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextProcessor"/> class.
    /// </summary>
    /// <param name="sentenceProcessor">Instance of <see cref="SentenceProcessor"/> for sentence operations.</param>
    public TextProcessor(SentenceProcessor sentenceProcessor)
    {
        _sentenceProcessor = sentenceProcessor;
    }

    /// <summary>
    /// Processes the text, filters valid sentences, and converts currency values.
    /// </summary>
    /// <param name="inputText">The raw text input from the user.</param>
    /// <param name="exchangeRate">The exchange rate for currency conversion.</param>
    /// <param name="currentDate">The current date for date validation.</param>
    /// <returns>Processed text with converted currency values.</returns>
    public string ProcessText(string inputText, decimal exchangeRate, DateTime currentDate)
    {
        string[] sentences = inputText.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        var validSentences = sentences.Where(sentence =>
        {
            try
            {
                return _sentenceProcessor.IsValidSentence(sentence)
                       && _sentenceProcessor.IsDateWithinOneMonth(sentence, currentDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sentence processing error: {ex.Message}");
                return false;
            }
        });

        return string.Join(". ", validSentences.Select(sentence =>
            _sentenceProcessor.ConvertCurrency(sentence, exchangeRate)));
    }
}