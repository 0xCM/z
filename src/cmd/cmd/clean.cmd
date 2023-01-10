@echo off
call %~dp0..\config.cmd
rimraf %ProjectBin%
rimref %ProjectObj%
