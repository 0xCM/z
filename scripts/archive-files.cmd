@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%EnvRoot%\archives\dev\%SlnId%
set XD=/xd %Src%/.git /xd %Src%/.vs /xd %Src%artifacts /xd %Src%/.vscode /xd %Src%/deps
set ArchiveFiles=robocopy %Src% %Dst% /e %XD%
echo ArchiveFiles:%ArchiveFiles%
call %ArchiveFiles%