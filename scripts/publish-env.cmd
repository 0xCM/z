@echo off
call %~dp0..\config.cmd

set TypeName=EnvRoot
set TypeDef=`%EnvRoot%`
set CmdSpec=echo export type %TypeName% = %TypeDef%
set Dst=%~dp0..\env\types.ts
echo // Sln %SlnId%>%Dst%
call %CmdSpec%>>%Dst%

set TypeName=SlnRoot
set TypeDef=`%SlnRoot%`
set CmdSpec=echo export type %TypeName% = %TypeDef%
call %CmdSpec%>>%Dst%
