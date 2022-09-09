@echo off
call %~dp0..\config.cmd
call %PublishLib%

if errorlevel 1 goto:eof
echo Project=%ProjectId%
echo Publication=%ProjectPubs%
