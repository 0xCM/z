@echo off
call %~dp0..\config.cmd
set SlnSrc=%~dp0..\assets\z0.deploy.sln
set SlnDst=%~dp0..\z0.deploy.sln
del %SlnDst% 1>nul 2>nul
cd %~dp0..\
copy %SlnSrc% %SlnDst%
set Sources=%~dp0../../src
dotnet sln %SlnDst% add %Sources%/cmd/z0.cmd.csproj
dotnet sln %SlnDst% add %Sources%/hub/z0.hub.csproj
dotnet sln %SlnDst% add %Sources%/dispatcher/z0.dispatcher.csproj
dotnet sln %SlnDst% add %~dp0..\z0.deploy.csproj