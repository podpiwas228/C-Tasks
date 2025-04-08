using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // create object laptop
            Storage laptop = new Storage("Laptop", 1200.50, 10);

            // get product info method
            Console.WriteLine(laptop.GetProductInfo());

            // add quanity(5)
            laptop.AddStock(5);
            Console.WriteLine("After adding stock:");
            Console.WriteLine(laptop.GetProductInfo());

            //sell  product
            bool isSold = laptop.Sell(8);
            Console.WriteLine(isSold ? "Sale successful!" : "Not enough stock to sell.");
            Console.WriteLine(laptop.GetProductInfo());

            //new price
            laptop.Price = 1300.75;
            Console.WriteLine("After changing the price:");
            Console.WriteLine(laptop.GetProductInfo());
        }
        // if we have any problem - exception
        catch (Exception ex)
        {  
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}