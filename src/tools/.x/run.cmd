@echo off
call %~dp0..\config.cmd
cd %SlnRoot%
ts-node "./site/index.tsx"