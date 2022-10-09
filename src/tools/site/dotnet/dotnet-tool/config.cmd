@echo off
set Toolset=dotnet-tools
set InstallBase=%DOTNET_ROOT%\tools
call %~dp0..\config.cmd
set SlnId=dotnet-tools
set SlnRoot=%SlnRoot%\%SlnId%
echo SlnRoot=%SlnRoot%
set SlnLogs=%SlnRoot%\logs
set SlnDocs=%SlnRoot%\help
set CfgFile=%SlnRoot%\%Toolset%.cfg
set SlnErrors=%SlnLogs%\%Toolset%.errors.log
set SlnStatus=%SlnLogs%\%Toolset%.status.log
set DotNetSdks=%ActiveEnv%\sdks\dotnet
set DotNetTools=%DotNetSdks%\tools
set DotNetToolCatalog=dotnet tool list --tool-path %DotNetTools%

