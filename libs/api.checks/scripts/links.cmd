@echo off
call %~dp0../config.cmd

set Src=%~dp0..\app.settings.csv
set Dst=%SlnRoot%\props\app.settings.csv
call %ControlScripts%\link-file.cmd