@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%Views%\archives\repos\%SlnId%
set XD=/xd %Src%.git /xd %Src%.vs /xd %Src%artifacts /xd %Src%.vscode /xd %Src%deps
set CmdSpec=robocopy %Src% %Dst% /e %XD%
echo CmdSpec=%CmdSpec%
call %CmdSpec%