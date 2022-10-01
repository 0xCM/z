@echo off
set ProjectId=tree-sitter
set ToolId=%ProjectId%
set DevPacks=%Views%\archives\devpacks
set InstallBase=%Views%\tools\%ProjectId%
set ToolExe=%ProjectId%.exe
call %Toolbase%\config.cmd
set tree-sitter=%ToolPath%
