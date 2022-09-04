@echo off
call %~dp0..\config.cmd

call %CleanSlnDist% 2>nul
call %CleanSlnBin% 2>nul
call %CleanSlnObj% 2>nul
