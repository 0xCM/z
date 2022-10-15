@echo off
call %~dp0..\config.cmd

set LogOptions=-bl:%BuildLogs%\z0.%ProjectId%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %DevTools%\z0\zfx
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set VersionSpec=--version-suffix %VersionSuffix%
set BuildProps=
set RetractCmd=rmdir %Deployments% /s/q
set DeployTool=dotnet publish
set DeployCmd=%DeployTool% %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %VersionSpec% %BuildProps% %LogOptions%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%
: echo DeployCmd=%DeployCmd%
call %DeployCmd%
