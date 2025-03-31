using Common.Infrastructure.Options;
using Identity.Infrastructure;
using Identity.Infrastructure.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.SqlServerMigrations;

public class SqliteIdentityDbContextFactory : IdentityDbContextFactory
{
    protected override string GetBasePath()
    {
        return Directory.GetCurrentDirectory();
    }

    protected override string GetConfigurationFileName()
    {
        return "appsettings.json";
    }

    protected override DbContextOptions<IdentityDbContext> GetDbContextOptions(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DatabaseType.Sqlite);

        var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
        optionsBuilder.UseSqlite(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqliteMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
