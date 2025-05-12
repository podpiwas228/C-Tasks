/// <summary>
/// Handles user interaction, including displaying messages and processing input to select transport types.
/// </summary>
public class UserInteraction
{
    private string _helloMessage = "Hello, please choose your type of transport\n1: Truck\n2: AirPlane\n3: Ship";
    private int _defaultValue = 100;
    private ITransportFactory _transportFactory;
    private int _exampleValue = 30;

    /// <summary>
    /// Displays a hello message to the user.
    /// </summary>
    public void GetHelloMessage()
    {
        Console.WriteLine(_helloMessage);
    }

    /// <summary>
    /// Processes the user input and creates the corresponding transport.
    /// </summary>
    public void GetInput()
    {
        string? a = Console.ReadLine();
        try
        {
            switch (a)
            {
                case "1":
                    _transportFactory = new TruckFactory();
                    break;
                case "2":
                    _transportFactory = new AirplaneFactory();
                    break;
                case "3":
                    _transportFactory = new ShipFactory();
                    break;
                default:
                    throw new ArgumentException("Invalid transport type");
            }

            Transport transport = _transportFactory.CreateTransport(_defaultValue);
            transport.DecreaseCapacity(_exampleValue);  // Example value for weight
            Console.WriteLine($"{transport.Capacity}");
            Console.WriteLine(transport.LoadCargo());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
