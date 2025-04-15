﻿using Task2;

class UserInteraction
{
    public int ReadPositiveInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                return result;
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    public double ReadSalary(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out double salary) && salary >= 0)
                return salary;
            Console.WriteLine("Invalid input. Salary cannot be negative. Please enter a valid number.");
        }
    }

    public List<Employee> ReadEmployees(int monthsCount)
    {
        List<Employee> employees = new List<Employee>();
        int employeeCount = ReadPositiveInteger("Enter the number of employees: ");

        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"\nEmployee #{i + 1}");
            employees.Add(ReadEmployee(monthsCount));
        }
        return employees;
    }

    public Employee ReadEmployee(int monthsCount)
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

    public void PrintEmployeeDetails(List<Employee> employees)
    {
        Console.WriteLine("\nList of employees:");
        foreach (var employee in employees)
            Console.WriteLine($"{employee.LastName,-15} | {employee.Department,-10} | Salaries: {employee.GetSalariesString()}");
    }

    public void PrintDepartmentAverages(Dictionary<string, double> departmentAverages)
    {
        Console.WriteLine("\nAverage salary by department:");
        foreach (var department in departmentAverages)
        {
            Console.WriteLine($"{department.Key,-15}: {department.Value:F2}");
        }
    }

    public void PrintEmployeesBelowThreshold(List<Employee> employees)
    {
        if (employees.Count == 0)
            Console.WriteLine("No employees with salary below threshold more than once.");
        else
        {
            Console.WriteLine("Employees with salary below threshold:");
            foreach (var employee in employees)
                Console.WriteLine($"{employee.LastName} ({employee.Department})");
        }
    }
}
