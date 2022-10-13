@echo off
call %~dp0\config.cmd
del %ToolHelpPath% 1>nul 2>nul
set HelpCmd=dotnet pack --help
call %~dp0..\emit-help.cmd
