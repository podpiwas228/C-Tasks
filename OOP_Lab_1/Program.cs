using Task2;

class Program
{
    static void Main()
    {
        UserInteraction interaction = new UserInteraction();
        EmployeeProcessor processor = new EmployeeProcessor();

        try
        {
            int monthsCount = interaction.ReadPositiveInteger("Enter the number of months: ");
            List<Employee> employees = interaction.ReadEmployees(monthsCount);

            employees = processor.SortEmployeesByLastName(employees);

            UserInteraction.PrintEmployeeDetails(employees);
            processor.PrintDepartmentAverages(employees);

            Console.Write("\nEnter salary threshold: ");
            double threshold = double.Parse(Console.ReadLine() ?? "0");
            processor.FindEmployeesBelowThreshold(employees, threshold);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
