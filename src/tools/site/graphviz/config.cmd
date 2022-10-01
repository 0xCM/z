@echo off
set ToolId=dot
set ToolGroup=graphviz
set ToolExe=%ToolId%.exe
set InstallBase=%Views%\tools\%ToolId%\bin
set HelpKind=help
set HelpCmd=--help
call %Toolbase%\config-grouped.cmd

