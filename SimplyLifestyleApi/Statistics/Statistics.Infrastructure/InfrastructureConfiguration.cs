using System.Reflection;
using Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Statistics.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddStatisticsInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            //.AddDBStorage<StatisticsDbContext>(
            //    configuration,
            //    Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, StatisticsDbInitializer>();
}