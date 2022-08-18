@echo off
call %~dp0..\config.cmd
call %DllShellPath% %1 %2 %3 %4
