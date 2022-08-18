@echo off
call %~dp0config.cmd
: set Src=%~dp0..\bin
set Dst=%DllShellBin%
call %ControlScripts%\link-dir.cmd