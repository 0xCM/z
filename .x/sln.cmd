@echo off
call %~dp0..\config.cmd

dotnet sln add %SlnRoot%\src\cmd\z0.cmd.csproj

