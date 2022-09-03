@echo off
set WsId=z0
set ProjectId=cmd
set ShellId=zcmd
set WsRoot=%DevRoot%\dev\z0
call %Views%\control\.cmd\config.cmd
call %ControlScripts%\commit-z0.cmd
