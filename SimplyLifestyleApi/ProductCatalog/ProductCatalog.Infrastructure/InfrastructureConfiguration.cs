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
    {
        var useSqlServer = configuration.GetUseSqlServerOption();
        string migrationsAssembly;
        if (useSqlServer)
            migrationsAssembly = "ProductCatalog.SqlServerMigrations";
        else
            migrationsAssembly = "ProductCatalog.SqliteMigrations";

        services
                .AddDBStorage<ProductDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly(),
                    migrationsAssembly)
                .AddTransient<IDbInitializer, ProductDbInitializer>();

        return services;
    }
}