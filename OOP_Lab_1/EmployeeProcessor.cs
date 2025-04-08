using Task2;

public class EmployeeProcessor
{
    public  List<Employee> SortEmployeesByLastName(List<Employee> employees)
    {
        return employees.OrderBy(employee => employee.LastName).ToList();
    }

    public  void PrintEmployeeDetails(List<Employee> employees)
    {
        Console.WriteLine("\nList of employees:");
        foreach (var employee in employees)
            Console.WriteLine($"{employee.LastName,-15} | {employee.Department,-10} | Salaries: {employee.GetSalariesString()}");
    }

    public void PrintDepartmentAverages(List<Employee> employees)
    {
        Console.WriteLine("\nAverage salary by department:");
        var groups = employees.GroupBy(employee => employee.Department);

        foreach (var group in groups)
        {
            double totalSalary = 0;
            int totalCount = 0;

            foreach (var employee in group)
            {
                for (int i = 0; i < employee.MonthsCount; i++)
                {
                    totalSalary += employee[i];
                    totalCount++;
                }
            }

            Console.WriteLine($"{group.Key,-15}: {totalSalary / totalCount:F2}");
        }
    }

    public void FindEmployeesBelowThreshold(List<Employee> employees, double threshold)
    {
        var filteredEmployees = employees
            .Where(employee => employee.CountSalaryBelowThreshold(threshold) > 1)
            .ToList();

        if (filteredEmployees.Count == 0)
            Console.WriteLine("No employees with salary below threshold more than once.");
        else
        {
            Console.WriteLine("Employees with salary below threshold:");
            foreach (var employee in filteredEmployees)
                Console.WriteLine($"{employee.LastName} ({employee.Department})");
        }
    }
}