@echo off

: set pin=%ToolPath%
: echo pin:%pin%
set ProjectId=sde
set CmdSpec=ts-node %~dp0index.ts
call %CmdSpec%>%ProjectId%.json
