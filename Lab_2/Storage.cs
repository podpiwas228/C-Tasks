using System;

class Storage
{
    private string _name;
    private double _price;
    private int _quantity;

    public string Name => _name; 
    public int Quantity => _quantity; 
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
                throw new ArgumentException("The price must be greater than 0");
            }
        }
    }

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

    public string GetProductInfo()
    {
        return $"Product: {Name}, Price: {Price:F2}, Quantity: {Quantity}";
    }
}
