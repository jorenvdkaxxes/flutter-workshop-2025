using Common.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Persistence.Helpers;

namespace OrderManagement.SqlServerMigrations;

public class SqliteOrderManagementDbContextFactory : OrderManagementDbContextFactory
{
    protected override string GetBasePath()
    {
        return Directory.GetCurrentDirectory();
    }

    protected override string GetConfigurationFileName()
    {
        return "appsettings.json";
    }

    protected override DbContextOptions<OrderManagementDbContext> GetDbContextOptions(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer);

        var optionsBuilder = new DbContextOptionsBuilder<OrderManagementDbContext>();
        optionsBuilder.UseSqlServer(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqliteMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
