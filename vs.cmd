@echo off
call %~dp0config.cmd
%devenv% %SlnRoot%\src\cmd\z0.cmd.csproj