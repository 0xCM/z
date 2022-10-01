@echo off
call %~dp0config.cmd
set ProjectBin=%Views%\repos\tree-sitter\%ProjectId%\target\release
set PackTarget=%DevPacks%\%ProjectId%
set PackLog=%DevPacks%\%ProjectId%.log
set PackCmd=robocopy %ProjectBin% %PackTarget% /e
set PubCmd=robocopy %PackTarget% %InstallBase% /e
call %PackCmd% > %PackLog%
call %PubCmd% >> %PackLog%

