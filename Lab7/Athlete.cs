using System;

namespace Lab7.Models
{
    public enum Sport
    {
        Athletics,
        Boxing,
        Swimming,
        Acrobatics
    }

    public class Athlete
    {
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public Sport SportType { get; set; }
        public int Place { get; set; }

        public int GetAge()
        {
            return DateTime.Now.Year - BirthYear;
        }

        public string GetInfo()
        {
            return $"{LastName} ({SportType}), Birth year: {BirthYear}, Place: {Place}, Age: {GetAge()}";
        }
    }
}
