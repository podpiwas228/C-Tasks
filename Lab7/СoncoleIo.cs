using Lab7.Models;
using System.Dynamic;

namespace Lab7.UI
{
    /// <summary>
    /// Handles console input and output operations.
    /// </summary>
    public class ConsoleIO
    {
        private const string _selectSports = "Select a sport using ↑ ↓ keys, then press Enter:\n";
        private const string _athletesPlaced = "Athletes who placed";
        private const string _points = ":" ;
        private const string _greater = ">";
        private const string _sport = "\nSport:";
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
            Console.Clear();
                Console.WriteLine(_selectSports);

                for (int i = 0; i < sports.Length; i++)
                {
                    var sportName = sports.GetValue(i);

                    if (i == selected)
                    {

            do
            {
           
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(_greater + i + _points + sportName);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(  i + _points + sportName);
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
            var lines = new List<string> { $"{_athletesPlaced} {place}:" };

            foreach (var group in groupedAthletes)
            {
                lines.Add(_sport+ group.Key);
                foreach (var athlete in group.Value)
                {
                    lines.Add(athlete.GetInfo());
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
