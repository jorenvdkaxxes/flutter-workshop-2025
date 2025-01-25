using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Common.Domain;

namespace ProductCatalog.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddProductCatalogDomain(
        this IServiceCollection services)
        => services
            .AddCommonDomain(Assembly.GetExecutingAssembly());
}