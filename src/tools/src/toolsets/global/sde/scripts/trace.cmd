set OutDir=j:\dumps
set DstId=sde-data-0
set DebugTracePath=%OutDir%\%DstId%.log
set MixPath=%OutDir%\%DstId%-mix.log
set TargetPath=cmd.exe
set sde=c:\tools\sde\sde.exe
set MixOptions=-mix -iform -disas -map_all_blocks -top_blocks 32000 -omix %MixPath%
set CmdSpec=%sde% -debugtrace -dt_out %DebugTracePath% %MixOptions% -- %TargetPath%
echo %CmdSpec%

: c:\tools\sde\sde.exe -log -log:basename "j:\dumps\pinlogs" -- cmd.exe
: c:/tools/sde/sde.exe -debugtrace -dt_out "j:\dumps\sde-data-0.log" -mix -iform -disas -map_all_blocks -top_blocks 32000 -omix "j:\dumps\sde-data-0-mix.log" -- cmd.exe

: -log -logfile "j:\dumps\sde-data-0-pintool.log"