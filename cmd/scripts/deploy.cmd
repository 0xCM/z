@echo off
call %~dp0..\config.cmd
robocopy %~dp0..\artifacts %InstallBase% /e