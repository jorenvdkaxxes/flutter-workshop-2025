using System.Reflection;
using Common.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Statistics.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddStatisticsDomain(
        this IServiceCollection services)
        => services
            .AddCommonDomain(Assembly.GetExecutingAssembly());
}