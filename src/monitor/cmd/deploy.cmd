@echo off
call %~dp0..\config.cmd
set DeployProps=-p:PublishReadyToRun=true -p:DebugType=embedded -P:PublishSingleFile=true -p:PublishDocumentationFiles=false
set DeployPath=%DevTools%\%BuildPrefix%\%ProjectName%
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %ConfigOption% %VerbosityOption% %FrameworkOption% %DeployProps% %DeployLog%
call %DeployApp%