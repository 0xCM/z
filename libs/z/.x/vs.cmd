@echo off
call %~dp0..\config.cmd
%devenv% %~dp0..\z.sln
