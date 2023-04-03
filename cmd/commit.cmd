@echo off
call %~dp0..\config.cmd
cd %SlnRoot%
git add -A -v >> %CommitLog%
git commit -am "." -v >> %CommitLog%
git push -u origin main -v
