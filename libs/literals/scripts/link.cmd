@echo off

set Src=%~dp0..\app.settings.csv
set Dst=%~dp0..\env\app.settings.csv
del %Src% 1>nul 2>nul
set CmdSpec=mklink %Src% %Dst%
call %CmdSpec% 1>nul
