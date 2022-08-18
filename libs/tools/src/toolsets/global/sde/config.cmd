@echo off
set ToolId=sde
set ToolGroup=tools
set InstallBase=b:\tools\sde
set ToolExe=%ToolId%.exe
set ToolPath=%InstallBase%\%ToolExe%
set sde=%ToolPath%

set HelpArgs=-help
: call %Toolbase%\config.cmd
set ToolHome=B:\devops\modules\toolsets\%ToolId%
set ToolDocs=%ToolHome%\docs

set HelpArgs=-help
set HelpKind=help
set HelpPath=%ToolDocs%\%ToolId%.%HelpKind%
set HelpCmd=%ToolPath% %HelpArgs%
echo # %HelpCmd%>%HelpPath%
call %HelpCmd% 1>>%HelpPath%

set HelpArgs=-help-long
set HelpKind=help.long
set HelpPath=%ToolDocs%\%ToolId%.%HelpKind%
set HelpCmd=%ToolPath% %HelpArgs%
echo # %HelpCmd%>%HelpPath%
call %HelpCmd% 1>>%HelpPath%


set HelpArgs=-chip-check-list -- cmd.exe 
set HelpKind=chips.help
set HelpPath=%ToolDocs%\%ToolId%.%HelpKind%
set HelpCmd=%ToolPath% %HelpArgs%
call %HelpCmd% 2>%HelpPath%

@REM set EmitHelp=%Toolbase%\emit-help1.cmd

@REM set HelpArgs=-debugtrace -thelp 
@REM set HelpKind=debugtrace
@REM call %EmitHelp%


: b:\tools\sde\sde -cpuid-in b:/tools/sde/misc/cpuid/adl/cpuid.def -- cmd.exe

