@echo off
call %~dp0config.cmd
call %~dp0..\init.cmd
mkdir %DotNetTools% 1>nul 2>nul
