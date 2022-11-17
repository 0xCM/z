@echo off
call %~dp0..\config.cmd
call %SlnRoot%\scripts\deploy.cmd
@REM set SlnRoot=%~dp0..
@REM set ProjectRoot=%SlnRoot%
@REM set Deployments=%DevTools%\%BuildPrefix%\bin
@REM set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
@REM set DeployedShell=%Deployments%\%ShellName%.exe
@REM set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
@REM set VerbosityOption=--verbosity normal
@REM set OutputOption=--output %Deployments%
@REM set ConfigOption=--configuration %ConfigName%
@REM set FrameworkOption=--framework %FrameworkMoniker%
@REM set BuildProps=-p:PublishReadyToRun=true
@REM set BuildProps=
@REM set RetractCmd=rmdir %Deployments% /s/q
@REM set ProjectPdb=%Artifacts%\pdb\%BuildPrefix%.%ProjectId%
@REM set PublishTool=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions%
@REM set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
@REM : set PublishSymbols=robocopy %ProjectPdb% %Deployments%
@REM echo PublishTool=%PublishTool%
@REM call %PublishTool%
