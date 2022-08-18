@echo off
call %~dp0..\config.cmd

call %CleanProjectBin%
if errorlevel 1 goto:eof
echo purge:[%ProjectBin% -- /devnull]

call %CleanProjectObj%
if errorlevel 1 goto:eof
echo purge:[%ProjectObj% -- /devnull]
