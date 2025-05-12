public class Truck : Transport
{
    public Truck(int capacity) : base(capacity) { }

    public override string LoadCargo() => "Truck loaded";
}