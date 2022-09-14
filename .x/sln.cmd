@echo off
call %~dp0..\config.cmd
cd %SlnDir%
del %SlnId%.sln 1>nul 2>nul
dotnet new sln
dotnet sln add %SlnRoot%\src\cmd\z0.cmd.csproj
