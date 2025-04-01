
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            try
            {
                int n = ReadPositiveInteger("Enter the number of months (n): ");
                List<Employee> employees = ReadEmployees(n);

                employees = employees.OrderBy(e => e.LastName).ToList();
                PrintAllEmployees(employees, n);

                PrintDepartmentAverages(employees);
                FindEmployeesWithLowSalary(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Prompts the user to enter a positive integer using the provided message. It repeatedly asks until the user provides a valid input:
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static int ReadPositiveInteger(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result > 0 ? result : throw new ArgumentException("Value must be positive");
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
        /// <summary>
        /// Reads a list of employees:
        /// </summary>
        /// <param name="monthsCount"></param>
        /// <returns></returns>
        private static List<Employee> ReadEmployees(int monthsCount)
        {
            List<Employee> employees = new List<Employee>();
            int count = ReadPositiveInteger("Enter the number of employees: ");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEmployee #{i + 1}");
                employees.Add(ReadEmployee(monthsCount));
            }
            return employees;
        }
        /// <summary>
        /// Reads the details of a single employee:
        /// </summary>
        /// <param name="monthsCount"></param>
        /// <returns></returns>
        private static Employee ReadEmployee(int monthsCount)
        {
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter department: ");
            string department = Console.ReadLine()?.Trim() ?? "";

            double[] salaries = new double[monthsCount];
            for (int i = 0; i < monthsCount; i++)
                salaries[i] = ReadSalary($"Salary for month {i + 1}: ");

            return new Employee(lastName, department, salaries);
        }
        /// <summary>
        /// Prompts the user to enter a salary for a specific month using the provided message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static double ReadSalary(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double salary))
                    return salary >= 0 ? salary : throw new ArgumentException("Salary cannot be negative");
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        /// <summary>
        /// Prints details of all employees in the provided list:
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="monthsCount"></param>
        private static void PrintAllEmployees(List<Employee> employees, int monthsCount)
        {
            Console.WriteLine("\nList of employees:");
            foreach (var emp in employees)
                Console.WriteLine($"{emp.LastName,-15} | {emp.Department,-10} | Salaries: {emp.GetSalariesString()}");
        }
        /// <summary>
        /// Calculates and prints the average salary for each department:
        /// </summary>
        /// <param name="employees"></param>

        private static void PrintDepartmentAverages(List<Employee> employees)
        {
            Console.WriteLine("\nAverage salary by department:");
            var groups = employees.GroupBy(e => e.Department);

            foreach (var group in groups)
            {
                double total = 0;
                int count = 0;
                foreach (var emp in group)
                    for (int i = 0; i < emp.MonthsCount; i++)
                    {
                        total += emp[i];
                        count++;
                    }
                Console.WriteLine($"{group.Key,-15}: {total / count:F2}");
            }
        }
        /// <summary>
        /// Finds and lists employees whose salaries are below a given threshold more than once:
        /// </summary>
        /// <param name="employees"></param>
        private static void FindEmployeesWithLowSalary(List<Employee> employees)
        {
            Console.Write("\nEnter salary threshold: ");
            double threshold = double.Parse(Console.ReadLine() ?? "0");

            var filtered = employees
                .Where(e => e.CountSalaryBelowThreshold(threshold) > 1)
                .ToList();
            if (filtered.Count == 0)
                Console.WriteLine("No employees with salary below threshold more than once.");
            else
            {
                Console.WriteLine("Employees with salary below threshold:");
                foreach (var emp in filtered)
                    Console.WriteLine($"{emp.LastName} ({emp.Department})");
            }
        }

    }
}