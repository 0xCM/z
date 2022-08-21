@echo off
call %~dp0..\config.cmd
echo SlnRestore:%SlnRestore%
call %SlnRestore%