@echo off
call %~dp0..\config.cmd

set ScriptCmd=%Toolbase%\emit-help1.cmd
set HelpKind=help
set HelpArgs=--help
call %ScriptCmd%
