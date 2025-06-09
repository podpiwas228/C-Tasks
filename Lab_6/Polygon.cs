/// <summary>
/// Represents a generic polygon using an array of vertices.
/// </summary>
class Polygon : IComparable<Polygon>
{
    /// <summary>
    /// Array of vertices as (X, Y) tuples.
    /// </summary>
    public (double X, double Y)[] Vertices;

    /// <summary>
    /// Initializes a polygon with specified vertices.
    /// </summary>
    public Polygon((double, double)[] vertices)
    {
        Vertices = vertices;
    }

    /// <summary>
    /// Calculates the perimeter of the polygon.
    /// </summary>
    public double GetPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i < Vertices.Length; i++)
        {
            var p1 = Vertices[i];
            var p2 = Vertices[(i + 1) % Vertices.Length];

            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            perimeter += Math.Sqrt(dx * dx + dy * dy);
        }
        return perimeter;
    }

    /// <summary>
    /// Compares this polygon with another by perimeter length.
    /// </summary>
    public int CompareTo(Polygon other)
    {
        if (other == null) return 1;
        return GetPerimeter().CompareTo(other.GetPerimeter());
    }
}
