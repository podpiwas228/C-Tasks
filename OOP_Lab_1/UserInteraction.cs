using Task2;

class UserInteraction
{
    /// <summary>
    /// Reads a positive integer from the user.
    /// </summary>
    /// <param name="message">The message to display to the user when asking for input.</param>
    /// <returns>A positive integer entered by the user.</returns>
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

    /// <summary>
    /// Reads a non-negative salary value from the user.
    /// </summary>
    /// <param name="message">The message to display to the user when asking for input.</param>
    /// <returns>A non-negative salary entered by the user.</returns>
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

    /// <summary>
    /// Reads a list of employees from the user for the specified number of months.
    /// </summary>
    /// <param name="monthsCount">The number of months for salary data.</param>
    /// <returns>A list of employees entered by the user.</returns>
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

    /// <summary>
    /// Reads the data for a single employee, including their last name, department, and salary information.
    /// </summary>
    /// <param name="monthsCount">The number of months for salary data.</param>
    /// <returns>An <see cref="Employee"/> object with the provided details.</returns>
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

    /// <summary>
    /// Prints the details of the employees, including their last name, department, and salaries.
    /// </summary>
    /// <param name="employees">The list of employees to print.</param>
    public void PrintEmployeeDetails(List<Employee> employees)
    {
        Console.WriteLine("\nList of employees:");
        foreach (var employee in employees)
            Console.WriteLine($"{employee.LastName,-15} | {employee.Department,-10} | Salaries: {employee.GetSalariesString()}");
    }

    /// <summary>
    /// Prints the average salary for each department.
    /// </summary>
    /// <param name="departmentAverages">A dictionary containing the department names as keys and their average salaries as values.</param>
    public void PrintDepartmentAverages(Dictionary<string, double> departmentAverages)
    {
        Console.WriteLine("\nAverage salary by department:");
        foreach (var department in departmentAverages)
        {
            Console.WriteLine($"{department.Key,-15}: {department.Value:F2}");
        }
    }

    /// <summary>
    /// Prints the list of employees whose salary is below the specified threshold more than once.
    /// </summary>
    /// <param name="employees">The list of employees to check.</param>
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
