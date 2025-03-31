using Common.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Statistics.Infrastructure;
using Statistics.Infrastructure.Persistence.Helpers;

namespace OrderManagement.SqlServerMigrations;

public class SqliteStatisticsDbContextFactory : StatisticsDbContextFactory
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
        var connectionString = configuration.GetConnectionString(DatabaseType.Sqlite);

        var optionsBuilder = new DbContextOptionsBuilder<StatisticsDbContext>();
        optionsBuilder.UseSqlite(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqliteMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
