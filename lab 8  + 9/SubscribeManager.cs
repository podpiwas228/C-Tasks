using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Manages subscriber data and provides methods to load subscribers and print them based on various filters.
/// </summary>
public class SubscriberManager
{
    private const int MinimumSubscriberParts = 3;
    private const int MultipleSubscriptionThreshold = 1;
    private const char DataSeparator = ';';
    private const string MainMenu = "No.\tLast Name\tAddress\tMagazines\tTotal Cost";
    private const string Subsriberswith1Magazine = "\nSubscribers with more than one magazine:";
    private const string SubsCost = $"\nSubscribers with total cost below :";
    private const string SubsWithHouseNumber = $"\nSubscribers with house number " ;

    /// <summary>
    /// Gets the list of subscribers.
    /// </summary>
    public List<Subscriber> Subscribers { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriberManager"/> class.
    /// </summary>
    public SubscriberManager()
    {
        Subscribers = new List<Subscriber>();
    }

    /// <summary>
    /// Loads subscribers from a file and registers event handlers for magazine changes.
    /// </summary>
    /// <param name="path">File path to load subscribers from.</param>
    /// <param name="magazineManager">Magazine manager to link subscribers with magazines.</param>
    public void LoadFromFile(string path, MagazineManager magazineManager)
    {
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split(DataSeparator);

            if (parts.Length >= MinimumSubscriberParts)
            {
                string name = parts[0];
                string address = parts[1];
                List<string> titles = parts.Skip(2)
                    .ToList();

                Subscriber subscriber = new Subscriber(name, address, titles);

                foreach (string title in titles)
                {
                    Magazine? magazine = magazineManager.FindMagazine(title);

                    if (magazine != null)
                    {
                        magazine.TitleChanged += subscriber.OnMagazineTitleChanged;
                        magazine.PriceChanged += subscriber.OnMagazinePriceChanged;
                        subscriber.SetMagazineCost(title, magazine.AnnualCost);
                    }
                }

                Subscribers.Add(subscriber);
            }
        }
    }

    /// <summary>
    /// Prints subscribers sorted by descending total subscription cost.
    /// </summary>
    /// <param name="ui">Console UI to output data.</param>
    public void PrintSortedByTotalCost(ConsoleUI ui)
    {
        List<Subscriber> sorted = Subscribers.OrderByDescending(s => s.TotalCost)
            .ToList();
        ui.Print(MainMenu);
        for (int i = 0; i < sorted.Count; i++)
        {
            sorted[i].PrintInfo(i + 1, ui);
        }
    }

    /// <summary>
    /// Prints subscribers who have subscriptions to more than one magazine.
    /// </summary>
    /// <param name="ui">Console UI to output data.</param>
    public void PrintMultipleSubscriptions(ConsoleUI ui)
    {
        ui.Print(Subsriberswith1Magazine);

        var result = Subscribers.Where(s => 
        s.GetMagazinesString()
        .Split(',').Length > MultipleSubscriptionThreshold)
            .ToList();

        for (int i = 0; i < result.Count; i++)
        {
            result[i].PrintInfo(i + 1, ui);
        }
    }

    /// <summary>
    /// Prints subscribers with total subscription cost below a specified threshold.
    /// </summary>
    /// <param name="maxCost">Maximum total cost allowed.</param>
    /// <param name="ui">Console UI to output data.</param>
    public void PrintByMaxCost(decimal maxCost, ConsoleUI ui)
    {
        ui.Print(SubsCost +  maxCost);

        var result = Subscribers.Where(s => s.TotalCost < maxCost)
            .ToList();

        for (int i = 0; i < result.Count; i++)
        {
            result[i].PrintInfo(i + 1, ui);
        }
    }

    /// <summary>
    /// Prints subscribers who live at the specified house number.
    /// </summary>
    /// <param name="houseNumber">House number string to filter subscribers.</param>
    /// <param name="ui">Console UI to output data.</param>
    public void PrintByHouseNumber(string houseNumber, ConsoleUI ui)
    {
        ui.Print(SubsWithHouseNumber  + houseNumber );

        var result = Subscribers.Where(s => s.Address
        .Contains($"d.{houseNumber}"))
            .ToList();

        for (int i = 0; i < result.Count; i++)
        {
            result[i].PrintInfo(i + 1, ui);
        }
    }
}
