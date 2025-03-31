using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Statistics.Infrastructure;

public abstract class StatisticsDbContextFactory : IDesignTimeDbContextFactory<StatisticsDbContext>
{
    public StatisticsDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration(GetBasePath(), GetConfigurationFileName());
        var options = GetDbContextOptions(configuration);

        return new StatisticsDbContext(options, default!);
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

    protected abstract DbContextOptions<StatisticsDbContext> GetDbContextOptions(IConfiguration configuration);
}
