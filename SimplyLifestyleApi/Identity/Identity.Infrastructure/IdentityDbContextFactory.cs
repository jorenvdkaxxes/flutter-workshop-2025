using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Identity.Infrastructure;

public abstract class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
    public IdentityDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration(GetBasePath(), GetConfigurationFileName());
        var options = GetDbContextOptions(configuration);

        return new IdentityDbContext(options);
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

    protected abstract DbContextOptions<IdentityDbContext> GetDbContextOptions(IConfiguration configuration);
}
