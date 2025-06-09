/// <summary>
/// Represents a triangle shape.
/// </summary>
class Triangle : Shape
{
    private int _baseLength;
    private int _heightLength;
    private const int _numberForSquare = 2;
    private const int _numberForSquareRavn = 3;
    private const int _numberForSquareRavn1 = 4;

    /// <summary>
    /// Base length of the triangle.
    /// </summary>
    public int BaseLength
    {
        get => _baseLength;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _baseLength = value;
        }
    }

    /// <summary>
    /// Height of the triangle.
    /// </summary>
    public int HeightLength
    {
        get => _heightLength;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value must be greater than 0");
            _heightLength = value;
        }
    }

    /// <summary>
    /// Creates a triangle with specified base and height.
    /// </summary>
    public Triangle(int baseLength, int heightLength) : base("Triangle", "Blue")
    {
        BaseLength = baseLength;
        HeightLength = heightLength;
    }

    /// <inheritdoc/>
    public override double CalculateSquare()
    {
        if (BaseLength == HeightLength)
        {
            return (Math.Sqrt(_numberForSquareRavn) / _numberForSquareRavn1) * Math.Pow(BaseLength, _numberForSquare);
        }
        else
        {
            return (BaseLength * HeightLength) / _numberForSquare;
        }
    }

    /// <inheritdoc/>
    public override string ShowInformation()
    {
        return $"{Type} ,{Color} {CalculateSquare():F2}";
    }
}
