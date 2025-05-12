/// <summary>
/// Represents a truck transport type.
/// </summary>
public class Truck : Transport
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Truck"/> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the truck.</param>
    public Truck(int capacity) : base(capacity) { }

    /// <summary>
    /// Loads cargo onto the truck.
    /// </summary>
    /// <returns>A string indicating the truck loading status.</returns>
    public override string LoadCargo() => "Truck loaded";
}
