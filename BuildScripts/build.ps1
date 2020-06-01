Import-Module -Name "$PSScriptRoot\Invoke-MsBuild\Invoke-MsBuild.psm1"


Write-Host "Retrieving base version number from AssemblyInfo.cs..." -ForegroundColor Yellow
$assemblyInfoPath = "$PSScriptRoot/../Source/ArgEditor/Properties/AssemblyInfo.cs"
$assemblyData = Get-Content -Path $assemblyInfoPath
$pattern = "AssemblyVersion\(`"([0-9]+.[0-9]+.[0-9]+).[0-9]+`"\)"
$regex = new-object System.Text.RegularExpressions.Regex ($pattern)
$matches = $regex.Matches($assemblyData)
$currentMajorMinor = $matches.Groups[1]
Write-Host ""

$newVersion = "$currentMajorMinor.0"
$newVersionZip = "$currentMajorMinor"
Write-Host "New version number: $newVersion"
Write-Host ""

if ($newVersionZip -Match '.0$')
{
    $newVersionZip = $newVersionZip.Substring(0, $newVersionZip.Length - 2)
}


Write-Host "Building solution..." -ForegroundColor Yellow
Invoke-MsBuild -Path "$PSScriptRoot/../Source/ArgEditor.sln" -MsBuildParameters "/target:Clean;Build /p:Configuration=Release;VersionAssembly=$newVersion"
Write-Host ""


Write-Host "Zipping exe file and placing it in the Artifacts folder..." -ForegroundColor Yellow
$zipFileName = "ArgEditor-$newVersionZip.zip"
Write-Host "File name: $zipFileName"
Compress-Archive -Path "$PSScriptRoot/../Source/ArgEditor/bin/Release/ArgEditor.exe" -Update -DestinationPath "$PSScriptRoot/Artifacts/$zipFileName"
Write-Host ""
