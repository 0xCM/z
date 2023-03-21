@echo off
set ProjectName=cmd
call %~dp0..\config.cmd
set DeployPath=%DevTools%\%BuildPrefix%\bin
set DeployLog=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.deploy.binlog
set DeployProps=-p:PublishReadyToRun=true -p:DebugType=pdbonly
set DeployProps=-p:PublishReadyToRun=true -p:DebugType=pdbonly -p:PublishDocumentationFiles=true -p:CopyDebugSymbolsFromPackages=true -p:CopyDocumentationFilesFromPackages=true
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %ConfigOption% %VerbosityOption% %FrameworkOption% %DeployProps% %DeployLog%
call %DeployApp%
