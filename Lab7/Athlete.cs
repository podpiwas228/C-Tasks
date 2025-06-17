namespace Lab7.Models
{
    /// <summary>
    /// Enumeration of supported sports.
    /// </summary>
    public enum Sport
    {
        Athletics,
        Boxing,
        Swimming,
        Acrobatics
    }

    /// <summary>
    /// Represents an athlete with personal and competition information.
    /// </summary>
    public class Athlete
    {
        /// <summary>
        /// Athlete's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Athlete's birth year.
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Type of sport the athlete participates in.
        /// </summary>
        public Sport SportType { get; set; }

        /// <summary>
        /// The place the athlete achieved.
        /// </summary>
        public int Place { get; set; }

        /// <summary>
        /// Calculates the current age of the athlete.
        /// </summary>
        /// <returns>The age based on the current year.</returns>
        public int GetAge()
        {
            return DateTime.Now.Year - BirthYear;
        }

        /// <summary>
        /// Returns a formatted string containing athlete information.
        /// </summary>
        /// <returns>Formatted athlete information string.</returns>
        public string GetInfo()
        {
            return $"{LastName} ({SportType}), Birth year: {BirthYear}, Place: {Place}, Age: {GetAge()}";
        }
    }
}
