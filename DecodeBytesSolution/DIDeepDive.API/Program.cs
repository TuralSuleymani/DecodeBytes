using DIDeepDive.API.Clients;
using DIDeepDive.API.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DIDeepDive.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddTransient<AccountNumberService>();
            builder.Services.AddTransient<TransactionService>();
            builder.Services.AddKeyedTransient<IAccountNumberClient,AccountNumberClient>("ac1");
            builder.Services.AddKeyedTransient<IAccountNumberClient, DefaultAccountNumberClient>("ac2");
            //inject
            var app = builder.Build();

            app.MapControllers();
            //middlewares

            app.Run();
        }
    }
}
