@echo off
call %~dp0config.cmd

set DotNetVer=5.0.3
set SdkType=NETCore
set NetSdkDstDir=j:\cache\symbols.dotnet\%DotNetVer%
set NetSdkSrcFiles="%ZTools%\netsdk\shared\Microsoft.%SdkType%.App\%DotNetVer%\*"

set DstDir=%NetSdkDstDir%
set SrcFiles=%NetSdkSrcFiles%

call %~dp0run.cmd


@REM mkdir %DstDir% 1>nul 2>nul

@REM set CmdOptions=--output %DstDir%
@REM set CmdFlags=--diagnostics --debugging --modules --symbols
@REM set CmdArgs=--diagnostics --debugging --modules --symbols --output %DstDir% %SrcFiles%

@REM set CmdSpec=%Tool% %CmdArgs%
@REM echo CmdSpec:%CmdSpec%

@REM %CmdSpec%
