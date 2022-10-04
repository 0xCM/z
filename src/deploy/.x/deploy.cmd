@echo off
call %~dp0..\config.cmd
set RetractCmd=rmdir %Deployments% /s/q
set PublishCmd=dotnet publish %ProjectPath% --output %Deployments% --configuration %ConfigName% --framework %FrameworkMoniker% --version-suffix %VersionSuffix%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%

echo PublishCmd=%PublishCmd%

call %RetractCmd% 1>nul 2>nul

call %PublishCmd%
if errorlevel 1 goto:eof

@REM call %CopySymbols%
@REM if errorlevel 1 goto:eof

@REM call %PublishSymbols%
@REM if errorlevel 1 goto:eof
