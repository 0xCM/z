@echo off
set BuildPrefix=z0
set Deployments=%DevTools%\%BuildPrefix%\bin
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set DeployedShell=%Deployments%\%ShellName%.exe
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.binlog
set VerbosityOption=--verbosity normal
set OutputOption=--output %Deployments%
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%
set BuildProps=-p:PublishReadyToRun=true
set RetractCmd=rmdir %Deployments% /s/q
set ProjectPdb=%Artifacts%\pdb\%BuildPrefix%.%ProjectId%
set PublishTool=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions% %BuidPrps%
set CopySymbols=copy %ProjectRuntime%\*.pdb %ProjectPdb%\ /Y
echo PublishTool=%PublishTool%
call %PublishTool%
