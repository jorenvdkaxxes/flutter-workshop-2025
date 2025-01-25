using Microsoft.Extensions.Configuration;
using OrderManagement.Application;

namespace OrderManagement.Infrastructure;

public static class ConfigurationExtensions
{
    public static OrderManagementSettings GetOrderManagementSettings(
        this IConfiguration configuration)
    {
        var orderManagementSettings = configuration.GetSection(nameof(OrderManagementSettings));
        var productCatalogAPIClientSettings = orderManagementSettings.GetSection(nameof(ProductCatalogAPIClientSettings));

        return new OrderManagementSettings(
                new(productCatalogAPIClientSettings.GetValue<string>(nameof(ProductCatalogAPIClientSettings.BaseUrl)))
            );
    }
}