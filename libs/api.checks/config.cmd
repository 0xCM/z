@echo off

set ProjectId=api.checks
set WsId=api.checks
set ShellId=%WsId%
set AreaName=libs
set ShellRoot=%SlnRoot%\%AreaName%\%ShellId%
call %~dp0..\..\.cmd\config.cmd

