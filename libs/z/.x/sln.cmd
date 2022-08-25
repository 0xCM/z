@echo off
call %~dp0..\config.cmd

set SlnPath=%SlnRoot%\z0.sln
dotnet sln %SlnPath% add %SlnLibs%/z/z0.z.csproj
dotnet sln %SlnPath% add %SlnLibs%/agents/z0.agents.csproj
dotnet sln %SlnPath% add %SlnLibs%/alloc/z0.alloc.csproj
dotnet sln %SlnPath% add %SlnLibs%/asm/z0.asm.csproj
dotnet sln %SlnPath% add %SlnLibs%/asm.svc/z0.asm.svc.csproj

