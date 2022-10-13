@echo off
call %~dp0..\config.cmd
set CmdScript=%Toolbase%\emit-help1.cmd

set HelpArgs=--help
set HelpKind=help

call %CmdScript%
