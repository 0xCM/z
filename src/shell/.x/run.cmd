@echo off
call %~dp0..\config.cmd
set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectName%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ToolName%.exe
call %ShellPath%