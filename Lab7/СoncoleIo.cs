using System;
using System.Collections.Generic;
using System.IO;
using Lab7.Models;

namespace Lab7.UI
{
    public class ConsoleIO
    {
        private const string SelectSportMessage = "Select a sport using ↑ ↓ keys, then press Enter:";
        private const string NewLine = "\n";
        private const string HeaderPrefix = "Athletes who placed ";
        private const string SportPrefix = "Sport: ";

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public Sport SelectSportFromMenu()
        {
            var sports = Enum.GetValues(typeof(Sport));
            int selected = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(SelectSportMessage);
                Console.WriteLine();

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
                {
                    if (selected == 0)
                    {
                        selected = sports.Length - 1;
                    }
                    else
                    {
                        selected = selected - 1;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selected = selected + 1;

                    if (selected == sports.Length)
                    {
                        selected = 0;
                    }
                }

            } while (key != ConsoleKey.Enter);

            return (Sport)sports.GetValue(selected);
        }

        public void WriteGroupedToFile(string filePath, Dictionary<Sport, List<Athlete>> groupedAthletes, int place)
        {
            var lines = new List<string>();

            string header = HeaderPrefix + place + ":";
            lines.Add(header);

            foreach (var group in groupedAthletes)
            {
                string sportLine = NewLine + SportPrefix + group.Key;
                lines.Add(sportLine);

                foreach (var athlete in group.Value)
                {
                    string info = athlete.GetInfo();
                    lines.Add(info);
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
