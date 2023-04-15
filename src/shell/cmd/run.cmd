@echo off
call %~dp0..\config.cmd
set ToolPath=%SlnBuild%\bin\z0.shell\Release\net6.0\win-x64\zsh.exe
%ToolPath% %*