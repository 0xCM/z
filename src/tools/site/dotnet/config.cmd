@echo off
set Toolset=dotnet
set ToolId=dotnet
call %~dp0..\config.cmd
set CfgFile=%~dp0%Toolset%.cfg
set InstallBase=%DOTNET_ROOT%
set PATH=%InstallBase%;%PATH%
