@echo off
call %~dp0..\config.cmd
set Shell=%PublishedShell%
echo Shell:%Shell%
call %Shell%