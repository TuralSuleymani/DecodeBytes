using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ExtensionMethodsDemo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatr(this IServiceCollection serviceCollection)
        {
           return serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));
        }

        public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
           return serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MY API",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
