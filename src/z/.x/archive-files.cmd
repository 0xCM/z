@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%SlnArchive%
set ArchiveLogPath=%DevArchives%\%SlnId%.archive.log
set XD=/xd %SlnRoot%\.git
set ArchiveLogFlags=/v /e /fp
set ArchiveSln=robocopy %Src% %Dst% %XD% %ArchiveLogFlags% /log:%ArchiveLogPath%
echo ArchiveSln:%ArchiveSln%
call %ArchiveSln%
