/// <summary>
/// Main program execution.
/// </summary>
class Program
{
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
            userInteraction.AddStock(13);

            // Sell the product
            userInteraction.SellProduct(8);

            // Update the product price
            userInteraction.UpdatePrice(1300.75);
        }
        catch (Exception ex)
        {
            // Handle unexpected errors gracefully
            throw new Exception(ex.Message);
        }
    }
}