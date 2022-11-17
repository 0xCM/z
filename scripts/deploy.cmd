@echo off
set BuildPrefix=z0
@REM set ProjectName=apps
@REM set ToolName=apps
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set StagePath=%DevTools%\%BuildPrefix%\stage\%ToolName%
set DeployPath=%DevTools%\%BuildPrefix%\bin
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %DeployPath%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set BuildProps=-p:PublishReadyToRun=true
set PublishApp=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions% %BuildProps%
call %PublishApp%
@REM echo StageBuild=%StageBuild%
@REM call %StageBuild%
@REM if errorlevel 1 goto:eof

@REM set DeployCmd=robocopy %StagePath% %DeployPath% /e
@REM call %DeployCmd%
