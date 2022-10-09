@echo off
call %~dp0..\init.cmd
call %DotNetToolCatalog% >%SlnLogs%\catalog.log
