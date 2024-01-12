namespace StrategyWithDelegate
{
    public record Employee(int Id, string Name, decimal Salary);
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new EmployeeService()
                            .GetEmployees(x => x.Salary > 2000).ToArray();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
