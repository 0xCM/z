@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%SlnArchive%
set LogPath=%DevArchives%\%SlnId%.archive.log
set XD=/xd %SlnRoot%\.git
set LogFlags=/v /e /fp
set ArchiveSln=robocopy %Src% %Dst% %XD% %LogFlags% /log:%LogPath%
echo ArchiveSln:%ArchiveSln%
call %ArchiveSln%
