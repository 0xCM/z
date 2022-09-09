@echo off
call %~dp0..\config.cmd
set RetractCmd=rmdir %Deployments% /s/q
set PublishCmd=dotnet publish %ProjectPath% --output %Deployments% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%
call %~dp0env.cmd

call %RetractCmd%
if errorlevel 1 goto:eof

call %PublishCmd%
if errorlevel 1 goto:eof

call %CopySymbols%
if errorlevel 1 goto:eof

call %PublishSymbols%
if errorlevel 1 goto:eof
