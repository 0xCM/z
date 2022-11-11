@echo off
set ProjectName=cmd
set ToolName=zcmd
call %~dp0..\config.cmd
set ProjectBin=%Artifacts%\bin\%BuildPrefix%.%ProjectName%
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set ProjectObj=%Artifacts%\obj\%BuildPrefix%.%ProjectName%