@echo off
call %~dp0..\config.cmd
robocopy %ShellBin% %Deployments% /e