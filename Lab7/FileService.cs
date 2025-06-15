using System;
using System.Collections.Generic;
using System.IO;
using Lab7.Models;

namespace Lab7.Services
{
    public class FileService
    {
        public List<Athlete> ReadAthletes(string path)
        {
            var list = new List<Athlete>();

            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(',');
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
