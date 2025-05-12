/// <summary>
/// Represents the base class for all transport types.
/// </summary>
public abstract class Transport
{
    /// <summary>
    /// Gets the current capacity of the transport.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Transport"/> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the transport.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the capacity is less than or equal to zero.</exception>
    protected Transport(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0");
        }
        Capacity = capacity;
    }

    /// <summary>
    /// Loads cargo onto the transport.
    /// </summary>
    /// <returns>A string indicating the cargo loading status.</returns>
    public abstract string LoadCargo();

    /// <summary>
    /// Decreases the transport's capacity by the specified weight.
    /// </summary>
    /// <param name="capacityWeight">The weight to subtract from the transport's capacity.</param>
    /// <exception cref="InvalidOperationException">Thrown when the capacity is less than the weight.</exception>
    public virtual void DecreaseCapacity(int capacityWeight)
    {
        if (Capacity < capacityWeight)
        {
            throw new InvalidOperationException("Error: Capacity must be greater than capacityWeight");
        }
        Capacity -= capacityWeight;
    }
}
