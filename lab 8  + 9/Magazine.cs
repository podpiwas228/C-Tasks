using System;

/// <summary>
/// Represents a magazine with title and annual cost, supporting events for changes.
/// </summary>
public class Magazine
{
    private string _title;
    private decimal _annualCost;

    /// <summary>
    /// Gets the magazine title.
    /// </summary>
    public string Title => _title;

    /// <summary>
    /// Gets the annual cost of the magazine.
    /// </summary>
    public decimal AnnualCost => _annualCost;

    /// <summary>
    /// Occurs when the magazine title changes.
    /// Parameters: old title, new title.
    /// </summary>
    public event Action<string, string>? TitleChanged;

    /// <summary>
    /// Occurs when the magazine annual cost changes.
    /// Parameters: magazine title, new cost.
    /// </summary>
    public event Action<string, decimal>? PriceChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="Magazine"/> class.
    /// </summary>
    /// <param name="title">Magazine title.</param>
    /// <param name="annualCost">Annual subscription cost.</param>
    public Magazine(string title, decimal annualCost)
    {
        _title = title;
        _annualCost = annualCost;
    }

    /// <summary>
    /// Changes the magazine title and raises the TitleChanged event.
    /// </summary>
    /// <param name="newTitle">New title for the magazine.</param>
    public void ChangeTitle(string newTitle)
    {
        string oldTitle = _title;
        _title = newTitle;
        TitleChanged?.Invoke(oldTitle, newTitle);
    }

    /// <summary>
    /// Changes the annual cost and raises the PriceChanged event.
    /// </summary>
    /// <param name="newCost">New annual cost.</param>
    public void ChangePrice(decimal newCost)
    {
        _annualCost = newCost;
        PriceChanged?.Invoke(_title, newCost);
    }
}
