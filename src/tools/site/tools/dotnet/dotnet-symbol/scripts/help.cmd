@echo off
call %~dp0..\config.cmd
set ToolHelpCmd=%Tool% --help
mkdir %ToolHelp% 1>nul 2>nul
call %ToolHelpCmd% >%ToolHelp%\%ToolId%.help

