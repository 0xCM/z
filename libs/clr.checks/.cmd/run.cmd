@echo off
call %~dp0config.cmd
call %DllShellPath% %1 %2 %3 %4
