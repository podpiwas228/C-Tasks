using System;
using System.Collections.Generic;
using System.IO;
using Lab7.Models;

namespace Lab7.UI
{
    public class ConsoleIO
    {
        public void Print(string text)
        {
            Console.Write(text);
        }

        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public Sport SelectSportFromMenu()
        {
            int selectedIndex = 0;
            ConsoleKey key;
            string[] sportNames = Enum.GetNames(typeof(Sport));

            do
            {
                Console.Clear();
                Console.WriteLine("Select sport (↑↓ arrows, Enter to confirm):\n");

                for (int i = 0; i < sportNames.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}. {sportNames[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {sportNames[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex == 0) ? sportNames.Length - 1 : selectedIndex - 1;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % sportNames.Length;

            } while (key != ConsoleKey.Enter);

            return (Sport)selectedIndex;
        }

        public void WriteGroupedToFile(string path, Dictionary<Sport, List<Athlete>> grouped, int place)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine($"{place} place::\n");

            foreach (var kvp in grouped)
            {
                writer.WriteLine(kvp.Key.ToString());
                writer.WriteLine("No.\tLast Name\tAge");

                int counter = 1;
                foreach (Athlete athlete in kvp.Value)
                {
                    writer.WriteLine($"{counter}\t{athlete.LastName}\t{athlete.GetAge()}");
                    counter++;
                }

                writer.WriteLine();
            }

            writer.Close();
        }
    }
}
