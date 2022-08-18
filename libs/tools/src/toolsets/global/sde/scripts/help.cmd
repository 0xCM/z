@echo off
call %~dp0..\config.cmd

set ToolId=sde
set CmdSpec=%sde% -help
echo CmdSpec:%CmdSpec%
set HelpPath=%ToolDocs%\%ToolId%-summary.help
echo ## %CmdSpec% > %HelpPath%
call %CmdSpec% >> %HelpPath%

set CmdSpec=%sde% -help-long
echo CmdSpec:%CmdSpec%
set HelpPath=%ToolDocs%\%ToolId%.help
echo ## %CmdSpec% > %HelpPath%
call %CmdSpec% >> %HelpPath%

set CmdSpec=%sde% -debugtrace -thelp
echo CmdSpec:%CmdSpec%
set HelpPath=%ToolDocs%\%ToolId%-debugtrace.help
echo ## %CmdSpec% > %HelpPath%
call %CmdSpec% >> %HelpPath%

set CmdSpec=%sde% -chip-check-list -- cmd.exe
echo CmdSpec:%CmdSpec%
set HelpPath=%ToolDocs%\%ToolId%-chips.help
echo ## %CmdSpec% > %HelpPath%
call %CmdSpec% 2>> %HelpPath%

set ToolId=pin
set CmdSpec=%pin% -help
echo CmdSpec:%CmdSpec%
set HelpPath=%ToolDocs%\%ToolId%.help
echo ## %CmdSpec% > %HelpPath%
%CmdSpec% >> %HelpPath%

: %sde% -debugtrace -thelp > %DocsDir%\sde-debugtrace.help