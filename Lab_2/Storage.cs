using System;

/// <summary>
/// Class representing a product storage.
/// </summary>
class Storage
{
    private string _name;
    private double _price;
    private int _quantity;

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Quantity of the product in storage.
    /// </summary>
    public int Quantity => _quantity;

    /// <summary>
    /// Product price.
    /// </summary>
    public double Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
            }
            else
            {
                throw new ArgumentException("The price must be greater than 0.");
            }
        }
    }

    /// <summary>
    /// Constructor to initialize a product.
    /// </summary>
    /// <param name="name">The product's name.</param>
    /// <param name="price">The product's price.</param>
    /// <param name="quantity">The product's quantity.</param>
    public Storage(string name, double price, int quantity)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name cannot be null or empty.");
        }
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException("The price must be greater than 0.");
        }
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException("Quantity cannot be negative.");
        }

        _name = name;
        _price = price;
        _quantity = quantity;
    }

    /// <summary>
    /// Method to add stock to storage.
    /// </summary>
    /// <param name="amount">Amount to add.</param>
    public void AddStock(int amount)
    {
        if (amount > 0)
        {
            _quantity += amount;
        }
        else
        {
            throw new ArgumentException("The amount to add must be greater than 0.");
        }
    }

    /// <summary>
    /// Method to sell a product.
    /// </summary>
    /// <param name="amount">Amount to sell.</param>
    /// <returns>True if the sale is successful, otherwise false.</returns>
    public bool Sell(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("The amount for sale must be greater than 0.");
        }

        if (_quantity >= amount)
        {
            _quantity -= amount;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Method to retrieve product information.
    /// </summary>
    /// <returns>Product information as a formatted string.</returns>
    public string GetProductInfo()
    {
        return $"Product: {Name}, Price: {Price:F2}, Quantity: {Quantity}";
    }
}