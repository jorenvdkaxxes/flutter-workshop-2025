using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Infrastructure;

namespace Products.Infrastructure;

public abstract class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
{
    public ProductDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration(GetBasePath(), GetConfigurationFileName());
        var options = GetDbContextOptions(configuration);

        return new ProductDbContext(options, default!);
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

    protected abstract DbContextOptions<ProductDbContext> GetDbContextOptions(IConfiguration configuration);
}
