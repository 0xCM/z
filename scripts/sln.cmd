@echo off
set WsId=z0
call %~dp0..\config.cmd

set SlnPath=%SlnRoot%\z0.sln

dotnet sln %SlnPath% add %SlnLibs%/z/z0.z.csproj

dotnet sln %SlnPath% add %SlnRoot%/cg/cg.libs/z0.cg.libs.csproj
dotnet sln %SlnPath% add %SlnRoot%/cg/cg.shell/z0.cg.shell.csproj

dotnet sln %SlnPath% add %SlnLibs%/cmd.checks/z0.cmd.checks.csproj

dotnet sln %SlnPath% add %SlnLibs%/clr.checks/z0.clr.checks.csproj
dotnet sln %SlnPath% add %SlnLibs%/wf.workers/z0.wf.workers.csproj
dotnet sln %SlnPath% add %SlnLibs%/wf.shell/z0.wf.shell.csproj

dotnet sln %SlnPath% add %SlnTests%/test.units/z0.test.units.csproj
dotnet sln %SlnPath% add %SlnTests%/test.checks/z0.test.checks.csproj
dotnet sln %SlnPath% add %SlnTests%/test.shell/z0.test.shell.csproj


