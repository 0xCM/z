@echo off
call %~dp0..\config.cmd
@REM cd %SlnRoot%
@REM ts-node "./site/index.tsx"

call %~dp0tsbuild.cmd
set CmdSpec=node %SiteBuild%\index.jsx
call %CmdSpec%
: cd %SlnRoot%

: ts-node "./site/index.tsx"