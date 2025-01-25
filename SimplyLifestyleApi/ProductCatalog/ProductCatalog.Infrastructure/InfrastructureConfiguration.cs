using System.Reflection;
using Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductCatalog.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddProductCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDBStorage<ProductDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, ProductDbInitializer>();
}