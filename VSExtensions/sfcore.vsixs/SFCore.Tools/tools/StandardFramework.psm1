$ErrorActionPreference = 'Stop'

$versionErrorMessage = 'The Standard Framework Package Manager Console Tools require Windows PowerShell 3.0 or ' +
    'higher. Install Windows Management Framework 3.0, restart Visual Studio, and try again. https://aka.ms/wmf3download'

<#
.SYNOPSIS
    Generate model exception files.

.DESCRIPTION
   Generate model exception files..

.PARAMETER Model
    The name of the model.

.PARAMETER OutputDir
    The directory to put files in. Paths are relative to the project directory. Defaults to "Models".

.PARAMETER Project
    The project to use.

.PARAMETER StartupProject
    The startup project to use. Defaults to the solution's startup project.

.PARAMETER Namespace
    The namespace to use. Matches the directory by default.

.PARAMETER Args
    Arguments passed to the application.

#>
function Generate-Exceptions(
    Model,
    $OutputDir, 
    $Project,
    $StartupProject,
    $Namespace,
    $Args)
{ 
  $params = 'exceptions', 'generate', $Name, '-a .'

  sf $params
}

Export-ModuleMember -Function Generate-Exceptions