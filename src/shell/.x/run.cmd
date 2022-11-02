@echo off
call %~dp0..\config.cmd
set ShellPath=%Artifacts%\bin\%BuildPrefix%.%ProjectName%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%\%ShellName%.exe
call %ShellPath%