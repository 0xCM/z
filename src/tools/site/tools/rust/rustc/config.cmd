@echo off
set ToolId=rustc
set ToolExe=%ToolId%.exe
set InstallBase=%Views%\sdks\rust\.cargo\bin
call %Toolbase%\config.cmd
set rustc=%ToolPath%

