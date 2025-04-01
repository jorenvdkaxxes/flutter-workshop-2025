using Common.Infrastructure;
using CustomerManagement.Infrastructure.Persistence;
using CustomerManagement.Infrastructure.Persistence.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomerManagement.Infrastructure;

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
                .AddDBStorage<CustomerDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly(),
                    migrationsAssembly)
                .AddTransient<IDbInitializer, CustomerDbInitializer>();

        return services;
    }
}