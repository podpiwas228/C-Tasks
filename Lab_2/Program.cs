/// <summary>
/// Main program execution.
/// </summary>
class Program
{
    private const int _addstock_value = 13;

    private const int _sellproduct_value = 8;

    private const double _newprice_value = 1300.75;
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            // Create interaction instance
            UserInteraction userInteraction = new UserInteraction();

            // Display product information
            userInteraction.ShowProductInfo();

            // Add stock and update the quantity
            userInteraction.AddStock(_addstock_value);

            // Sell the product
            userInteraction.SellProduct(_sellproduct_value);

            // Update the product price
            userInteraction.UpdatePrice(_newprice_value);
        }
        catch (Exception ex)
        {
            // Handle unexpected errors gracefully
            throw new Exception(ex.Message);
        }
    }
}