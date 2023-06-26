@echo off
call %~dp0..\config.cmd
set ShellPath=%SlnBuild%\bin\z0.%ProjectName%\%ConfigName%\%FrameworkMoniker%\win-x64\%ShellName%.exe
%ShellPath% %*