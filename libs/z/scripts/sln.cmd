@echo off
call %~dp0..\config.cmd

dotnet sln %ProjectSln% add %SlnLibs%/z/z0.z.csproj
dotnet sln %ProjectSln% add %SlnLibs%/lib/z0.lib.csproj
