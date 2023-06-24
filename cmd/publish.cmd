@echo off
set ProjectName=cmd
call %~dp0..\config.cmd
set FrameworkOption=--framework %FrameworkMoniker%
set ConfigOption=--configuration %ConfigName%
set DeployPath=d:\tools\z0\zcmd
set DeployLog=-bl:%BuildLogs%\z0.%ProjectName%.deploy.binlog 
set DeployProps=/p:PublishReadyToRun=false /p:DebugType=pdbonly /p:RuntimIdentifier=win-x64 /p:Platform=x64 /p:SelfContained=true
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %ConfigOption% %VerbosityOption% %FrameworkOption% %DeployProps% %DeployLog%
%DeployApp%