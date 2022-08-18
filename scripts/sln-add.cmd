@echo off
set ProjectPath=%SlnLibs%\%ProjectId%\%BuildPrefix%.%ProjectId%.csproj
dotnet sln %ProjectSln% add %ProjectPath%