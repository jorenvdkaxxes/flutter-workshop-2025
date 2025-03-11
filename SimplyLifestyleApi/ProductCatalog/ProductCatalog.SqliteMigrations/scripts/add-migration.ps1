param(
    [string] $MigrationName
)

$Env:DbOptions__UseSqlServer = $false
dotnet ef migrations add $MigrationName --project ..\ProductCatalog.SqliteMigrations.csproj --startup-project ..\..\..\ProjectStartup\ProjectStartup.csproj