@echo off
call %~dp0config.cmd
call %SlnScripts%\run.cmd %*
