using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Common.Application;

namespace ProductCatalog.Application;

public static class ProductsApplicationConfiguration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddProductCatalogApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddCommonApplication(configuration, Assembly);
}