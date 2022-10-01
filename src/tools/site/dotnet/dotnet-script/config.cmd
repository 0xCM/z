@echo off
set ToolId=dotnet-script
set ToolExe=%ToolId%.exe
set InstallBase=C:\Users\Administrator\.dotnet\tools
set Toolset=dotnet
call %~dp0..\config.cmd
set dotnet-script=%ToolPath%

set HelpArgs=--help
set HelpKind=help
call %HelpCmd1%

