@echo off
call %~dp0..\config.cmd
set DeployProps=-p:PublishReadyToRun=true -p:DebugType=embedded -p:PublishDocumentationFiles=false
set DeployPath=d:/tools/z0/monitor
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %ConfigOption% %VerbosityOption% %FrameworkOption% %DeployProps% %DeployLog%
call %DeployApp%