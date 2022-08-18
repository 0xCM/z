@echo off
call %~dp0..\config.cmd
call %PublishShell%

if errorlevel 1 goto:eof
echo Actor=%ShellId%
echo ShellPath=%PublishedShell%
