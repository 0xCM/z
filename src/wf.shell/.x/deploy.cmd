@echo off
call %~dp0..\config.cmd
call %DeployShell%

if errorlevel 1 goto:eof
echo Actor=%ShellId%
echo ShellPath=%DeployedShell%
