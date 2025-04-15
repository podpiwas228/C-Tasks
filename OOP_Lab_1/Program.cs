using Task2;

class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// It interacts with the user to read employee data, process it, and display results.
    /// </summary>
    /// <remarks>
    /// This method handles the entire flow of the program, including reading input, processing employee data,
    /// calculating averages, sorting, and printing results to the user.
    /// </remarks>
    static void Main()
    {
        UserInteraction interaction = new UserInteraction();
        EmployeeService employeeService = new EmployeeService();

        try
        {
            /// <summary>
            /// Reads the number of months for salary data from the user.
            /// </summary>
            int monthsCount = interaction.ReadPositiveInteger("Enter the number of months: ");

            /// <summary>
            /// Reads the employee data (last name, department, and salary information) for the given months.
            /// </summary>
            List<Employee> employees = interaction.ReadEmployees(monthsCount);

            /// <summary>
            /// Sorts the list of employees by their last name.
            /// </summary>
            employees = employeeService.SortEmployeesByLastName(employees);

            /// <summary>
            /// Prints the details of the employees (e.g., their names and salaries).
            /// </summary>
            interaction.PrintEmployeeDetails(employees);

            /// <summary>
            /// Calculates the average salary for each department.
            /// </summary>
            var departmentAverages = employeeService.CalculateDepartmentAverages(employees);
            interaction.PrintDepartmentAverages(departmentAverages);

            /// <summary>
            /// Reads the salary threshold from the user.
            /// </summary>
            double threshold = interaction.ReadSalary("\nEnter salary threshold: ");

            /// <summary>
            /// Finds the employees whose salary is below the specified threshold in more than one month.
            /// </summary>
            var employeesBelowThreshold = employeeService.FindEmployeesBelowThreshold(employees, threshold);
            interaction.PrintEmployeesBelowThreshold(employeesBelowThreshold);
        }
        catch (Exception ex)
        {
            /// <summary>
            /// Catches any exception that occurs during program execution and rethrows it with the error message.
            /// </summary>
            throw new Exception(ex.Message);
        }
    }
}
