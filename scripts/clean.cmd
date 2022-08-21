@echo off
set CleanProjectBin=rmdir %EnvRoot%\dev\z0\artifacts\bin /s/q
set CleanProjectObj=rmdir %EnvRoot%\dev\z0\artifacts\obj /s/q
call %CleanProjectBin%
call %CleanProjectObj%
