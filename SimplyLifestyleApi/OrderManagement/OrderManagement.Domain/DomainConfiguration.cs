using System.Reflection;
using Common.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddOrderManagementDomain(
        this IServiceCollection services)
        => services
            .AddCommonDomain(
                Assembly.GetExecutingAssembly());
}