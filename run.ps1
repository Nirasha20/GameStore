# GameStore run script - ensures correct .NET SDK is used
$env:PATH = "C:\Program Files\dotnet;" + $env:PATH
Set-Location -Path "$PSScriptRoot\GameStore.Api"
dotnet run
