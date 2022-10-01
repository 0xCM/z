@echo off
call %~dp0..\config.cmd

setx /M tree-sitter %tree-sitter% 1>nul

set FuckYou=C:\Users\Administrator\AppData\Roaming\tree-sitter
set FuckOff=%InstallBase%

mklink /D %FuckYou% %FuckOff% 
mklink %~dp0config.json %InstallBase%\config.json
