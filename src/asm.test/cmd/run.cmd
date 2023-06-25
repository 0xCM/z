@echo off
call %~dp0..\config.cmd
%SlnBuild%\bin\z0.asm.test\Release\net8.0\win-x64\asm-test.exe %*
