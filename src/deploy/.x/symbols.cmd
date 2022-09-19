@echo off
call %~dp0..\config.cmd
set SymbolTool=dotnet symbol --symbols --debugging --diagnostics --output %ProjectPdb%
set FetchSymbols=%SymbolTool% %ProjectRuntime%\*.dll
: call %FetchSymbols%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\
call %CopySymbols%