@echo off
set ProjectId=z
set Area=libs
call %~dp0..\config.cmd
%CleanSlnBin%
%CleanSlnObj%
%CleanSlnLogs%