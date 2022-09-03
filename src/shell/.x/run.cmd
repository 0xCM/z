@echo off
set zcmd="%DevRoot%\dev\z0\.build\bin\z0.shell\release\net6.0\win-x64\zshell.exe"
set CmdSpec=%comspec% /C %zcmd% %*
call %CmdSpec%
