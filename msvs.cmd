@echo off
call %Control%\config.cmd
call %~dp0config.cmd
devenv %~dp0z0.sln


