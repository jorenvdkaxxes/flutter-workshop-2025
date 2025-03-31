using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OrderManagement.Infrastructure;

public abstract class OrderManagementDbContextFactory : IDesignTimeDbContextFactory<OrderManagementDbContext>
{
    public OrderManagementDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration(GetBasePath(), GetConfigurationFileName());
        var options = GetDbContextOptions(configuration);

        return new OrderManagementDbContext(options, default!);
    }

    private static IConfiguration GetConfiguration(string basePath, string configurationFileName)
    {
        var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile(configurationFileName)
                                .Build();

        return configuration;
    }

    protected abstract string GetBasePath();

    protected abstract string GetConfigurationFileName();

    protected abstract DbContextOptions<OrderManagementDbContext> GetDbContextOptions(IConfiguration configuration);
}
