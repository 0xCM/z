@echo off
call %~dp0..\config.cmd
set SlnRoot=%SlnRoot%\src
set ProjectRoot=%SlnRoot%\%ProjectName%
set ProjectPath=%ProjectRoot%\z0.%ProjectName%.csproj
set ShellBuildCmd=%BuildTool% %ProjectPath% %ShellBuildProps%

