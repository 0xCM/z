@echo off
call %~dp0..\config.cmd
echo %Pagebreak% > %CfgFile%
echo # SlnId=%SlnId% >> %CfgFile%
echo # SlnRoot=%SlnRoot% >> %CfgFile%
echo # SiteSrc=%SiteSrc% >> %CfgFile%
echo # SiteBuild=%SiteBuild% >> %CfgFile%
echo # SiteIndex=%SiteIndex% >> %CfgFile%
echo # SlnPaths=%SlnPaths% >> %CfgFile%
echo # NodeModules=%NodeModules% >> %CfgFile%
echo %Pagebreak% >> %CfgFile%
echo # Global >> %CfgFile%
echo %Pagebreak% >> %CfgFile%
set >> %CfgFile%

