/// <summary>
/// Defines the contract for transport factories to create transport instances.
/// </summary>
public interface ITransportFactory
{
    /// <summary>
    /// Creates a transport with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the transport.</param>
    /// <returns>A <see cref="Transport"/> instance.</returns>
    Transport CreateTransport(int capacity);
}
