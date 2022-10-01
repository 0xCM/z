@echo off
call %~dp0..\init.cmd
set DotNetToolInstallCmd=dotnet tool install %DotNetToolId% --tool-path %DotNetTools%
echo DotNetToolInstallCmd=%DotNetToolInstallCmd%  1>>%SlnStatus% 2>>%SlnErrors%
