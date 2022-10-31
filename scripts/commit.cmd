@echo off
cd %SlnRoot%
git add -A -v >> %CommitLog%
git commit -am "." -v >> %CommitLog%
call %GitPush%
