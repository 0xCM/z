@echo off
call %~dp0..\config.cmd
set CommitLogPath=%RepoArchives%\z0-commit.log

git add -A -v >> %CommitLogPath%
git commit -am "." -v >> %CommitLogPath%
call %GitPush%
: git push -v >> %CommitLogPath%
: call %~dp0archive.cmd