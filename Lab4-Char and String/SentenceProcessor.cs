using System;
using System.Globalization;

/// <summary>
/// Class to validate and process sentences containing dates and payment amounts.
/// </summary>
public class SentenceProcessor
{
    /// <summary>
    /// Validates if the sentence contains a valid date and amount.
    /// </summary>
    /// <param name="sentence">The sentence to validate.</param>
    /// <exception cref="FormatException">Thrown when the sentence does not contain a valid date and amount.</exception>
    public void ValidateSentence(string sentence)
    {
        if (!TryParseSentence(sentence, out _, out _))
        {
            throw new FormatException("Invalid sentence format. It must contain a date and an amount.");
        }
    }

    /// <summary>
    /// Attempts to parse a sentence into a date and amount.
    /// </summary>
    /// <param name="sentence">The sentence to parse.</param>
    /// <param name="date">The parsed date.</param>
    /// <param name="amount">The parsed amount.</param>
    /// <returns>True if the sentence was successfully parsed; otherwise, false.</returns>
    public bool TryParseSentence(string sentence, out DateTime date, out decimal amount)
    {
        date = default;
        amount = default;

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        bool dateFound = false;
        bool amountFound = false;

        foreach (var word in words)
        {
            if (!dateFound && DateTime.TryParseExact(word, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                dateFound = true;
            }
            else if (!amountFound && decimal.TryParse(word, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            {
                amountFound = true;
            }

            if (dateFound && amountFound)
                return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if the provided date is within one month of the current date.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="currentDate">The current date to compare with.</param>
    /// <returns>True if the date is within one month from the current date; otherwise, false.</returns>
    public bool IsDateWithinOneMonth(DateTime date, DateTime currentDate)
    {
        return date >= currentDate.AddMonths(-1) && date <= currentDate;
    }

    /// <summary>
    /// Converts a payment amount from USD to BYN using the provided exchange rate.
    /// </summary>
    /// <param name="date">The payment date.</param>
    /// <param name="amount">The payment amount in USD.</param>
    /// <param name="exchangeRate">The exchange rate to convert to BYN.</param>
    /// <returns>A formatted string with the payment date and converted amount in BYN.</returns>
    public string ConvertCurrency(DateTime date, decimal amount, decimal exchangeRate)
    {
        decimal amountInBYN = amount * exchangeRate;
        return $"Payment date: {date:dd.MM.yyyy}, amount: {amountInBYN:F2} BYN";
    }
}
