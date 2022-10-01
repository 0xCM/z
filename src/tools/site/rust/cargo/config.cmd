@echo off
set ToolId=cargo
set ToolExe=%ToolId%.exe
set InstallBase=%Views%\sdks\rust\.cargo\bin
call %Toolbase%\config.cmd
set cargo=%ToolPath%

