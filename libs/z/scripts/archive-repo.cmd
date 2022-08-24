@echo off
call %~dp0..\config.cmd
set ArchiveRepo=git archive -v -o %RepoArchive% HEAD
call %ArchiveRepo%