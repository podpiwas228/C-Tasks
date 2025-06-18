/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main method — запускает приложение и взаимодействует с пользователем через консоль.
    /// </summary>
    static void Main()
    {
        ConsoleUI ui = new ConsoleUI();
        MagazineManager magazineManager = new MagazineManager();
        SubscriberManager subscriberManager = new SubscriberManager();

        magazineManager.LoadFromFile("magazines.txt");
        subscriberManager.LoadFromFile("subscribers.txt", magazineManager);

        subscriberManager.PrintSortedByTotalCost(ui);

        subscriberManager.PrintMultipleSubscriptions(ui);

        decimal maxCost = 500000m;
        subscriberManager.PrintByMaxCost(maxCost, ui);

        string houseNumber = "12";
        subscriberManager.PrintByHouseNumber(houseNumber, ui);

        string name = ui.Read("\nEnter magazine name to modify: ");
        Magazine? magazine = magazineManager.FindMagazine(name);

        if (magazine != null)
        {
            string newTitle = ui.Read("Enter new title: ");
            magazine.ChangeTitle(newTitle);

            string newCostInput = ui.Read("Enter new annual cost: ");
            if (decimal.TryParse(newCostInput, out decimal newCost))
            {
                magazine.ChangePrice(newCost);
            }
        }
        else
        {
            ui.Print("Magazine not found.");
        }

        ui.Print("\nUpdated subscriber list:");
        subscriberManager.PrintSortedByTotalCost(ui);
    }
}
