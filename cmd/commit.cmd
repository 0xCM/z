@echo off
call %~dp0..\config.cmd
git add -A -v >> %CommitLog%
git commit -am "." -v >> %CommitLog%
call %GitPush%
