using BestPracticesPart1.Config;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticesPart1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.Configure<AccountServiceConfig>(
            builder.Configuration.GetSection(AccountServiceConfig.AccountService));

            builder.Services.AddOptions<AccountServiceConfig>()
                .Bind(builder.Configuration.GetSection(AccountServiceConfig.AccountService))
                .ValidateDataAnnotations()
                .Validate(config=>
                {
                    if (config.Url.Length < 50)
                        return false;
                    return true;
                },"Url should be not less than 50 symbols");
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
