@echo off
set Area=src
set ProjectId=cmd
set ShellId=zcmd
call %~dp0..\config.cmd
set SlnRoot=%SlnRoot%\cmd
set Deployments=%EnvB%\tools\z0
set ProjectBin=%SlnBin%\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%


