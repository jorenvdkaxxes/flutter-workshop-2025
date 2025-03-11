param(
    [string] $MigrationName
)

$Env:DbOptions__UseSqlServer = $true
dotnet ef migrations add $MigrationName --project ..\ProductCatalog.SqlServerMigrations.csproj --startup-project ..\..\..\ProjectStartup\ProjectStartup.csproj