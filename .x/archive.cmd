@echo off
set SlnId=z0
set ProjectId=z0
call %~dp0..\config.cmd
call %ArchiveRepo%
call %ArchiveSln%
