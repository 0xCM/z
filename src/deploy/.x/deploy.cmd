@echo off
call %~dp0..\config.cmd

set LogOptions=-bl:%BuildLogs%\z0.deploy.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %Deployments%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set VersionSpec=--version-suffix %VersionSuffix%
set BuildProps=-p:PublishReadyToRun=true
set RetractCmd=rmdir %Deployments% /s/q
set PubTool=dotnet publish %ProjectPath%
set PublishCmd=%PubTool% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %VersionSpec% %BuildProps% %LogOptions%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%
call %PublishCmd%
