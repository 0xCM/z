@echo off
call %~dp0..\config.cmd
set ExePath=%SlnBuild%\bin\z0.test.shell\Release\net8.0\win-x64\ztest.exe
call %ExePath% %*
