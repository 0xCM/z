@echo off
set Area=src
set ProjectId=cmd
set ShellName=zcmd
set ProjectRoot=%SlnRoot%\%Area%\%ProjectId%
set ProjectBin=%SlnBin%\%BuildPrefix%.%ProjectId%\%ConfigName%\%FrameworkMoniker%\%RuntimeMoniker%
set ShellPath=%ProjectBin%\%ShellName%.exe
call %ShellPath% %*
