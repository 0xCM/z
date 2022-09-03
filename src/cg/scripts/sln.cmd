@echo off
set SlnName=z0.cg.sln
call %~dp0..\config.cmd
set SlnPath=%~dp0..\%SlnName%

dotnet sln %SlnPath% add %CgRoot%/cg.libs/z0.cg.libs.csproj
dotnet sln %SlnPath% add %CgRoot%/cg.shell/z0.cg.shell.csproj
dotnet sln %SlnPath% add %CgRoot%/cg.test/z0.cg.test.csproj

