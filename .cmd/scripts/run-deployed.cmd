@echo off
set zcmd="%Views%\tools\z0\zcmd\zcmd.exe"
set CmdSpec=%comspec% /C %zcmd% %*
call %CmdSpec%
