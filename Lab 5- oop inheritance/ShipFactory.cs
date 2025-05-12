/// <summary>
/// Factory class for creating <see cref="Ship"/> instances.
/// </summary>
public class ShipFactory : ITransportFactory
{
    /// <summary>
    /// Creates a new instance of the <see cref="Ship"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the ship.</param>
    /// <returns>A new <see cref="Ship"/> instance.</returns>
    public Transport CreateTransport(int capacity)
    {
        return new Ship(capacity);
    }
}
