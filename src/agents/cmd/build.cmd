@echo off
call %~dp0..\config.cmd
dotnet build %~dp0..\z0.%ProjectName%.csproj -c Release
: %ShellBuildCmd%