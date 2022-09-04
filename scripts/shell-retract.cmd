@echo off
call %~dp0..\config.cmd
call %DeleteShellDeploymentLink% 2>nul
rmdir %ShellDeployment% 2>null