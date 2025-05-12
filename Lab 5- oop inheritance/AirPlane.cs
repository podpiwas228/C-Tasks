public class Airplane : Transport
{
    public Airplane(int capacity) : base(capacity) { }

    public override string LoadCargo() => "Airplane loaded";
}