param($installPath, $toolsPath, $package, $project)

# NB: Not set for scripts in PowerShell 2.0
if (!$PSScriptRoot)
{
    $PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
}

if ($PSVersionTable.PSVersion -lt '3.0')
{
    return
}

$importedModule = Get-Module 'StandardFramework'
$moduleToImport = Test-ModuleManifest (Join-Path $PSScriptRoot 'StandardFramework')
$import = $true
if ($importedModule)
{
    if ($importedModule.Version -le $moduleToImport.Version)
    {
        Remove-Module 'StandardFramework'
    }
    else
    {
        $import = $false
    }
}

if ($import)
{
    Import-Module $moduleToImport -DisableNameChecking
}
