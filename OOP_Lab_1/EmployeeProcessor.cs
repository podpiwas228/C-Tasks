using Task2;

public class EmployeeService
{
    public List<Employee> SortEmployeesByLastName(List<Employee> employees)
    {
        return employees.OrderBy(employee => employee.LastName).ToList();
    }

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

    public List<Employee> FindEmployeesBelowThreshold(List<Employee> employees, double threshold)
    {
        return employees
            .Where(employee => employee.CountSalaryBelowThreshold(threshold) > 1)
            .ToList();
    }
}
