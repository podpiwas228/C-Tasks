/// <summary>
/// Represents a rectangle shape.
/// </summary>
class Rectangle : Shape
{
    private int _aLength;
    private int _bLength;

    /// <summary>
    /// Width of the rectangle.
    /// </summary>
    public int A
    {
        get => _aLength;
        private set => _aLength = value;
    }

    /// <summary>
    /// Height of the rectangle.
    /// </summary>
    public int B
    {
        get => _bLength;
        private set => _bLength = value;
    }

    /// <summary>
    /// Creates a rectangle with given dimensions.
    /// </summary>
    public Rectangle(int a, int b) : base("Rectangle", "Gray")
    {
        if (a <= 0)
            throw new ArgumentOutOfRangeException(nameof(a), "Width (A) must be greater than 0.");
        if (b <= 0)
            throw new ArgumentOutOfRangeException(nameof(b), "Height (B) must be greater than 0.");

        A = a;
        B = b;
    }

    /// <inheritdoc/>
    public override double CalculateSquare() => A * B;

    /// <inheritdoc/>
    public override string ShowInformation() => $"{Type}, {Color} {CalculateSquare():F2}";
}
