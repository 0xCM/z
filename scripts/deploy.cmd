@echo off
set BuildPrefix=z0
set ProjectName=apps
set ToolName=apps
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set StagePath=%DevTools%\%BuildPrefix%\stage\%ToolName%
set DeployPath=%DevTools%\%BuildPrefix%\bin
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %StagePath%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set BuildProps=-p:PublishReadyToRun=true
set StageBuild=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions% %BuildProps%
echo StageBuild=%StageBuild%
call %StageBuild%
if errorlevel 1 goto:eof

set DeployCmd=robocopy %StagePath% %DeployPath% /e
call %DeployCmd%
