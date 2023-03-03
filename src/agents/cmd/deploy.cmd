@echo off
call %~dp0..\config.cmd
set DeployProps=-p:PublishReadyToRun=false -p:DebugType=embedded -p:PublishSingleFile=true -p:PublishDocumentationFiles=false -p:IncludeNativeLibrariesInSingleFile=true
set DeployPath=%DevTools%\%BuildPrefix%\%ProjectName%
set DeployApp=dotnet publish %ProjectPath% --output %DeployPath% %ConfigOption% %VerbosityOption% %FrameworkOption% %DeployProps% %DeployLog%
call %DeployApp%
if errorlevel 1 goto:eof
robocopy %DeployPath% %DevTools%\%BuildPrefix% /e
