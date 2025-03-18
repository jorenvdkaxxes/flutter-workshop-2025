param(
    [Parameter(Position = 0, Mandatory = $true)]
    [string] $MigrationName
)

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$projectDir = Split-Path $scriptDir -Parent

$migrationsOutputDir = Join-Path -Path $projectDir -ChildPath "Migrations"

dotnet ef migrations add $migrationName --project $projectDir --output-dir $migrationsOutputDir