@echo off
call %EnvRoot%\settings\config.cmd
call %~dp0env.cmd
set WsRoot=%SlnRoot%
set WsPath=%WsRoot%
set WsRoot=%~dp0
set WsPath=%~dp0
call %VsCode%
