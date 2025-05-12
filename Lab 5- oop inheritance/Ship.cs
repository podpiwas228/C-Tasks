/// <summary>
/// Represents a ship transport type.
/// </summary>
public class Ship : Transport
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ship"/> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the ship.</param>
    public Ship(int capacity) : base(capacity) { }

    /// <summary>
    /// Loads cargo onto the ship.
    /// </summary>
    /// <returns>A string indicating the ship loading status.</returns>
    public override string LoadCargo() => "Ship loaded";
}
