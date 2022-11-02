@echo off

set PackageTool=dotnet pack --include-symbols --include-source
set PackageProject=%PackageTool% %ProjectPath%
set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %ConfigName% %PackageFlags%
set PackageOut=%DevPacks%\stage\devpacks\nuget
set PackSln=dotnet pack --include-symbols --include-source %SlnMain% --output %PackageOut% %BuildProps%
call %PackSln%
call %DevPacks%\unpack.cmd