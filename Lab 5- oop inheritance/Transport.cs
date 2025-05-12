using System;

public abstract class Transport
{
    private int _capacity;

    public int Capacity
    {
        get { return _capacity; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity must be greater than 0");
            }
            _capacity = value;
        }
    }

    public Transport(int capacity)
    {
        _capacity = capacity;
    }

    public abstract string LoadCargo();

    public virtual void DecreaseCapacity(int capacityWeight)
    {
        if (_capacity < capacityWeight)
        {
            throw new InvalidOperationException("Error: Capacity must be greater than capacityWeight");
        }
        _capacity -= capacityWeight;
    }
}