using System.Reflection;
using Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statistics.Infrastructure.Persistence.Helpers;

namespace Statistics.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddStatisticsInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var useSqlServer = configuration.GetUseSqlServerOption();
        var migrationsAssembly = useSqlServer
                                ? MigrationHelper.SqlServerMigrationsAssemblyName
                                : MigrationHelper.SqliteMigrationsAssemblyName;

        services
                .AddDBStorage<StatisticsDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly(),
                    migrationsAssembly)
                .AddTransient<IDbInitializer, StatisticsDbInitializer>();

        return services;
    }
}