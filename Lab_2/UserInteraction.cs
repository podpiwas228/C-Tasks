/// <summary>
/// Class responsible for user interaction.
/// </summary>
class UserInteraction
{
    private const double _price = 1200.50;
    private const int _quantity = 10;
    private const string _laptop = "Laptop";

    private Storage _storage;

    /// <summary>
    /// Initializes storage with predefined values.
    /// </summary>
    public UserInteraction()
    {
        _storage = new Storage(_laptop, _price, _quantity);
    }

    /// <summary>
    /// Displays current product information.
    /// </summary>
    public void ShowProductInfo()
    {
        string message = _storage.GetProductInfo();
        Console.WriteLine(message);
    }

    /// <summary>
    /// Adds stock and displays updated information.
    /// </summary>
    /// <param name="amount">Amount of stock to add.</param>
    public void AddStock(int amount)
    {
        _storage.AddStock(amount);
        Console.WriteLine("After adding stock:");
        string message = _storage.GetProductInfo();
        Console.WriteLine(message);
    }

    /// <summary>
    /// Sells a product and updates the information.
    /// </summary>
    /// <param name="amount">Amount to sell.</param>
    public void SellProduct(int amount)
    {
        bool isSold = _storage.Sell(amount);
        Console.WriteLine(isSold ? "Sale successful!" : "Not enough stock to sell.");
        string message = _storage.GetProductInfo();
        Console.WriteLine(message);
    }

    /// <summary>
    /// Updates the price and displays the updated product information.
    /// </summary>
    /// <param name="newPrice">New price to set.</param>
    public void UpdatePrice(double newPrice)
    {
        _storage.Price = newPrice;
        Console.WriteLine("After changing the price:");
        string message = _storage.GetProductInfo();
        Console.WriteLine(message);
    }
}