/// <summary>
/// Factory class for creating <see cref="Airplane"/> instances.
/// </summary>
public class AirplaneFactory : ITransportFactory
{
    /// <summary>
    /// Creates a new instance of the <see cref="Airplane"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the airplane.</param>
    /// <returns>A new <see cref="Airplane"/> instance.</returns>
    public Transport CreateTransport(int capacity)
    {
        return new Airplane(capacity);
    }
}
