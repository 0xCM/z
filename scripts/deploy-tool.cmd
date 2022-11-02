@echo off
set ProjectName=%1
set ToolName=%2
set ProjectRoot=%SlnRoot%\src\%ProjectName%

set Deployments=%DevTools%\%BuildPrefix%\%ToolName%
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set DeployedShell=%Deployments%\%ToolName%.exe
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %Deployments%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set BuildProps=-p:PublishReadyToRun=true
set BuildProps=
set RetractCmd=rmdir %Deployments% /s/q
set ProjectPdb=%Artifacts%\pdb\%BuildPrefix%.%ProjectId%
set PublishTool=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
set PublishSymbols=robocopy %ProjectPdb% %Deployments%
echo RetractCmd=%RetractCmd%

mkdir %Deployments% 1>nul 2>nul
: call %RetractCmd%
: if errorlevel 1 goto:eof

echo PublishShell=%PublishShell%
call %PublishTool%
