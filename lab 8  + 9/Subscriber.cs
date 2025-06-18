using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a subscriber to magazines, storing their personal data and subscriptions.
/// </summary>
public class Subscriber
{
    /// <summary>
    /// Gets the subscriber's last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the subscriber's address.
    /// </summary>
    public string Address { get; }

    private readonly List<string> _magazineTitles;
    private readonly List<decimal> _magazineCosts;

    private const decimal InitialSubscriptionCost = 0m;
    private const string ExcludedAddressPrefix = "Ul.Sovetskaya";
    /// <summary>
    /// Initializes a new instance of the <see cref="Subscriber"/> class.
    /// </summary>
    /// <param name="lastName">Subscriber's last name.</param>
    /// <param name="address">Subscriber's address.</param>
    /// <param name="magazineTitles">List of magazine titles the subscriber is subscribed to.</param>
    public Subscriber(string lastName, string address, IEnumerable<string> magazineTitles)
    {
        LastName = lastName;
        Address = address;
        _magazineTitles = magazineTitles.ToList();
        _magazineCosts = new List<decimal>();
        foreach (var _ in _magazineTitles)
        {
            _magazineCosts.Add(InitialSubscriptionCost);
        }
    }

    /// <summary>
    /// Gets the magazine title at the specified index.
    /// </summary>
    /// <param name="index">Index of the magazine.</param>
    public string this[int index] => _magazineTitles[index];

    /// <summary>
    /// Gets the total cost of all magazine subscriptions.
    /// </summary>
    public decimal TotalCost => _magazineCosts.Sum();

    /// <summary>
    /// Event handler for when a magazine title changes.
    /// Updates the subscriber's stored magazine title accordingly.
    /// </summary>
    /// <param name="oldTitle">Old title of the magazine.</param>
    /// <param name="newTitle">New title of the magazine.</param>
    public void OnMagazineTitleChanged(string oldTitle, string newTitle)
    {
        int index = _magazineTitles.IndexOf(oldTitle);
        if (index >= 0)
        {
            _magazineTitles[index] = newTitle;
        }
    }

    /// <summary>
    /// Event handler for when a magazine price changes.
    /// Updates the stored cost for the magazine unless the address starts with "Ul.Sovetskaya".
    /// </summary>
    /// <param name="title">Title of the magazine.</param>
    /// <param name="newCost">New annual cost.</param>
    public void OnMagazinePriceChanged(string title, decimal newCost)
    {
        int index = _magazineTitles.IndexOf(title);
        if (index >= 0)
        {
            bool isExcluded = Address.StartsWith(ExcludedAddressPrefix);
            if (!isExcluded)
            {
                _magazineCosts[index] = newCost;
            }
        }
    }

    /// <summary>
    /// Sets the cost of a specific magazine subscription.
    /// </summary>
    /// <param name="title">Title of the magazine.</param>
    /// <param name="cost">Cost to set.</param>
    public void SetMagazineCost(string title, decimal cost)
    {
        int index = _magazineTitles.IndexOf(title);
        if (index >= 0)
        {
            _magazineCosts[index] = cost;
        }
    }

    /// <summary>
    /// Gets a comma-separated string of all magazine titles the subscriber is subscribed to.
    /// </summary>
    /// <returns>String of magazine titles separated by commas.</returns>
    public string GetMagazinesString()
    {
        return string.Join(", ", _magazineTitles);
    }

    /// <summary>
    /// Prints subscriber information with a numbering prefix.
    /// </summary>
    /// <param name="number">Numbering index for display.</param>
    /// <param name="ui">Console UI instance to output data.</param>
    public void PrintInfo(int number, ConsoleUI ui)
    {
        string getMagazine  = GetMagazinesString();
        ui.Print($"{number}.\t{LastName}\t{Address}\t{getMagazine}\t{TotalCost:F2}");
    }
}
