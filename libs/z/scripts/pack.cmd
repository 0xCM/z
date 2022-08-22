@echo off
@echo Level:%~dp0
call %~dp0..\config.cmd

set PackSln=dotnet pack %ProjectSln% --configuration Release --include-symbols --include-source --output %PackageOut% --version-suffix %VersionSuffix% 
call %PackSln%

