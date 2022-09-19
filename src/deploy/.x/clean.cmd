@echo off
call %~dp0..\config.cmd
set CleanCmd=rmdir %ProjectBin% /s/q
call %CleanCmd%
