@echo off
call %~dp0..\config.cmd
set Src=%AreaProjectPath%
set Dst=%Views%\tools\z0\wf
set CmdSpec=dotnet publish %Src% --output %Dst% --verbosity minimal
call %CmdSpec%