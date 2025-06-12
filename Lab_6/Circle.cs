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
        private set => _radius = value;
    }

    /// <summary>
    /// Y-coordinate of the circle center.
    /// </summary>
    public double CenterY
    {
        get => _centerY;
        private set => _centerY = value;
    }

    /// <summary>
    /// X-coordinate of the circle center.
    /// </summary>
    public double CenterX
    {
        get => _centerX;
        private set => _centerX = value;
    }

    /// <summary>
    /// Creates a circle with the specified center and radius.
    /// </summary>
    public Circle(double centerX, double centerY, double radius)
        : base("Circle", "Blue")
    {
        if (centerX <= 0)
            throw new ArgumentOutOfRangeException(nameof(centerX), "CenterX must be greater than 0.");
        if (centerY <= 0)
            throw new ArgumentOutOfRangeException(nameof(centerY), "CenterY must be greater than 0.");
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than or equal to 0.");

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
        return $"{Type}, {Color} {CalculateSquare():F2}";
    }
}
