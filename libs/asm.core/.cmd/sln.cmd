@echo off
call %~dp0config.cmd

set SlnFile=z0.%ProjectId%.sln
set ProjectFile=z0.%ProjectId%.csproj
set SlnPath=%~dp0..\%SlnFile%
set ProjectPath=%~dp0..\%ProjectFile%

dotnet sln %SlnPath% add %ProjectPath%
