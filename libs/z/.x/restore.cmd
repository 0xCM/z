@echo off
call %~dp0..\config.cmd
mkdir %NuGetDeps% 1>nul 2>nul
call %RestoreProject%
: call %LocalRestore%