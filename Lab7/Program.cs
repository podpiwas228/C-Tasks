using System;
using System.Collections.Generic;
using System.IO;
using Lab7.Models;
using Lab7.Services;
using Lab7.UI;

namespace Lab7
{
    class Program
    {
        private const string InputFileNotFoundMessage = "Input file 'athletes.txt' not found.";
        private const string SelectedSportMessage = "\nSelected sport: \n";
        private const string FilteredAthletesMessage = "Filtered athletes:";
        private const string EnterPlaceMessage = "\nEnter the place number to filter by: ";
        private const string InvalidInputMessage = "Invalid input. Must be a number.";
        private const string ResultsWrittenMessage = "\nResults written to file: ";

        static void Main(string[] args)
        {
            ConsoleIO io = new ConsoleIO();
            FileService fileService = new FileService();
            AthleteService athleteService = new AthleteService();

            string inputPath = "athletes.txt";
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "winner.txt");



            if (!File.Exists(inputPath))
            {
                io.PrintLine(InputFileNotFoundMessage);
                return;
            }

            List<Athlete> athletes = fileService.ReadAthletes(inputPath);

            Sport selectedSport = io.SelectSportFromMenu();

            io.PrintLine(SelectedSportMessage + selectedSport);

            List<Athlete> filtered = athleteService.FilterBySport(athletes, selectedSport);

            io.PrintLine(FilteredAthletesMessage);

            foreach (Athlete athlete in filtered)
            {
                string athleteInfo = athlete.GetInfo();
                io.PrintLine(athleteInfo);
            }

            io.Print(EnterPlaceMessage);

            string input = io.ReadLine();

            bool isValid = int.TryParse(input, out int place);

            if (!isValid)
            {
                io.PrintLine(InvalidInputMessage);
                return;
            }

            Dictionary<Sport, List<Athlete>> grouped = athleteService.GroupBySportAndPlace(athletes, place);

            io.WriteGroupedToFile(outputPath, grouped, place);

            io.PrintLine(ResultsWrittenMessage + outputPath);
        }
    }
}
