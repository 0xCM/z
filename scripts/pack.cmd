@echo off
set PackageTool=dotnet pack --include-symbols --include-source
set PackageProject=%PackageTool% %ProjectPath%
set PackageLib=dotnet pack %ProjectPath% --output %PackageDist% --configuration %ConfigName% %PackageFlags%
set Packed=%DevPacks%\zpack\packed
set Unpacked=%DevPacks%\zpack\unpacked
set Stage=%DevPacks%\zpack\stage
set PackSln=dotnet pack %SlnFilePath% --output %Stage% %BuildProps% --include-symbols --include-source -p:SymbolPackageFormat=snupkg -p:DebugType=pdbonly
set UnpackCmd=nuget init %Stage% %Unpacked%
mkdir %Stage% 1>nul 2>nul
call %PackSln%
if errorlevel 1 goto:eof
call %UnpackCmd%
if errorlevel 1 goto:eof
robocopy %Stage% %Packed% /e 1>nul
rm %Stage% -rf
mkdir %Stage%
