using Lab7.Models;

namespace Lab7.Services
{
    /// <summary>
    /// Provides services for filtering and grouping athletes.
    /// </summary>
    public class AthleteService
    {
        /// <summary>
        /// Filters athletes by a specific sport.
        /// </summary>
        /// <param name="athletes">List of athletes.</param>
        /// <param name="sport">Sport to filter by.</param>
        /// <returns>Filtered list of athletes.</returns>
        public List<Athlete> FilterBySport(List<Athlete> athletes, Sport sport)
        {
            return athletes.Where(a => a.SportType == sport).ToList();
        }

        /// <summary>
        /// Groups athletes by sport and filters by place. Sorts each group by age descending.
        /// </summary>
        /// <param name="athletes">List of athletes.</param>
        /// <param name="place">Place to filter by.</param>
        /// <returns>Dictionary of grouped athletes by sport.</returns>
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
