@echo off
set PinChip=ICE_LAKE
set CpuidPath=c:\tools\sde/misc/cpuid/icl/cpuid.def
set EmuTarget=cmd.exe

set PinPath=c:\tools\sde\ia32\pin
set Pin32Dir=c:\tools\sde\ia32\pin
set Pin64Dir=c:\tools\sde\intel64\pin
set PinLogPath=C:\Windows\system32\pin-log.txt
set Mix64Path=c:\tools\sde\intel64\sde-mix-mt.dll
set Mix32Path=c:\tools\sde\ia32\sde-mix-mt.dll
set MixLogPath=C:\Windows\system32\pin-tool-log.txt
set PinWorkDir=C:\Windows\system32

set bridge-save-mxcsr=0
set bridge-set-mxcsr=1
set use_sahf=0
set chip-check=ICE_LAKE
set cpuid-in=%CpuidPath%

set Options1=-p32 %Pin32Dir% ^
-p64 %Pin64Dir% ^
-logfile %PinLogPath%

set Options2=-bridge-save-mxcsr %bridge-save-mxcsr% ^
-bridge-set-mxcsr %bridge-set-mxcsr% ^
-use_sahf %use_sahf% ^
-follow-execv ^
-t64 %Mix64Path% ^
-t %Mix32Path% ^
-logfile %MixLogPath% ^
-work-dir %PinWorkDir% ^
-chip-check %chip-check% ^
-cpuid-in %cpuid-in% ^
-- %EmuTarget%

set CmdSpec=%PinPath% %Options1% -xxzzy %Options2%
set CmdExpect=c:\tools\sde\ia32\pin -p32 c:\tools\sde\ia32\pin -p64 c:\tools\sde\intel64\pin -logfile C:\Windows\system32\pin-log.txt -xyzzy -bridge-save-mxcsr 0 -bridge-set-mxcsr 1 -use_sahf 0 -follow-execv -t64 c:\tools\sde\intel64\sde-mix-mt.dll -t c:\tools\sde\ia32\sde-mix-mt.dll -logfile C:\Windows\system32\pin-tool-log.txt -work-dir C:\Windows\system32 -chip-check ICE_LAKE -cpuid-in c:\tools\sde/misc/cpuid/icl/cpuid.def -- cmd.exe

set CmdTestLog=%~dp0launch.log
echo Expect:%CmdExpect% > %CmdTestLog%
echo Actual:%CmdSpec% >> %CmdTestLog%


