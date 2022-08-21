@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%EnvRoot%/archives/dev/%SlnId%
set XD=/xd %Src%/.git
set ArchiveFiles=robocopy %Src% %Dst% %XD% /mir
echo ArchiveFiles:%ArchiveFiles%
call %ArchiveFiles%