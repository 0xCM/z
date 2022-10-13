@echo off
call %~dp0..\config.cmd
set HelpKind=help
set HelpArgs=--help
set HelpCmd=%ToolPath% %HelpArgs%
set HelpDst=%ToolHome%\docs\%ToolId%.%HelpKind%
set PageBreak=------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
echo # HelpCmd=%HelpCmd%>%HelpDst%
echo %PageBreak%>>%HelpDst%
call %HelpCmd%>>%HelpDst%
