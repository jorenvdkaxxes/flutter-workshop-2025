using Microsoft.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string GetSqlServerConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("SqlServer");

    public static string GetSqliteConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("Sqlite");

    public static bool GetUseSqlServerOption(
        this IConfiguration configuration)
        => configuration.GetSection(nameof(DbOptions)).Get<DbOptions>().UseSqlServer;

}