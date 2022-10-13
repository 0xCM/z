@echo off
call %~dp0..\init.cmd
set EmitHelp=%Toolsets%\emit-help-1.cmd

set ToolId=dotnet-symbol
set HelpKind=help
set HelpOptions=--help
call %EmitHelp%

set ToolId=dotnet-dump
call %EmitHelp%

set ToolId=dotnet-trace
call %EmitHelp%

set ToolId=dotnet-sos
call %EmitHelp%
