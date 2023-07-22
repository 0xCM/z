@echo off
call %~dp0..\config.cmd
set ShellPath=%SlnBuild%\bin\z0.agents\Release\net8.0\win-x64\agents.exe
%ShellPath% %*