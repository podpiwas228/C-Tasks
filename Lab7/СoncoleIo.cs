using Lab7.Models;

namespace Lab7.UI
{
    /// <summary>
    /// Handles console input and output operations.
    /// </summary>
    public class ConsoleIO
    {
        /// <summary>
        /// Prints a message with a newline.
        /// </summary>
        public void PrintLine(string message) => Console.WriteLine(message);

        /// <summary>
        /// Prints a message without a newline.
        /// </summary>
        public void Print(string message) => Console.Write(message);

        /// <summary>
        /// Reads a line of input from the user.
        /// </summary>
        public string ReadLine() => Console.ReadLine();

        /// <summary>
        /// Allows the user to select a sport from a menu using arrow keys.
        /// </summary>
        /// <returns>The selected sport.</returns>
        public Sport SelectSportFromMenu()
        {
            var sports = Enum.GetValues(typeof(Sport));
            int selected = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Select a sport using ↑ ↓ keys, then press Enter:\n");

                for (int i = 0; i < sports.Length; i++)
                {
                    var sportName = sports.GetValue(i);

                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("> " + i + ": " + sportName);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + i + ": " + sportName);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selected = (selected == 0) ? sports.Length - 1 : selected - 1;
                else if (key == ConsoleKey.DownArrow)
                    selected = (selected + 1) % sports.Length;

            } while (key != ConsoleKey.Enter);

            return (Sport)sports.GetValue(selected);
        }

        /// <summary>
        /// Writes grouped athletes to a file, grouped by sport and filtered by place.
        /// </summary>
        /// <param name="filePath">The path of the output file.</param>
        /// <param name="groupedAthletes">The grouped athletes.</param>
        /// <param name="place">The place filter.</param>
        public void WriteGroupedToFile(string filePath, Dictionary<Sport, List<Athlete>> groupedAthletes, int place)
        {
            var lines = new List<string> { $"Athletes who placed {place}:" };

            foreach (var group in groupedAthletes)
            {
                lines.Add($"\nSport: {group.Key}");
                foreach (var athlete in group.Value)
                {
                    lines.Add(athlete.GetInfo());
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
