@echo off
call %~dp0..\config.cmd
git archive -v -o %RepoArchive% HEAD
