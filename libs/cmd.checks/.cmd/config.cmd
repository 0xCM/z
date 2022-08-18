@echo off
set ProjectId=cmd.checks
set WsId=cmd.checks
set Area=libs
call %~dp0..\..\.cmd\config.cmd
set WsRoot=%SlnRoot%\libs\%WsId%
set SlnPath=%WsRoot%\%WsId%.sln
