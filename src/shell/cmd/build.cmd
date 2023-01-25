@echo off
call %~dp0..\config.cmd
cd %ProjectRoot%
dotnet build