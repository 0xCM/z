@echo off
call %~dp0config.cmd
%VsCodePath% %~dp0cpp-docs
