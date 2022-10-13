call %~dp0\config.cmd

set ProjectId=asm.lang.g

set SrcPath=%ZDev%\src\%ProjectId%\z0.%ProjectId%.csproj
echo SrcPath:%SrcPath%

set DstDir=%ZPack%\nuget
echo DstDir:%DstDir%

set Version=1.0.2
echo Version:%Version%

set Configuration=Release
echo Configuration:%Configuration%

set Verbosity=normal
echo Verbosity:%Verbosity%

dotnet pack %SrcPath% -o %DstDir% -c %Configuration% --version-suffix %Version% --verbosity %Verbosity% --include-symbols --include-source

