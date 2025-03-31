using System.Reflection;
using Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application;
using OrderManagement.Infrastructure.Persistence.Helpers;

namespace OrderManagement.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddOrderManagementInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var useSqlServer = configuration.GetUseSqlServerOption();
        var migrationsAssembly = useSqlServer
                                ? MigrationHelper.SqlServerMigrationsAssemblyName
                                : MigrationHelper.SqliteMigrationsAssemblyName;

        services
                .AddDBStorage<OrderManagementDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly(),
                    migrationsAssembly)
                .AddTransient<IDbInitializer, OrderManagementDbInitializer>();

        services.AddHttpClients(configuration);

        return services;
    }

    public static IServiceCollection AddHttpClients(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddHttpClient<ProductCatalogHttpService>(httpClient =>
            {
                var httpClientSettings = configuration.GetOrderManagementSettings();
                httpClient.BaseAddress = new Uri(httpClientSettings.ProductCatalogAPIClientSettings.BaseUrl);
            })
            .ConfigureDefaultHttpClientHandler()
            .AddTypedClient<IProductCatalogHttpService, ProductCatalogHttpService>()
            .Services;
}