using ExtensionMethodsDemo.Api.Extensions;
using ExtensionMethodsDemo.Api.Middlewares;
using ExtensionMethodsDemo.Services.Contracts;
using ExtensionMethodsDemo.Services.Implementations;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ExtensionMethodsDemo.Services.Extensions;
namespace ExtensionMethodsDemo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //mediatr for loosely coupling
            builder.Services.AddMediatr();

            //swagger for API UI
            builder.Services.AddSwagger();

            builder.Services.RegisterServices();

            builder.Services.AddControllers();

            var app = builder.Build();

            // use global exception handling
            app.UseGlobalExceptionHandling();

            //use cache control
            app.UseCacheControl();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}