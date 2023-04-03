@echo off
call %~dp0..\config.cmd
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set ProjectPath=%ProjectRoot%\z0.%ProjectName%.csproj
set ShellBuildCmd=%BuildTool% %ProjectPath% %ShellBuildProps%
set ProjectBuildCmd=%BuildTool% %ProjectPath% %ProjectBuildProps%
