@echo off
call %~dp0..\config.cmd
set FrameworkOption=--framework %FrameworkMoniker%
set ConfigOption=--configuration %ConfigName%
set DeployProps=-p:PublishReadyToRun=false -p:DebugType=embedded /p:RuntimIdentifier=win-x64 /p:Platform=x64 /p:SelfContained=true
set DeployLog=-bl:%BuildLogs%\z0.%ProjectName%.deploy.binlog
set DeployPath=d:\tools\z0\agents
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %FrameworkOption% %ConfigOption% %VerbosityOption% %DeployProps% %DeployLog%
%DeployApp%
