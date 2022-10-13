@echo off
set ToolId=winget
set InstallBase=%EnvRoot%\tools\%ToolId%\bin
set ToolPath=%InstallBase%\%ToolId%.exe

set HelpCmd=%ToolPath% -help

set ProjectRoot=%~dp0
set ProjectDocs=%ProjectRoot%\docs
set HelpPath=%ProjectDocs%\%ToolId%.help
mkdir %ProjectDocs% 1>nul 2>nul
echo # %HelpCmd% >%HelpPath%
call %HelpCmd% >>%HelpPath%