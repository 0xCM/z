@echo off
set PkgDst=j:\cache\dev
dotnet pack %~dp0..\z0.lib.csproj -c Release --output j:\cache\dev
