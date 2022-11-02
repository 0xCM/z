call %~dp0config.cmd
set DotNetVersion=6.0.303
set DOTNET_ROOT=%SdkRoot%\dotnet\v%DotNetVersion%
set PATH=%SlnScripts%;%DOTNET_ROOT%;%PATH%
