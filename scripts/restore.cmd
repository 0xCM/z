@echo off
call %~dp0..\config.cmd
dotnet restore %SlnFilePath% --packages %SlnPkg% %BuildProps% --verbosity normal