@echo off
call %~dp0..\config.cmd

dotnet sln %ProjectSln% add %SlnRoot%cmd/z0.cmd.csproj
dotnet sln %ProjectSln% add %SlnRoot%/cg/cg.libs/z0.cg.libs.csproj

dotnet sln %ProjectSln% add %SlnLibs%/cmd.checks/z0.cmd.checks.csproj
dotnet sln %ProjectSln% add %SlnLibs%/llvm.checks/z0.llvm.checks.csproj

dotnet sln %ProjectSln% add %SlnLibs%/clr.checks/z0.clr.checks.csproj
dotnet sln %ProjectSln% add %SlnLibs%/api.checks/z0.api.checks.csproj
dotnet sln %ProjectSln% add %SlnLibs%/asm.checks/z0.asm.checks.csproj
dotnet sln %ProjectSln% add %SlnLibs%/db.shell/z0.db.shell.csproj
dotnet sln %ProjectSln% add %SlnLibs%/wf.workers/z0.wf.workers.csproj
dotnet sln %ProjectSln% add %SlnLibs%/wf.shell/z0.wf.shell.csproj

dotnet sln %ProjectSln% add %SlnLibs%/memory.checks/z0.memory.checks.csproj

dotnet sln %ProjectSln% add %SlnShells%/calcs.check/z0.calcs.check.csproj
dotnet sln %ProjectSln% add %SlnShells%/intel/z0.intel.csproj

dotnet sln %ProjectSln% add %SlnTests%/test.units/z0.test.units.csproj
dotnet sln %ProjectSln% add %SlnTests%/test.checks/z0.test.checks.csproj
dotnet sln %ProjectSln% add %SlnTests%/test.shell/z0.test.shell.csproj

