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
        protected set => _type = value;
    }

    /// <summary>
    /// Color of the shape.
    /// </summary>
    public string? Color
    {
        get => _color;
        set => _color = value;
    }

    /// <summary>
    /// Initializes a new instance of the Shape class.
    /// </summary>
    /// <param name="type">Shape type name.</param>
    /// <param name="color">Shape color.</param>
    public Shape(string? type, string? color)
    {
        if (string.IsNullOrEmpty(type))
            throw new ArgumentNullException(nameof(type), "Type must not be null or empty.");
        if (string.IsNullOrEmpty(color))
            throw new ArgumentNullException(nameof(color), "Color must not be null or empty.");

        _type = type;
        _color = color;
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
