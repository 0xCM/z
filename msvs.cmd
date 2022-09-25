@echo off
call %~dp0config.cmd
devenv %RootSlnPath%
