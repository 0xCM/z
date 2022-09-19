@echo off
call %~dp0..\config.cmd
robocopy %ProjectBin% %PlatformDeployment% /e