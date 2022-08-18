@echo off
set ShellId=zmemc
set ProjectId=memory.checks
set Configuration=Release
set FrameworkMoniker=net6.0
set RuntimeIdentifier=win-x64
set SlnRoot=%Views%\z0
set ShellPath=%SlnRoot%\artifacts\bin\z0.%ProjectId%\%Configuration%\%FrameworkMoniker%\%RuntimeIdentifier%\%ShellId%.exe
call %ShellPath% %1 %2 %3 %4
