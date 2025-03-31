using Common.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Statistics.Infrastructure;
using Statistics.Infrastructure.Persistence.Helpers;

namespace ProductCatalog.SqlServerMigrations;

public class SqlServerStatisticsDbContextFactory : StatisticsDbContextFactory
{
    protected override string GetBasePath()
    {
        return Directory.GetCurrentDirectory();
    }

    protected override string GetConfigurationFileName()
    {
        return "appsettings.json";
    }

    protected override DbContextOptions<StatisticsDbContext> GetDbContextOptions(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer);

        var optionsBuilder = new DbContextOptionsBuilder<StatisticsDbContext>();
        optionsBuilder.UseSqlServer(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqlServerMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
