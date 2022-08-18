@echo off
set ExeName=ztool.exe
set ProjectId=tools.shell
set Artifacts=D:\drives\z\dev\z0\artifacts
set BuildPrefix=z0
set Configuration=Release
set FrameworkMoniker=net6.0
set RuntimeIdentifier=win-x64
%Artifacts%\bin\%BuildPrefix%.%ProjectId%\%Configuration%\%FrameworkMoniker%\%RuntimeIdentifier%\%ExeName%
: set CmdSpec=%comspec% /C %ztool% %*
: call %CmdSpec%
