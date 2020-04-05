[CmdletBinding()]
param (
    [Parameter()]
    [string]$Configuration= 'Release'
)


Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$RootPath = (Get-Item -Path $PSScriptRoot).Parent.FullName
$SolutionFilePath = Join-Path -Path $RootPath -ChildPath 'Quiz.sln'
$NuGetConfigFilePath = Join-Path -Path $RootPath -ChildPath 'nuget.config'
$RunSettingsFilePath = Join-Path -Path $RootPath -ChildPath 'datacollection.runsettings'
$TestResultsDirectoryPath = Join-Path -Path $RootPath -ChildPath 'TestResults'

if (Test-Path -Path $TestResultsDirectoryPath) {
    Remove-Item -Path $TestResultsDirectoryPath -Recurse
}

dotnet tool restore --configfile $NuGetConfigFilePath

dotnet restore $SolutionFilePath --configfile $NuGetConfigFilePath
dotnet build $SolutionFilePath --configuration $Configuration --no-restore
dotnet test $SolutionFilePath --configuration $Configuration --collect:"XPlat Code Coverage" --no-build --results-directory $TestResultsDirectoryPath --settings $RunSettingsFilePath

$CoverageReports = "$($TestResultsDirectoryPath)\*\coverage.cobertura.xml"
$TargetDirectory = Join-Path -Path $TestResultsDirectoryPath -ChildPath 'coveragereport'
dotnet reportgenerator -reports:$CoverageReports -targetdir:$TargetDirectory -reporttypes:HtmlInline

$ReportFilePath = Join-Path -Path $TargetDirectory -ChildPath 'index.htm'
Invoke-Item -Path $ReportFilePath
