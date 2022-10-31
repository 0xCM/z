@echo off
echo %Pagebreak% >%CfgFile%
echo SlnId=%SlnId%>>%CfgFile%
echo SlnRoot=%SlnRoot%>>%CfgFile%
echo SlnScripts=%SlnScripts%>>%CfgFile%
echo DOTNET_ROOT=%DOTNET_ROOT%>>%CfgFile%
echo %Pagebreak% >>%CfgFile%
echo # Global >>%CfgFile%
echo %Pagebreak% >>%CfgFile%
set >>%CfgFile%

