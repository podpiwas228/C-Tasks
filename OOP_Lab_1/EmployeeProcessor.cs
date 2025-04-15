using Task2;

public class EmployeeService
{
    /// <summary>
    /// Sorts a list of employees by their last name.
    /// </summary>
    /// <param name="employees">The list of employees to be sorted.</param>
    /// <returns>A sorted list of employees by their last name.</returns>
    public List<Employee> SortEmployeesByLastName(List<Employee> employees)
    {
        return employees.OrderBy(employee => employee.LastName).ToList();
    }

    /// <summary>
    /// Calculates the average salary for each department.
    /// </summary>
    /// <param name="employees">The list of employees to calculate averages for.</param>
    /// <returns>A dictionary where the key is the department name and the value is the average salary of that department.</returns>
    public Dictionary<string, double> CalculateDepartmentAverages(List<Employee> employees)
    {
        var departmentAverages = new Dictionary<string, double>();

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

            departmentAverages[group.Key] = totalSalary / totalCount;
        }

        return departmentAverages;
    }

    /// <summary>
    /// Finds all employees whose salary is below the specified threshold in more than one month.
    /// </summary>
    /// <param name="employees">The list of employees to search through.</param>
    /// <param name="threshold">The salary threshold to compare against.</param>
    /// <returns>A list of employees whose salary is below the threshold in more than one month.</returns>
    public List<Employee> FindEmployeesBelowThreshold(List<Employee> employees, double threshold)
    {
        return employees
            .Where(employee => employee.CountSalaryBelowThreshold(threshold) > 1)
            .ToList();
    }
}
