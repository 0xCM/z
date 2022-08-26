@echo off
call %~dp0..\config.cmd

dotnet sln add %SlnRoot%/libs/z/z0.z.csproj
dotnet sln add %SlnRoot%/cg/cg.test/z0.cg.test.csproj
dotnet sln add %SlnRoot%/test/test.shell/z0.test.shell.csproj  
dotnet sln add %SlnRoot%/libs/shimmer/z0.shimmer.csproj
dotnet sln add %SlnRoot%/libs/workers/z0.workers.csproj
@REM dotnet sln add %SlnRoot%/libs/clr.checks/z0.clr.checks.csproj
