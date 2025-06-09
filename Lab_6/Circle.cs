/// <summary>
/// Represents a circle shape.
/// </summary>
class Circle : Shape
{
    private double _centerX;
    private double _centerY;
    private double _radius;

    /// <summary>
    /// Radius of the circle.
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _radius = value;
        }
    }

    /// <summary>
    /// Y-coordinate of the circle center.
    /// </summary>
    public double CenterY
    {
        get => _centerY;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _centerY = value;
        }
    }

    /// <summary>
    /// X-coordinate of the circle center.
    /// </summary>
    public double CenterX
    {
        get => _centerX;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _centerX = value;
        }
    }

    /// <summary>
    /// Creates a circle with the specified center and radius.
    /// </summary>
    public Circle(double centerX, double centerY, double radius)
        : base("Circle", "Blue")
    {
        CenterX = centerX;
        CenterY = centerY;
        Radius = radius;
    }

    /// <inheritdoc/>
    public override double CalculateSquare()
    {
        return Math.PI * Radius * Radius;
    }

    /// <inheritdoc/>
    public override string ShowInformation()
    {
        return $"{Type} ,{Color} {CalculateSquare():F2}";
    }
}
