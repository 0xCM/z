@echo off
call %~dp0..\config.cmd
set ProjectBin=%SlnBin%\%BuildPrefix%.%ProjectId%
set CleanCmd=rmdir %ProjectBin% /s/q
call %CleanCmd%
