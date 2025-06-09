/// <summary>
/// Abstract base class representing a geometric shape.
/// </summary>
abstract class Shape
{
    private string? _type;
    private string? _color;

    /// <summary>
    /// Type of the shape (e.g., "Circle", "Triangle").
    /// </summary>
    public string? Type
    {
        get => _type;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Name must be greater than 0");
            _type = value;
        }
    }

    /// <summary>
    /// Color of the shape.
    /// </summary>
    public string? Color
    {
        get => _color;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("color must be greater than null");
            _color = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the Shape class.
    /// </summary>
    /// <param name="type">Shape type name.</param>
    /// <param name="color">Shape color.</param>
    public Shape(string? type, string? color)
    {
        Type = type;
        Color = color;
    }

    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    public abstract double CalculateSquare();

    /// <summary>
    /// Displays shape information in string format.
    /// </summary>
    public abstract string ShowInformation();
}
