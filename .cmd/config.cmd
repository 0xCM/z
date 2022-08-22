@echo off
set ProjectId=cmd
call %~dp0scripts\props.cmd
call %~dp0..\config.cmd
set Scripts=%SlnRoot%\scripts
set InstallBase=%Views%\tools\z0\zcmd
