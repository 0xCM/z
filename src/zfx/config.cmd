@echo off
set Area=src
set ProjectId=zfx
set ShellId=zfx
call %~dp0..\config.cmd
set SlnRoot=%SlnRoot%\cmd
set Deployments=%DevTools%\z0
set ProjectBin=%SlnBin%\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%
