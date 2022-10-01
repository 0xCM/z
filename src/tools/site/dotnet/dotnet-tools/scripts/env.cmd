@echo off
call %~dp0..\config.cmd
echo # Toolset=%Toolset% >%CfgFile%
echo DotNetTools=%DotNetTools%>> %CfgFile%
echo %PageBreak% >>%CfgFile%
set >>%CfgFile%

