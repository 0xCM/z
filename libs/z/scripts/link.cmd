@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%cmd\artifacts
set Dst=%SlnRoot%artifacts\bin\z0.%ProjectId%\%Configuration%\%FrameworkMoniker%\%RuntimeIdentifier%
set CmdSpec=mklink /D %Src% %Dst%
echo Src=%Src%
echo Dst=%Dst%
echo CmdSpec=%CmdSpec%
call %CmdSpec%