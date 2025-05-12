/// <summary>
/// Factory class for creating <see cref="Truck"/> instances.
/// </summary>
public class TruckFactory : ITransportFactory
{
    /// <summary>
    /// Creates a new instance of the <see cref="Truck"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the truck.</param>
    /// <returns>A new <see cref="Truck"/> instance.</returns>
    public Transport CreateTransport(int capacity)
    {
        return new Truck(capacity);
    }
}
