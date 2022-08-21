@echo off
call %~dp0..\config.cmd
set Src=%EnvRoot%\dev\z0
set Dst=%EnvRoot%\archives\dev\%SlnId%
set XD=/xd %EnvRoot%\dev\%SlnId%\.git
set ArchiveFiles=robocopy %Src% %Dst% %XD% /e
echo ArchiveFiles:%ArchiveFiles%
call %ArchiveFiles%