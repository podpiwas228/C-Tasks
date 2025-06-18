using System.Diagnostics.Metrics;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    const decimal MaxSubscriptionCost = 500000m;
    const string TargetHouseNumber = "12";
    const string MagazinesFilePath = "magazines.txt";
    const string SubscribersFilePath = "subscribers.txt";
    const string NewtTitlemessage = "\nEnter magazine name to modify:";
    const string GetNewTitle = "Enter new title:";
    const string GetCost = "Enter new annual cost:" ;
    const string FailStore = "Magazine not found.";
    const string UpdateSubscriber = "\nUpdated subscriber list:";
    /// <summary>
    /// Main method - starts the application and interacts with the user through the console.
    /// </summary>
    static void Main()
    {
        ConsoleUI ui = new ConsoleUI();
        MagazineManager magazineManager = new MagazineManager();
        SubscriberManager subscriberManager = new SubscriberManager();

        magazineManager.LoadFromFile(MagazinesFilePath);
        subscriberManager.LoadFromFile(SubscribersFilePath, magazineManager);

        subscriberManager.PrintSortedByTotalCost(ui);

        subscriberManager.PrintMultipleSubscriptions(ui);

        subscriberManager.PrintByMaxCost(MaxSubscriptionCost, ui);

        string houseNumber = TargetHouseNumber;
        subscriberManager.PrintByHouseNumber(houseNumber, ui);

        string name = ui.Read(NewtTitlemessage);
        Magazine? magazine = magazineManager.FindMagazine(name);

        if (magazine != null)
        {
            string newTitle = ui.Read(GetNewTitle);
            magazine.ChangeTitle(newTitle);

            string newCostInput = ui.Read(GetCost);
            if (decimal.TryParse(newCostInput, out decimal newCost))
            {
                magazine.ChangePrice(newCost);
            }
        }
        else
        {
            ui.Print(FailStore);
        }

        ui.Print(UpdateSubscriber);
        subscriberManager.PrintSortedByTotalCost(ui);
    }
}
