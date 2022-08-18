@echo off
call %~dp0..\config.cmd
: call %RestoreProject%
call %LocalRestore%
