@echo off
call %~dp0..\config.cmd
echo cpuid-code:%cpuid-code%
set cpuid-in=%InstallBase%\misc\cpuid\%cpuid-code%\cpuid.def

set TargetId=cmd
set TargetExe=%TargetId%.exe

set work-dir=C:\Windows\system32
set LogDir=F:\Drives\Y\archives\logs
set SdeLogDir=%LogDir%\sde
mkdir %SdeLogDir% 1>nul 2>nul

set SdeConfigLog=%SdeLogDir%\%cpuid-code%.config

set SdeLogPath=%SdeLogDir%\sde-%cpuid-code%.log
echo SdeLogPath:%SdeLogPath% > %SdeConfigLog%

set MixLogPath=%SdeLogDir%\%TargetId%-%cpuid-code%.log
echo MixLogPath:%MixLogPath% >> %SdeConfigLog%

set MixOptions=-mix -iform -disas -map_all_blocks -top_blocks 32000 -omix %MixLogPath%
echo MixOptions:%MixOptions% >> %SdeConfigLog%

set ToolOptions=-logfile %SdeLogPath% -work-dir %work-dir% -cpuid-in %cpuid-in% %MixOptions%
echo ToolOptions:%ToolOptions% >> %SdeConfigLog%

set CmdSpec=%ToolPath% %ToolOptions% -- %TargetExe%
echo CmdSpec:%CmdSpec% >> %SdeConfigLog%

call %CmdSpec%
