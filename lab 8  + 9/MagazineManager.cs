using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages a collection of magazines and provides loading and search functionality.
/// </summary>
public class MagazineManager
{
    /// <summary>
    /// Gets the list of magazines.
    /// </summary>
    public List<Magazine> Magazines { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MagazineManager"/> class.
    /// </summary>
    public MagazineManager()
    {
        Magazines = new List<Magazine>();
    }

    /// <summary>
    /// Loads magazine data from a file.
    /// </summary>
    /// <param name="path">File path to load magazines from.</param>
    public void LoadFromFile(string path)
    {
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');

            if (parts.Length == 2)
            {
                string title = parts[0];
                if (decimal.TryParse(parts[1], out decimal cost))
                {
                    Magazines.Add(new Magazine(title, cost));
                }
            }
        }
    }

    /// <summary>
    /// Finds a magazine by its title.
    /// </summary>
    /// <param name="title">Magazine title to find.</param>
    /// <returns>The <see cref="Magazine"/> instance if found; otherwise, null.</returns>
    public Magazine? FindMagazine(string title)
    {
        return Magazines.Find(m => m.Title == title);
    }
}
