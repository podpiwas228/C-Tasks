public class UserInteraction 
{
    private string _helloMessage = "Hello, pls choose you type of transport\n1:Truck\n2:AirPlane\n3:Ship";
    private int _defaultValue = 100;
    private int _valueForTruck = 70; 
    private int _valueForAirplane = 10;
    private int _valueForShip = 30;
    public void GetHelloMessage()
    {
        Console.WriteLine($"{_helloMessage}"); 
    }
    public void GetInput()
    {
        string? a = Console.ReadLine();
        try
        {
            switch (a)
            {
                case "1":
                    Transport truck = new Truck(_defaultValue);
                    truck.DecreaseCapacity(_valueForTruck);
                    Console.WriteLine($"{truck.Capacity}");
                    break;
                case "2":
                    Transport airplane = new Airplane(_defaultValue);
                    airplane.DecreaseCapacity(_valueForAirplane);
                    Console.WriteLine($"{airplane.Capacity}");
                    break;
                case "3":
                    Transport ship = new Ship(_defaultValue);
                    ship.DecreaseCapacity(_valueForShip);
                    Console.WriteLine($"{ship.Capacity}");
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString());
        }
    }
}