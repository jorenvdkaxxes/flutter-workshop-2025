using Common.Domain;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddCustomerManagementDomain(
        this IServiceCollection services)
        => services
            .AddCommonDomain(Assembly.GetExecutingAssembly());
}