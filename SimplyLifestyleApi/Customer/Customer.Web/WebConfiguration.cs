using Common.Web;
using CustomerManagement.Application;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddCustomerManagementWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(CustomerManagementApplicationConfiguration));
}
