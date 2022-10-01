@echo off
call %~dp0..\config.cmd
set EmitCmd=%Toolbase%\emit-list.cmd

set ListKind=tools.search
set ListArgs=tool search typescript
call %EmitCmd%

set ListKind=tools.local
set ListArgs=tool list
call %EmitCmd%

set ListKind=tools.global
set ListArgs=tool list --global
call %EmitCmd%
