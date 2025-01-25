using System.Reflection;
using Common.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Application;

public static class OrderManagementApplicationConfiguration
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddOrderManagementApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddCommonApplication(configuration, Assembly);
}