using Consumer.Database.ReportAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace ConsumerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddDbContext<ReportDbContext>(op =>
            op.UseSqlServer("Data Source=.;Initial Catalog=MyReportDb;Integrated Security=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True"),ServiceLifetime.Singleton);
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}