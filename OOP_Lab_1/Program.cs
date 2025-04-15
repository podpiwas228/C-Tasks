using Task2;

class Program
{
    static void Main()
    {
        UserInteraction interaction = new UserInteraction();
        EmployeeService employeeService = new EmployeeService();

        try
        {
            int monthsCount = interaction.ReadPositiveInteger("Enter the number of months: ");
            List<Employee> employees = interaction.ReadEmployees(monthsCount);

            employees = employeeService.SortEmployeesByLastName(employees);

            interaction.PrintEmployeeDetails(employees);

            var departmentAverages = employeeService.CalculateDepartmentAverages(employees);
            interaction.PrintDepartmentAverages(departmentAverages);

            double threshold = interaction.ReadSalary("\nEnter salary threshold: ");
            var employeesBelowThreshold = employeeService.FindEmployeesBelowThreshold(employees, threshold);
            interaction.PrintEmployeesBelowThreshold(employeesBelowThreshold);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
