@echo off
set PackageTool=dotnet pack --include-symbols --include-source
set PackageProject=%PackageTool% %ProjectPath%
set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %ConfigName% %PackageFlags%
set Packed=%DevPacks%\zpack\packed
set Unpacked=%DevPacks%\zpack\unpacked
set PackSln=dotnet pack %SlnMain% --output %Packed% %BuildProps% --include-symbols --include-source -p:SymbolPackageFormat=snupkg -p:DebugType=pdbonly
set UnpackCmd=nuget init %Packed% %Unpacked%
call %PackSln%
if errorlevel 1 goto:eof
call %UnpackCmd%
if errorlevel 1 goto:eof
