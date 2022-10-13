@echo off
call %~dp0..\config.cmd
set CmdLog=%ToolLogs%\install-tools.log
set CmdSpec=dotnet tool install %GlobalToolId% --global --verbosity normal
set Sep=-------------------------------------------------------------------------------------------------------------------------------------------
echo %Sep% >> %CmdLog%
echo %CmdSpec% >> %CmdLog%
call %CmdSpec% >> %CmdLog%
