@echo off
call %~dp0..\config.cmd

set PinBase=C:\Tools\sde\intel64
set pin=%PinBase%\pin.exe
set ToolDll=%PinBase%\sde-mix-mt.dll
set work-dir=C:\Windows\system32

: set chip-check=ICE_LAKE
set cpuid-code=pentium3
set cpuid-code=pnr
set cpuid-code=icl
set cpuid-in=c:\tools\sde\misc\cpuid\%cpuid-code%\cpuid.def

set EmuTargetId=cmd
set PinLogPath=%ToolHome%\logs\pin.log
set ToolLogPath=%ToolHome%\logs\pin-tool-%cpuid-code%.log
set MixLogPath=%ToolHome%\logs\%EmuTargetId%-%cpuid-code%.log

set EmuExe=%EmuTargetId%.exe

set bridge-save-mxcsr=0
set bridge-set-mxcsr=1
set use_sahf=0
set follow_execv=1
set MixOptions=-mix -iform -disas -map_all_blocks -top_blocks 32000 -omix %MixLogPath%
set ToolOptions=-logfile %ToolLogPath% -work-dir %work-dir% -cpuid-in %cpuid-in% %MixOptions%
set CmdSpec=%pin% -mt -logfile %PinLogPath% -unique_logfile -follow_execv -t %ToolDll% %ToolOptions% -- %EmuExe%

call %CmdSpec%

