using Common.Web;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application;

namespace OrderManagement.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddOrderManagementWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(OrderManagementApplicationConfiguration));
}