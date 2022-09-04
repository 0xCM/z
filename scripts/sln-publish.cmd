@echo off
call %~dp0..\config.cmd
call %SlnPubRetract%
call %SlnPublish%
