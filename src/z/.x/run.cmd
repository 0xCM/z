@echo off
set zcmd="%Tools%\z0\z\z.exe"
set CmdSpec=%comspec% /C %zcmd% %*
call %CmdSpec%
