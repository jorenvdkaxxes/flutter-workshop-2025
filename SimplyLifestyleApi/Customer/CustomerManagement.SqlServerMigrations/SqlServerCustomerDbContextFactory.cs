using Common.Infrastructure.Options;
using CustomerManagement.Infrastructure;
using CustomerManagement.Infrastructure.Persistence;
using CustomerManagement.Infrastructure.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductCatalog.SqlServerMigrations;

public class SqlServerCustomerDbContextFactory : CustomerDbContextFactory
{
    protected override string GetBasePath()
    {
        return Directory.GetCurrentDirectory();
    }

    protected override string GetConfigurationFileName()
    {
        return "appsettings.json";
    }

    protected override DbContextOptions<CustomerDbContext> GetDbContextOptions(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DatabaseType.SqlServer);

        var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();
        optionsBuilder.UseSqlServer(
                                    connectionString,
                                    x => x.MigrationsAssembly(MigrationHelper.SqlServerMigrationsAssemblyName));

        return optionsBuilder.Options;
    }
}
