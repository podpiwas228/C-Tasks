using System.Collections.Generic;
using System.Linq;
using Lab7.Models;

namespace Lab7.Services
{
    public class AthleteService
    {
        public List<Athlete> FilterBySport(List<Athlete> athletes, Sport sport)
        {
            return athletes
                .Where(a => a.SportType == sport)
                .ToList(); 
        }

        public Dictionary<Sport, List<Athlete>> GroupBySportAndPlace(List<Athlete> athletes, int place)
        {
            return athletes
                .Where(a => a.Place == place)
                .GroupBy(a => a.SportType)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(a => a.GetAge()).ToList()
                );
        }
    }
}
