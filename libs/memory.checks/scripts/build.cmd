@echo off
call %~dp0..\config.cmd
call %BuildProject%
if errorlevel 1 goto:eof
echo ShellId=%ShellId%
echo ShellPath=%ShellPath%

