@echo off
set ProjectId=z
set Area=src
call %~dp0..\config.cmd
%CleanSlnBin%
%CleanSlnObj%
%CleanSlnLogs%