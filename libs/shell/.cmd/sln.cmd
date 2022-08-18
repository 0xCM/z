@echo off
call %~dp0config.cmd
dotnet sln %SlnPath% add %~dp0..\z0.shell.csproj
dotnet sln %SlnPath% add %~dp0..\..\shell.cmd\z0.shell.cmd.csproj

