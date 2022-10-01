@echo off
call %~dp0..\config.cmd
set Src=C:\Users\Administrator\.dotnet\tools
set Dst=%Views%\tools\dotnet
set CmdSpec=robocopy %Src% %Dst% /e
set DeployLog=%ToolLogs%\deploy-tools.log
call %CmdSpec% > %DeployLog%