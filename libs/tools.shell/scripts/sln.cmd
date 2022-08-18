@echo off
set SlnRoot=D:\Drives\Z\dev\z0\libs\tools.shell
set SlnPath=%SlnRoot%\z0.tools.shell.sln
set SlnTool=dotnet sln %SlnPath% add
set LibsRoot=D:\Drives\Z\dev\z0\libs

set CmdSpec=%SlnTool% %LibsRoot%\tools.shell\z0.tools.shell.csproj
call %CmdSpec%
set CmdSpec=%SlnTool% %LibsRoot%\tools\z0.tools.csproj
call %CmdSpec%