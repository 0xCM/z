@echo off
call %~dp0..\config.cmd
%SlnBuild%\%ProjectName%\%ToolName%.exe %*