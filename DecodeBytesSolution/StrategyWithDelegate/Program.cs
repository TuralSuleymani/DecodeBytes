namespace StrategyWithDelegate
{
    public record Employee(int Id, string Name, decimal Salary);
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = GetEmployees(x => x.Salary > 4000).ToArray();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine("Hello, World!");
        }

        static IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate)
        {
            List<Employee> employeeList =
            [
                new Employee(1, "Simon", 4500),
                new Employee(2, "john", 3400),
                new Employee(3 ,"Daniel", 5600)
            ];

            foreach (var employee in employeeList)
            {
                if (predicate(employee))
                {
                    yield return employee;
                }
            }
        }
    }
}
