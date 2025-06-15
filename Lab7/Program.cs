using System.Collections.Generic;
using Lab7.Models;
using Lab7.Services;
using Lab7.UI;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO io = new ConsoleIO();
            FileService fileService = new FileService();
            AthleteService athleteService = new AthleteService();

            string inputPath = "athletes.txt";
            string outputPath = "winners.txt";

            if (!System.IO.File.Exists(inputPath))
            {
                io.PrintLine("Input file 'athletes.txt' not found.");
                return;
            }

            List<Athlete> athletes = fileService.ReadAthletes(inputPath);

            Sport selectedSport = io.SelectSportFromMenu();
            io.PrintLine($"\nSelected sport: {selectedSport}\n");

            List<Athlete> filtered = athleteService.FilterBySport(athletes, selectedSport);

            foreach (Athlete athlete in filtered)
            {
                io.PrintLine(athlete.GetInfo());
            }

            io.Print("\nEnter place number to filter by: ");
            int place = int.Parse(io.ReadLine());

            Dictionary<Sport, List<Athlete>> grouped = athleteService.GroupBySportAndPlace(athletes, place);

            io.WriteGroupedToFile(outputPath, grouped, place);

            io.PrintLine($"\nResults written to file: {outputPath}");
        }
    }
}
