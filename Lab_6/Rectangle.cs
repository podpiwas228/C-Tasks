/// <summary>
/// Represents a rectangle shape.
/// </summary>
class Rectangle : Shape
{
    private int _a;
    private int _b;

    /// <summary>
    /// Width of the rectangle.
    /// </summary>
    public int A
    {
        get => _a;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _a = value;
        }
    }

    /// <summary>
    /// Height of the rectangle.
    /// </summary>
    public int B
    {
        get => _b;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _b = value;
        }
    }

    /// <summary>
    /// Creates a rectangle with given dimensions.
    /// </summary>
    public Rectangle(int a, int b) : base("Rectangle", "Gray")
    {
        A = a;
        B = b;
    }

    /// <inheritdoc/>
    public override double CalculateSquare() => A * B;

    /// <inheritdoc/>
    public override string ShowInformation() => $"{Type} ,{Color} {CalculateSquare():F2}";
}
