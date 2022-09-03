@echo off
set ProjectId=cmd
set ShellId=zcmd
set ShellPath=%EnvRoot%/dev/z0/artifacts/dist/%ProjectId%/%ShellId%.exe
echo ProjectId:%ProjectId%
echo ShellId:%ShellId%
echo ShellPath:%ShellPath%
%ShellPath%