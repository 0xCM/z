@echo off
set ToolId=dotnet-test
set Toolset=dotnet
set ToolExe=dotnet.exe test
set InstallBase=%DOTNET_ROOT%
call %~dp0..\config.cmd

