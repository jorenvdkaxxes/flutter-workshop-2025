$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$projectDir = Split-Path $scriptDir -Parent

dotnet ef database update --project $projectDir