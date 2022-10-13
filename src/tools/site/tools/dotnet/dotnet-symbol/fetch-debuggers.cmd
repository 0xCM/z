@echo off
call %~dp0config.cmd

::set WinSdkTools="C:\Program Files (x86)\Windows Kits\10\Tools\x64\*.exe"

set DstDir=j:\cache\symbols\deguggers

set SrcFiles="C:\Program Files (x86)\Windows Kits\10\Debuggers\x64\*.exe"
call %~dp0run.cmd

set SrcFiles="C:\Program Files (x86)\Windows Kits\10\Debuggers\x64\*.dll"
call %~dp0run.cmd

