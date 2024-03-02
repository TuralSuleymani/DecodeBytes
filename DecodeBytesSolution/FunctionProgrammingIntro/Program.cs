using FunctionProgrammingIntro.Builder;
using FunctionProgrammingIntro.Extensions;

namespace FunctionProgrammingIntro
{
    internal class Program
    {
       static (string name, int age) GetUserInfo()
        {
            return ("John Doe", 30);
        }
        static void Main(string[] args)
        {
            #region LINQ
            // Define a list of accounts
            List<Account> accounts = new List<Account>()
                {
                    new Account { Name = "John Doe", City = "New York" },
                    new Account { Name = "Jane Doe", City = "Los Angeles" },
                    new Account { Name = "Alice Smith", City = "New York" },
                    new Account { Name = "Bob Smith", City = "Chicago" }
                };

            // Group accounts by city and count the number of accounts in each group
            var accountGroups = accounts.GroupBy(account => account.City)
                                         .Select(cityGroup => new { City = cityGroup.Key, Count = cityGroup.Count() });

            // Print the city and account count for each group
            foreach (var group in accountGroups)
            {
                Console.WriteLine($"City: {group.City}, Count: {group.Count}");
            }
            #endregion

            #region Delegates
            Func<decimal, decimal> multiply = x => x * 5;
            multiply(45);
            #endregion

            #region method extensions
            var bycity = accounts.ByCity("Chicago");
            #endregion

            #region Tuples
           var userInfo = GetUserInfo();
           
            #endregion

            #region local functions
            int Multiply(int x, int y) => x * y;
            int result = Multiply(3, 4);
            #endregion

            #region immutability
            Point p = new Point(4, 5);
            Point newPoint = p.MoveX(45);
            #endregion

            #region Method chaining - builder example
            // Building a basic computer
            Computer basicComputer = new ComputerBuilder()
                                        .WithCPU("Intel i5")
                                        .WithRAM("8GB")
                                        .Build();

            // Building a gaming computer with optional GPU
            Computer gamingComputer = new ComputerBuilder()
                                        .WithCPU("AMD Ryzen 7")
                                        .WithRAM("16GB")
                                        .WithGPU("NVIDIA RTX 3070")
                                        .Build();
            #endregion
        }
    }
}
