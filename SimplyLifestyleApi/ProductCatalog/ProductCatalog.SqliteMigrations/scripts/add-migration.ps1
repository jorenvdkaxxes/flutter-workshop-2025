param(
    [string] $MigrationName
)

dotnet ef migrations add $MigrationName --project ..\ProductCatalog.SqliteMigrations.csproj