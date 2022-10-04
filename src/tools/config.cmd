@echo off
set ProjectId=tools
set Area=src
set ShellId=zsh
call %~dp0..\config.cmd

set SlnRoot=%SlnRoot%\tools
set SlnId=tools
set NodeModules=%SlnRoot%\node_modules
set NodeBin=%NodeModules%\.bin

set SlnSrc=%SlnRoot%\src
set CfgFile=%SlnRoot%\%SlnId%.cfg
set SiteBuild=%SlnRoot%\.site
set SiteSrc=%SlnRoot%\site
set SiteIndex=%SiteSrc%\index.tsx
set SlnPaths=%NodeBin%
set PATH=%SlnPaths%;%PATH%
