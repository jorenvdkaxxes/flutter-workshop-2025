using CustomerManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CustomerManagement.Infrastructure;

public abstract class CustomerDbContextFactory : IDesignTimeDbContextFactory<CustomerDbContext>
{
    public CustomerDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration(GetBasePath(), GetConfigurationFileName());
        var options = GetDbContextOptions(configuration);

        return new CustomerDbContext(options, default!);
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

    protected abstract DbContextOptions<CustomerDbContext> GetDbContextOptions(IConfiguration configuration);
}
