@echo off
call %~dp0..\config.cmd
%SlnRoot%\build\bin\z0.cmd\Release\net8.0\win-x64\zcmd.exe %*