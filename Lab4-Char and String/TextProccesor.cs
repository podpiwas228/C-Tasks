using System;
using System.Linq;

public class TextProcessor
{
    public static string ProcessText(string inputText, decimal exchangeRate, DateTime currentDate)
    {
        string[] sentences = inputText.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        var validSentences = sentences.Where(sentence =>
        {
            try
            {
                return SentenceProcessor.IsValidSentence(sentence)
                       && SentenceProcessor.IsDateWithinOneMonth(sentence, currentDate);
            }
            catch
            {
                return false;
            }
        });

        return string.Join(". ", validSentences.Select(sentence =>
            SentenceProcessor.ConvertCurrency(sentence, exchangeRate)));
    }
}