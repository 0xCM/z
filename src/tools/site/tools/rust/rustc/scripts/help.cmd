@echo off
call %~dp0..\config.cmd
del %ToolHelpPath% 1>nul 2>nul
set HelpCmd=%ToolPath% --help -v
call %Toolbase%\emit-help.cmd
: set HelpCmd=%ToolPath% -C help
: call %Toolbase%\emit-help.cmd
