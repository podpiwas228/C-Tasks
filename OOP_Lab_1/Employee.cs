namespace Task2
{
    /// <summary>
    /// Represents an employee with their last name, department, and salary information.
    /// </summary>
    public class Employee
    {
        private readonly string _lastName;
        private readonly string _department;
        private readonly double[] _salaries;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="lastName">The last name of the employee.</param>
        /// <param name="department">The department the employee belongs to.</param>
        /// <param name="salaries">An array of the employee's salaries over time.</param>
        public Employee(string lastName, string department, double[] salaries)
        {
            _lastName = lastName;
            _department = department;
            _salaries = salaries;
        }

        /// <summary>
        /// Gets the last name of the employee.
        /// </summary>
        public string LastName => _lastName;

        /// <summary>
        /// Gets the department of the employee.
        /// </summary>
        public string Department => _department;

        /// <summary>
        /// Gets the count of months for which the employee has salary data.
        /// </summary>
        public int MonthsCount => _salaries.Length;

        /// <summary>
        /// Gets the salary for a specific month using the provided index.
        /// </summary>
        /// <param name="index">The index of the salary to retrieve.</param>
        /// <returns>The salary for the specified month.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of bounds for the salaries array.</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _salaries.Length)
                    throw new IndexOutOfRangeException("Invalid salary index");
                return _salaries[index];
            }
        }

        /// <summary>
        /// Counts the number of months where the employee's salary is below the specified threshold.
        /// </summary>
        /// <param name="threshold">The salary threshold.</param>
        /// <returns>The number of months with salaries below the threshold.</returns>
        public int CountSalaryBelowThreshold(double threshold)
        {
            return _salaries.Count(salary => salary < threshold);
        }

        /// <summary>
        /// Returns a string representation of the employee's salaries, formatted to two decimal places.
        /// </summary>
        /// <returns>A comma-separated string of the employee's salaries.</returns>
        public string GetSalariesString()
            => string.Join(", ", _salaries.Select(salary => salary.ToString("F2")));
    }
}
