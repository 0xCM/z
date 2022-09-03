@echo off
call %~dp0config.cmd
: echo %DllShellPath%
call %DllShellPath% %1 %2 %3 %4
