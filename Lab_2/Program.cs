using System;

/// <summary>
/// Main program.
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments array.</param>
    static void Main(string[] args)
    {
        try
        {
            // Create Laptop object
            Storage laptop = new Storage("Laptop", 1200.50, 10);

            // Display product information
            Console.WriteLine(laptop.GetProductInfo());

            // Add quantity (5)
            laptop.AddStock(5);
            Console.WriteLine("After adding stock:");
            Console.WriteLine(laptop.GetProductInfo());

            // Sell the product
            bool isSold = laptop.Sell(8);
            Console.WriteLine(isSold ? "Sale successful!" : "Not enough stock to sell.");
            Console.WriteLine(laptop.GetProductInfo());

            // Update the price
            laptop.Price = 1300.75;
            Console.WriteLine("After changing the price:");
            Console.WriteLine(laptop.GetProductInfo());
        }
        // Handle exceptions
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}