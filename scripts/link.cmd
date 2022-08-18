@echo off
set ShellId=zcmd
set ProjectId=cmd
call %~dp0..\config.cmd
mkdir %Publications% 1>nul 2>nul
set Src=%Publications%\%ShellId%
set Dst=%ShellArtifacts%\publish
mklink /D %Src% %Dst% 2>nul

set ProjectId=tools.shell
set ShellId=ztool
call %~dp0..\config.cmd
set Src=%Publications%\%ShellId%
set Dst=%ShellArtifacts%\publish
mklink /D %Src% %Dst% 2>nul
