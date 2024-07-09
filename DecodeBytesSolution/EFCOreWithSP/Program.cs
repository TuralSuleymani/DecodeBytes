
using EFCOreWithSP.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EFCOreWithSP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new ShoppingDbContext())
            {
                dbContext.Database.EnsureCreated();
                SqlParameter num1 = new SqlParameter("@num1", 55);
                SqlParameter num2 = new SqlParameter("@num2", 156);
                SqlParameter result = new SqlParameter("@result",SqlDbType.Decimal) { Direction = ParameterDirection.Output };

                var calculatedResult =await dbContext
                    .Database
                    .ExecuteSqlRawAsync($"EXEC usp_calculateNumbers @num1, @num2,@result OUTPUT",num1,num2,result);

                Console.WriteLine(result.Value);
                
            }
            Console.ReadLine();
        }
    }
}
