@echo off
call %~dp0..\config.cmd
cd %SlnRoot%
tsc --build --verbose
