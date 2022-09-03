@echo off
call %~dp0config.cmd
robocopy %ZCmdDir% %Views%\db\capture\zcmd /e