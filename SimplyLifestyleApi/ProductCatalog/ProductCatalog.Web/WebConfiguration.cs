using Common.Web;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application;

namespace ProductCatalog.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddProductCatalogWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(ProductsApplicationConfiguration));
}