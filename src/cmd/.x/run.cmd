@echo off
call %~dp0..\config.cmd
set ToolPath=%ProjectBin%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ToolName%.exe
call %ToolPath%