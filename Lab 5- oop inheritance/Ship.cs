public class Ship : Transport
{
    public Ship(int capacity) : base(capacity) { }

    public override string LoadCargo() => "Ship loaded";
}