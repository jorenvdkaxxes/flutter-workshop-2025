using Common.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Infrastructure;
using Products.Infrastructure;
using Products.Infrastructure.Persistence.Helpers;

namespace ProductCatalog.SqlServerMigrations;

public class SqliteProductDbContextFactory : ProductDbContextFactory
{
    protected override string GetBasePath()
    {
        return Directory.GetCurrentDirectory();
    }

    protected override string GetConfigurationFileName()
    {
        return "appsettings.json";
    }

    protected override DbContextOptions<ProductDbContext> GetDbContextOptions(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer);

        var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
        optionsBuilder.UseSqlServer(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqliteMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
