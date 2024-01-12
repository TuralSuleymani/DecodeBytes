namespace StrategyWithDelegate
{
    internal class EmployeeService
    {
        public IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate)
        {
            //repository
            List<Employee> employeeList =
            [
                new Employee(1, "Simon", 4500),
                new Employee(2, "john", 3400),
                new Employee(3, "Daniel", 5600)
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
