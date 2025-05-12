/// <summary>
/// Represents an airplane transport type.
/// </summary>
public class Airplane : Transport
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Airplane"/> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the airplane.</param>
    public Airplane(int capacity) : base(capacity) { }

    /// <summary>
    /// Loads cargo onto the airplane.
    /// </summary>
    /// <returns>A string indicating the airplane loading status.</returns>
    public override string LoadCargo() => "Airplane loaded";
}
