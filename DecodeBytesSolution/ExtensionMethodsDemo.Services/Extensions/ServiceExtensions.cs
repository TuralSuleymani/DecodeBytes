using ExtensionMethodsDemo.Services.Contracts;
using ExtensionMethodsDemo.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ExtensionMethodsDemo.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           return services.AddTransient<IAccountService, DefaultAccountService>()
                .AddTransient<ICreditCardService, DefaultCreditCardService>();
        }
    }
}
