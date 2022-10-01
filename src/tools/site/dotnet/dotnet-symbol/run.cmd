@echo off

mkdir %DstDir% 1>nul 2>nul

set CmdOptions=--output %DstDir%
set CmdArgs=--diagnostics --debugging --modules --symbols --recurse-subdirectories --output %DstDir% %SrcFiles%

set CmdSpec=%Tool% %CmdArgs%
echo CmdSpec:%CmdSpec%

%CmdSpec%




: dotnet symbol --symbols --modules --debugging --diagnostics --output symbols --cache-directory bin\  bin\*.dll

