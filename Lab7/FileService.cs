using Lab7.Models;

namespace Lab7.Services
{
    /// <summary>
    /// Provides functionality for reading athletes from a file.
    /// </summary>
    public class FileService
    {
        private const char _comma = ',';
        /// <summary>
        /// Reads athlete data from a specified file.
        /// </summary>
        /// <param name="path">Path to the input file.</param>
        /// <returns>List of athletes read from the file.</returns>
        public List<Athlete> ReadAthletes(string path)
        {
            var list = new List<Athlete>();

            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(_comma);
                if (parts.Length != 4) continue;

                var athlete = new Athlete
                {
                    LastName = parts[0].Trim(),
                    BirthYear = int.Parse(parts[1].Trim()),
                    SportType = Enum.Parse<Sport>(parts[2].Trim()),
                    Place = int.Parse(parts[3].Trim())
                };

                list.Add(athlete);
            }

            return list;
        }
    }
}
