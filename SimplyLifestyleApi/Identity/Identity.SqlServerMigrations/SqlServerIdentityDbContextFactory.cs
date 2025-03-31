using Common.Infrastructure.Options;
using Identity.Infrastructure;
using Identity.Infrastructure.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductCatalog.SqlServerMigrations;

public class SqlServerIdentityDbContextFactory : IdentityDbContextFactory
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
        var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer);

        var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
        optionsBuilder.UseSqlServer(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqlServerMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
