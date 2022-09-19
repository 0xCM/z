@echo off
set ProjectId=cmd.checks
set WsId=cmd.checks
set Area=src
call %~dp0..\..\.cmd\config.cmd
set WsRoot=%SlnRoot%\libs\%WsId%
set SlnPath=%WsRoot%\%WsId%.sln
