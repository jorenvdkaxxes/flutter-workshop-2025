using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplyLifestyle.Application;

namespace SimplyLifestyle.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .ConfigureDatabase(configuration)
            .ConfigureRepositories()
            .ConfigureTransactionContext();

        return serviceCollection;
    }

    internal static IServiceCollection ConfigureDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var dbOptions = configuration
                            .GetSection(DbOptions.SectionKey)
                            .Get<DbOptions>()!;

        var useSqlServer = dbOptions.UseSqlServer;

        if(useSqlServer)
        {
            var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer)!;
            services
                .AddDbContext<SimplyLifestyleDbContext>(options =>
                    options.UseSqlServer(connectionString));
        }
        else
        {
            var connectionString = configuration.GetConnectionString(DatabaseType.Sqlite)!;
            services
                .AddDbContext<SimplyLifestyleDbContext>(options =>
                    options.UseSqlite(connectionString));
        }

        return services;
    }

    internal static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithScopedLifetime());

    internal static IServiceCollection ConfigureTransactionContext(this IServiceCollection services)
    {
        services.AddScoped<ITransactionContext, TransactionContext>();

        return services;
    }
}
