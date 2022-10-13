@echo off
call %~dp0..\init.cmd
set EmitHelp=%Toolsets%\emit-help-1.cmd

set ToolId=ghcup
set HelpKind=help
set HelpOptions=--help
call %EmitHelp%

set HelpKind=install.help
set HelpOptions=install --help
call %EmitHelp%

set HelpKind=dist.list
set HelpOptions=list
call %EmitHelp%
