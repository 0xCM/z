@echo off
call %~dp0..\config.cmd
set BuildPrefix=z0
set ProjectName=cmd
set ProjectRoot=%SlnRoot%\src\%ProjectName%
set ProjectPath=%ProjectRoot%\%BuildPrefix%.%ProjectName%.csproj
set VerbosityOption=--verbosity normal
set ConfigOption=--configuration %ConfigName%
set FrameworkOption=--framework %FrameworkMoniker%

set DeployMode=unpacked
set DeployPath=%DevTools%\%BuildPrefix%\bin
set LogOptions=-bl:%BuildLogs%\%BuildPrefix%.%ProjectName%.%DeployMode%.binlog
set OutputOption=--output %DeployPath%
set BuildProps=-p:PublishReadyToRun=true -p:DebugType=pdbonly -p:PublishDocumentationFiles=true -p:CopyLocalLockFileAssemblies=true -p:CopyDebugSymbolsFromPackages=true -p:CopyDocumentationFilesFromPackages=true
set PublishApp=dotnet publish %ProjectPath% %OutputOption% %ConfigOption% %VerbosityOption% %FrameworkOption% %BuildProps% %LogOptions%
call %PublishApp%


