namespace Task2
{
    public class Employee
    {
        private readonly string _lastName;
        private readonly string _department;
        private readonly double[] _salaries;

        public Employee(string lastName, string department, double[] salaries)
        {
            _lastName = lastName;
            _department = department;
            _salaries = salaries;
        }

        public string LastName => _lastName;
        public string Department => _department;
        public int MonthsCount => _salaries.Length;

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _salaries.Length)
                    throw new IndexOutOfRangeException("Invalid salary index");
                return _salaries[index];
            }
        }

        public int CountSalaryBelowThreshold(double threshold)
        {
            int count = 0;
            foreach (var salary in _salaries)
                if (salary < threshold) count++;
            return count;
        }

        public string GetSalariesString()
            => string.Join(", ", _salaries.Select(s => s.ToString("F2")));
    }
}