using System;
using System.Globalization;

public class SentenceProcessor
{
    public static bool IsValidSentence(string sentence)
    {
        return TryParseSentence(sentence, out _, out _);
    }

    public static bool IsDateWithinOneMonth(string sentence, DateTime currentDate)
    {
        if (TryParseSentence(sentence, out DateTime date, out _))
        {
            return (date >= currentDate.AddMonths(-1) && date <= currentDate);
        }
        return false;
    }

    public static string ConvertCurrency(string sentence, decimal exchangeRate)
    {
        if (TryParseSentence(sentence, out DateTime date, out decimal amount))
        {
            decimal amountInBYN = amount * exchangeRate;
            return $"Payment date: {date.ToShortDateString()}, payment amount: {amountInBYN} BYN";
        }
        return string.Empty;
    }

    private static bool TryParseSentence(string sentence, out DateTime date, out decimal amount)
    {
        date = default;
        amount = default;

        var parts = sentence.Split(',');
        if (parts.Length < 2) return false;

        if (!DateTime.TryParse(parts[0].Trim(), out date)) return false;

        if (!decimal.TryParse(parts[1].Trim(), NumberStyles.Currency, CultureInfo.InvariantCulture, out amount))
        {
            return false;
        }

        return true;
    }
}