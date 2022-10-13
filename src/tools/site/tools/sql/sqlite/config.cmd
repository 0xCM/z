@echo off
set ToolId=sqlite
set ToolGroup=tools
set InstallBase=%Views%\tools\%ToolId%\tools
set ToolExe=sqlite3.exe
call %Toolbase%\config.cmd
set sqlite=%ToolPath%
