@echo off
call %~dp0..\config.cmd
call %PackageLib%

if errorlevel 1 goto:eof
echo Project=%ProjectId%
echo Package=%PackagePath%
