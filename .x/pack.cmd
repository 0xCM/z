@echo off
call %~dp0..\config.cmd
call %PackSln%
call %DevPacks%\unpack.cmd