@echo off
call %~dp0..\config.cmd

set CmdSpec=%Toolbase%\emit-help1.cmd

set HelpKind=help
set HelpArgs=--help
call %CmdSpec%

set HelpKind=dump-languages.list
set HellpArgs=dump-languages
call %CmdSpec%
