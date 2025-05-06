using System;
using System.Globalization;

/// <summary>
/// Provides functionality for validating sentences, extracting data, and converting currency.
/// </summary>
public class SentenceProcessor
{
    /// <summary>
    /// Checks if a sentence is valid (contains a date and an amount).
    /// </summary>
    /// <param name="sentence">The sentence to validate.</param>
    /// <returns>True if the sentence contains a valid date and amount, otherwise false.</returns>
    public bool IsValidSentence(string sentence)
    {
        return TryParseSentence(sentence, out _, out _);
    }

    /// <summary>
    /// Determines whether the sentence contains a date within the last month.
    /// </summary>
    /// <param name="sentence">The sentence containing the date.</param>
    /// <param name="currentDate">The reference date for validation.</param>
    /// <returns>True if the date is within the last month, otherwise false.</returns>
    public bool IsDateWithinOneMonth(string sentence, DateTime currentDate)
    {
        if (TryParseSentence(sentence, out DateTime date, out _))
        {
            return date >= currentDate.AddMonths(-1) && date <= currentDate;
        }
        return false;
    }

    /// <summary>
    /// Converts the currency in the sentence using the provided exchange rate.
    /// </summary>
    /// <param name="sentence">The sentence containing the amount.</param>
    /// <param name="exchangeRate">The exchange rate for conversion.</param>
    /// <returns>A formatted string with the converted currency values.</returns>
    public string ConvertCurrency(string sentence, decimal exchangeRate)
    {
        if (TryParseSentence(sentence, out DateTime date, out decimal amount))
        {
            decimal amountInBYN = amount * exchangeRate;
            return $"Payment date: {date.ToShortDateString()}, payment amount: {amountInBYN} BYN";
        }
        return string.Empty;
    }

    /// <summary>
    /// Attempts to parse the sentence and extract date and amount values.
    /// </summary>
    /// <param name="sentence">The sentence containing date and amount.</param>
    /// <param name="date">Extracted date value.</param>
    /// <param name="amount">Extracted amount value.</param>
    /// <returns>True if parsing was successful, otherwise false.</returns>
    private bool TryParseSentence(string sentence, out DateTime date, out decimal amount)
    {
        var parts = sentence.Split(',', StringSplitOptions.RemoveEmptyEntries);

        // Default assignment to prevent uninitialized variables
        date = default;
        amount = default;

        if (parts.Length != 2)
        {
            Console.WriteLine($"Parsing error: Invalid sentence format - '{sentence}'");
            return false;
        }

        if (!DateTime.TryParse(parts[0].Trim(), out date))
        {
            Console.WriteLine($"Date parsing error: '{parts[0].Trim()}'.");
            return false;
        }

        if (!decimal.TryParse(parts[1].Trim(), out amount))
        {
            Console.WriteLine($"Amount parsing error: '{parts[1].Trim()}'.");
            return false;
        }

        return true;
    }
}