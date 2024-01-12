namespace LinqApp
{
    public record Employee(int Id, string Name, decimal Salary);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList =
            [
                new Employee(1, "Simon", 4500),
                new Employee(2, "John", 3400),
                new Employee(3, "Daniel", 5600)
            ];
            
           // employeeList.FirstOrDefault()

            //LINQ methods..
            Console.WriteLine("Hello, World!");
        }
    }
}
