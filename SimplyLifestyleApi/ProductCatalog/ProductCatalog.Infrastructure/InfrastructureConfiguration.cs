using System.Reflection;
using Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.Persistence.Helpers;

namespace ProductCatalog.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddProductCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var useSqlServer = configuration.GetUseSqlServerOption();
        var migrationsAssembly = useSqlServer
                                ? MigrationHelper.SqlServerMigrationsAssemblyName
                                : MigrationHelper.SqliteMigrationsAssemblyName;

        services
                .AddDBStorage<ProductDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly(),
                    migrationsAssembly)
                .AddTransient<IDbInitializer, ProductDbInitializer>();

        return services;
    }
}