@echo off
call %~dp0config.cmd
set Src=%~dp0..\%EnvId%.csv
set Dst=%AppSettings%
call %ControlScripts%\link-file.cmd